using Middleware.domain;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.repository
{
    public class TripRepository : IRepositoryTrip
    {
        protected SqlConnection conn;

        public TripRepository(SqlConnection conn)
        {
            this.conn = conn;
        }

        public void add(Trip elem)
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";
            sql = "insert into Trip values (" + elem.getId() + ","
                + elem.getCompanyId() + "," + elem.getAgencyId() + ",\'" + elem.getLocation() + "\'," + elem.getDepartureTime() + ","
                + elem.getTicketPrice() + "," + elem.getAvailableTickets() + ")";
            command = new SqlCommand(sql, conn);
            adapter.InsertCommand = new SqlCommand(sql, conn);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();

        }

        public void delete(string id)
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";
            sql = "Select * from Trip where id = " + id;
            command = new SqlCommand(sql, conn);
            SqlDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                reader.Close();
                throw new Exception();
            }
            reader.Close();
            command.Dispose();
            sql = "Delete from Trip where id = " + id;
            command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            //adapter.DeleteCommand = new SqlCommand(sql, conn);
            //adapter.DeleteCommand.ExecuteNonQuery();
            command.Dispose();
        }

        public IEnumerable<Trip> findAll()
        {
            SqlCommand command;
            SqlDataReader reader;
            string sql = "";
            sql = "Select * from Trip";
            command = new SqlCommand(sql, conn);
            reader = command.ExecuteReader();
            List<Trip> trips = new List<Trip>();
            while (reader.Read())
            {
                Trip trip = new Trip((string)reader.GetValue(0), (string)reader.GetValue(1), (string)reader.GetValue(2), (string)reader.GetValue(3)
                    , (int)reader.GetValue(4), Convert.ToSingle(reader.GetValue(5)), (int)reader.GetValue(6));
                trips.Add(trip);
            }

            command.Dispose();
            reader.Close();
            return trips;
        }
        public Trip find(string id)
        {
            SqlCommand command;
            SqlDataReader reader;
            string sql = "";
            sql = "Select * from Trip where id=" + id;
            command = new SqlCommand(sql, conn);
            reader = command.ExecuteReader();
            reader.Read();
            Trip trip = new Trip((string)reader.GetValue(0), (string)reader.GetValue(1), (string)reader.GetValue(2), (string)reader.GetValue(3)
                   , (int)reader.GetValue(4), Convert.ToSingle(reader.GetValue(5)), (int)reader.GetValue(6));
            reader.Close();
            return trip;
        }

        public List<Trip> find_by_location_time(string location, int min, int max)
        {
            SqlCommand command;
            SqlDataReader reader;
            string sql = "";
            sql = "Select from Trip where location=" + location + " and departure_time between" + min + "and" + max;
            command = new SqlCommand(sql, conn);
            reader = command.ExecuteReader();
            List<Trip> trips = new List<Trip>();
            while (reader.Read())
            {
                Trip trip = new Trip((string)reader.GetValue(0), (string)reader.GetValue(1), (string)reader.GetValue(2), (string)reader.GetValue(3)
                    , (int)reader.GetValue(4), (float)reader.GetValue(5), (int)reader.GetValue(6));
                trips.Add(trip);
            }
            reader.Close();

            command.Dispose();
            return trips;
        }

        public int ticketsPerTripId(string id)
        {
            SqlCommand command;
            SqlDataReader reader;
            string sql = "";
            sql = "Select from Trip where id=" + id;
            command = new SqlCommand(sql, conn);
            reader = command.ExecuteReader();
            int val = (int)reader.GetValue(6);
            reader.Close();
            return val;
        }

        public void update(string id, int x)
        {
            SqlConnection cnn = new SqlConnection(CurrentAppData.connectionString);
            string query = "update Trip set available_seats=@x WHERE id=@Id";
            cnn.Open();
            SqlCommand updateCmd = new SqlCommand(query, cnn);
            updateCmd.Parameters.AddWithValue("id", id);
            updateCmd.Parameters.AddWithValue("x", x);
            updateCmd.ExecuteNonQuery();
            updateCmd.Dispose();
        }
        /*
        public void updateTicketsTripId(int new_nr_tickets, string id)
        {
            throw new NotImplementedException();
        } */
    }
}
