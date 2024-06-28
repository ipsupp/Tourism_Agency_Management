using Middleware.domain;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.repository
{
    public class ReservationRepository : IRepositoryReservation
    {
        protected SqlConnection conn;

        public ReservationRepository(SqlConnection conn)
        {
            this.conn = conn;
        }

        public void add(Reservation elem)
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";
            sql = "insert into Reservation(id,id_trip, name, phone_number,no_tickets) values ("
                + elem.getReservation_id() + "," + elem.getTripId() + "," + elem.getName() + "," 
                + elem.getPhoneNumber() + "," + elem.getNoTickets() + ")";
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
            sql = "Delete from Reservation where id = " + id;
            command = new SqlCommand(sql, conn);
            adapter.DeleteCommand = new SqlCommand(sql, conn);
            adapter.DeleteCommand.ExecuteNonQuery();
            command.Dispose();
        }

        public IEnumerable<Reservation> findAll()
        {
            SqlCommand command;
            SqlDataReader reader;
            string sql = "";
            sql = "Select * from Reservation";
            command = new SqlCommand(sql, conn);
            reader = command.ExecuteReader();
            List<Reservation> ress = new List<Reservation>();
            while (reader.Read())
            {
                Reservation rez = new Reservation((string)reader.GetValue(0), (string)reader.GetValue(1),
                    (string)reader.GetValue(2), (string)reader.GetValue(3), (int)reader.GetValue(4));
                ress.Add(rez);
            }

            command.Dispose();
            return ress;
        }


        public void update(string id, int x)
        {
            //nu imi trebuie :|
            throw new NotImplementedException();
        }
    }
}
