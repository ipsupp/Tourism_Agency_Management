using Microsoft.Data.SqlClient;
using Middleware.domain;
using Newtonsoft.Json;
using ServerApp.repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;


namespace ServerApp.service
{
    public class Service
    {
        private AgencyRepository agency_repository;
        private EmployeeRepository employee_repository;
        private TCompanyRepository company_repository;
        private TripRepository trip_repository;
        private ReservationRepository reservation_repository;
        private ChatLogs chatlogs = new ChatLogs();
        private List<String> activeUsers = new List<string>();

        public Service(AgencyRepository ag, EmployeeRepository em, TCompanyRepository tc, TripRepository tr, ReservationRepository rs)
        {
            this.agency_repository = ag;
            this.employee_repository = em;
            this.company_repository = tc;
            this.trip_repository = tr;
            this.reservation_repository = rs;
        }

        public async Task RunAsync()
        { 

            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://127.0.0.1:8888/");
          
            listener.Start();
            Console.WriteLine("Listening...");
            while (true) {

                // este blocat pana primim un request de la client
                HttpListenerContext context = listener.GetContext();
                Console.WriteLine("got a request");
                HandleMessage(context);

                HttpListenerResponse response = context.Response;
                var writer = new StreamWriter(response.OutputStream);
                ServerMessage serverMessage = new ServerMessage(new BoolData(true));
                string json = JsonConvert.SerializeObject(serverMessage);
                writer.Write(json);
            //    Console.WriteLine(json);
                writer.Flush();
                writer.Close();

            }
        }


        public void HandleMessage(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            string body;
            using (var reader = new StreamReader(request.InputStream,
                                 request.ContentEncoding))
            {
                body = reader.ReadToEnd();
               // Console.WriteLine(body);
                reader.Close();
            }
            ServerMessage serverMessage = JsonConvert.DeserializeObject<ServerMessage>(body);
            string requestType = serverMessage.type;

            if ("class domain.LoginInfo" == requestType)
            {
                LoginInfo loginInfo = JsonConvert.DeserializeObject<LoginInfo>(serverMessage.body);
                HandleValidateLogin(context, loginInfo);
            }
            else if ("class domain.GetTripsTable" == requestType)
            {

                  HandleGetTripsTableData(context);
            }
            else if ("class domain.GetReservationTable" == requestType)
            {
                //ChatMessage msg = JsonConvert.DeserializeObject<ChatMessage>(serverMessage.body);
                // HandleSentMessage(socket, msg);
                ReservationInfo rez = JsonConvert.DeserializeObject<ReservationInfo>(serverMessage.body);
             //   HandleReservation(context, rez);
             //todo: repair methods^
                HandleGetReservationTable(context,rez);
                
            }
            else if ("class domain.GetLookupTable" == requestType)
            {
                Search blah = JsonConvert.DeserializeObject<Search>(serverMessage.body);
                HandleGetTripsFromSearch(context, blah);
            }
            else if ("class domain.LoginLogger" == requestType)
            {
               LoginLogger bleh = JsonConvert.DeserializeObject<LoginLogger>(serverMessage.body);
                HandleActiveUsers(context, bleh);
            }
         
        }



        private void HandleGetReservationTable(HttpListenerContext context, ReservationInfo reservationInfo)
        {
            ServerMessage serverMessage = new ServerMessage();
            serverMessage.type = Convert.ToString(HandleReservation(reservationInfo));

            string dataTable = GetReservationTrip(reservationInfo.id);
            
            serverMessage.body = dataTable;
            
            HttpListenerResponse response = context.Response;
            var writer = new StreamWriter(response.OutputStream);
            string json = JsonConvert.SerializeObject(serverMessage);

            writer.Write(json);
            writer.Flush();
            writer.Close();

        }
        public string GetReservationTrip(string id)
        {
            SqlConnection cnn = new SqlConnection(CurrentAppData.connectionString);
            string query = "select id, available_seats from Trip where id =@Id";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("id", id);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            var json = JsonConvert.SerializeObject(dataTable);
            cmd.Dispose();
            cnn.Close();
            return json;

        }
        private bool HandleReservation( ReservationInfo reservationInfo)
        {
            return TryMakeReservationForTrio(reservationInfo.id, reservationInfo.name, reservationInfo.phone_number, reservationInfo.number_tickets);
        }

        public bool TryMakeReservationForTrio(string id, string name, string pn, int tickets)
        {
            SqlConnection cnn = new SqlConnection(CurrentAppData.connectionString);
            string query = "select id, available_seats from Trip where id =@Id";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("id", id);

            cnn.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();

            int desc = 0;
            while (reader.Read())
            {
                desc = (int)reader["available_seats"];
            }

            reader.Close();

            if (desc < tickets)
            {
                return false;
            }
            int newNrSeats = desc - tickets;
            query = "update Trip set available_seats=@NewNrSeats WHERE id=@Id";
            SqlCommand updateCmd = new SqlCommand(query, cnn);
            updateCmd.Parameters.AddWithValue("id", id);
            updateCmd.Parameters.AddWithValue("newnrseats", newNrSeats);
            updateCmd.ExecuteNonQuery();

            cmd.Dispose();
            return true;
        }

        private void HandleValidateLogin(HttpListenerContext context, LoginInfo loginInfo)
        {
            bool isValid = ValidateLogin(loginInfo.username, loginInfo.password);
            activeUsers.Add(loginInfo.username);

            Console.WriteLine("Validating login for user: " + loginInfo.username + " with password: " + loginInfo.password + " -> " + isValid);
            HttpListenerResponse response = context.Response;
            var writer = new StreamWriter(response.OutputStream);
            ServerMessage serverMessage = new ServerMessage(new BoolData(isValid));
            string json = JsonConvert.SerializeObject(serverMessage);
            writer.Write(json);
          //  Console.WriteLine(json);
            writer.Flush();
            writer.Close();
        }
        private void HandleActiveUsers(HttpListenerContext context,LoginLogger login)
        {
            if (login.onlineUser == null)
            {
                ServerMessage serverMessage = new ServerMessage(activeUsers);
                string json = JsonConvert.SerializeObject(serverMessage);
                HttpListenerResponse response = context.Response;
                var writer = new StreamWriter(response.OutputStream);
                writer.Write(json);
                writer.Flush();
                writer.Close();
            }
            else
            {

                activeUsers.Remove(login.onlineUser);
                Console.WriteLine("User: " + login.onlineUser + " logged out");
                ServerMessage serverMessage = new ServerMessage(activeUsers);
                string json = JsonConvert.SerializeObject(serverMessage);
                HttpListenerResponse response = context.Response;
                var writer = new StreamWriter(response.OutputStream);
                writer.Write(json);
                writer.Flush();
                writer.Close();
            }
        }

        private void HandleSentMessage(Socket clientSocket, ChatMessage msg)
        {
            if (msg.sender != null && msg.message != null)
            {
                Console.WriteLine("User: " + msg.sender + " sent message: " + msg.message);
                chatlogs.addLog(msg);
                string response = JsonConvert.SerializeObject(chatlogs);
                byte[] responseData = Encoding.UTF8.GetBytes(response);
                clientSocket.Send(responseData);
            }
            else
            {
                string response = JsonConvert.SerializeObject(chatlogs);
                byte[] responseData = Encoding.UTF8.GetBytes(response);
                clientSocket.Send(responseData);
            }
        }
        private void HandleGetTripsTableData(HttpListenerContext context)
        {
            List<Trip> dataTable = new List<Trip>();
            ServerMessage serverMessage = new ServerMessage(dataTable);
            serverMessage.body = GetTrips();
            Console.WriteLine("Sending trips table data to client");

          //  GetTripsTableData tableData = new GetTripsTableData(dataTable);
           // string response = JsonConvert.SerializeObject(tableData);
            HttpListenerResponse response = context.Response;
            var writer = new StreamWriter(response.OutputStream);
           
            string json = JsonConvert.SerializeObject(serverMessage);
            writer.Write(json);
            //  Console.WriteLine(json);
            writer.Flush();
            writer.Close();
        }
        private void HandleGetTripsFromSearch(HttpListenerContext context, Search info)
        {
            string dataTable = GetSearchResultsTable(info.location, info.time_start, info.time_end);
            ServerMessage serverMessage = new ServerMessage(dataTable);
            serverMessage.body = dataTable;
            HttpListenerResponse response = context.Response;
            var writer = new StreamWriter(response.OutputStream);

            string json = JsonConvert.SerializeObject(serverMessage);
            writer.Write(json);
            writer.Flush();
            writer.Close();

        }


        public string GetSearchResultsTable(string location, int dep_start, int dep_end)
        {

            SqlConnection connection;
            connection = new SqlConnection(CurrentAppData.connectionString);
            string commandString = "select id, location, departure_time, price, available_seats from Trip where location=@Location and departure_time>=@Start_time and departure_time<=@End_time";
            SqlCommand command = new SqlCommand(commandString, connection);
            command.Parameters.AddWithValue("location", location);
            command.Parameters.AddWithValue("start_time", dep_start);
            command.Parameters.AddWithValue("end_time", dep_end);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            command.Dispose();
            connection.Close();
            string json = JsonConvert.SerializeObject(dataTable);
            return json;
        }
        public string GetTrips()
        {
            SqlConnection connection = new SqlConnection(CurrentAppData.connectionString);

           string commandString = "select t.id, a.agency_name as id_agency, c.company_name as id_company, t.location, t.departure_time, t.price, t.available_seats from Trip t inner join Agency a on t.id_agency = a.id inner join TCompany c on t.id_company = c.id_company";
            
            
         /*   string commandString = "select t.id, (select agency_name from Agency where id=t.id_agency) as id_agency," +
                "(select company_name from TCompany where id_company=t.id_company) as id_company, t.location, t.departure_time, t.price, t.available_seats from Trip t";
           
            */
            
            //    string commandString = "select t.id, a.agency_name as id_agency, c.company_name as id_company, t.location, t.departure_time, t.price, t.available_seats from Trip t  join Agency a on t.id_agency = a.id  join TCompany c on t.id = c.id_company";
           //  string commandString = "select t.id, a.agency_name, c.company_name, t.location, t.departure_time, t.price, t.available_seats from Trip t inner join Agency a on t.id_agency = a.id inner join TCompany c on t.id = c.id_company";
           // string commandString = "select * from Trip";
           
            SqlCommand command = new SqlCommand(commandString, connection);
           //  command.Parameters.AddWithValue("id",)


            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
           // List<Trip> trips = new List<Trip>();
            adapter.Fill(dataTable);
            Console.WriteLine(dataTable.Rows.Count);

            var json = JsonConvert.SerializeObject(dataTable);
           // var model = JsonConvert.DeserializeObject<List<Trip>>(json);
            command.Dispose();
            connection.Close();
            return json;
        }


        /* public DataTable GetReservationInfoTable(string id, string name, string pn)
         {
             SqlConnection connection = new SqlConnection(CurrentAppData.connectionString);
             string commandString = "select id, available_seats from Trip where id =@Id";
             SqlCommand command = new SqlCommand(commandString, connection);
             command.Parameters.AddWithValue("id", id);

             SqlDataAdapter adapter = new SqlDataAdapter(command);
             DataTable dataTable = new DataTable();
             adapter.Fill(dataTable);
             connection.Open();
             command.ExecuteNonQuery();
             command.Dispose();
             connection.Close();

             return dataTable;
         }*/

        
        public bool ValidateLogin(string username, string password)
        {
            SqlConnection connection;
            connection = new SqlConnection(CurrentAppData.connectionString);
            SqlCommand command = new SqlCommand("select * from Employee where login_user=@UserName and login_pswd=@Password", connection);
            command.Parameters.AddWithValue("username", username);
            command.Parameters.AddWithValue("password", password);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            return dataTable.Rows.Count > 0;
        }


        public DataTable GetTrip(string id)
        {
            SqlConnection cnn = new SqlConnection(CurrentAppData.connectionString);
            string query = "select id, available_seats from Trip where id =@Id";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("id", id);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        // TODO: Implement the rest of the methods
        /*
        public bool validate_login(string login_user, string login_pswd)
        {
            return employee_repository.user_validation(login_user, login_pswd);
        }

        public bool confirm_reservation(Reservation ag)
        {
            if (trip_repository.ticketsPerTripId(ag.getTripId()) >= ag.getNoTickets())
            {
                return true;
            }
            return false;
        }

        public void add_reservation(string id, string id_trip, string name,
                                string phone_number, int no_tickets)
        {
            Reservation ag = new Reservation(id, id_trip, name, phone_number, no_tickets);
            if (confirm_reservation(ag) == true)
            {
                reservation_repository.add(ag);
                int initial = trip_repository.ticketsPerTripId(ag.getTripId());
                int reserved = ag.getNoTickets();
                trip_repository.update(id, (initial - reserved));

            }
            else Console.WriteLine("Not enough available tickets");
            // adaug bordura rosie pt ui table
        }
        public List<Trip> get_trip_list()
        {
            return (List<Trip>)trip_repository.findAll();
        }

        public List<Trip> get_trip_location_depTime(string location, int min, int max)
        {
            return trip_repository.find_by_location_time(location, min, max);
        }
        */
    }
}
