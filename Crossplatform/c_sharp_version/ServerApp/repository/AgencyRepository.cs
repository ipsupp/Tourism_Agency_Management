using Middleware.domain;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace ServerApp.repository
{
    public class AgencyRepository : IRepositoryAgency
    {
        protected SqlConnection conn;

        public AgencyRepository(SqlConnection conn)
        {
            this.conn = conn;
        }

        public void add(Agency elem)
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";
            sql = "insert into Agency(id,agency_name) values (" + elem.getAgencyId() + "," + elem.getAgencyName() + ")";
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
            sql = "Delete from Agency where id = " + id;
            command = new SqlCommand(sql, conn);
            adapter.DeleteCommand = new SqlCommand(sql, conn);
            adapter.DeleteCommand.ExecuteNonQuery();
            command.Dispose();
        }

        public IEnumerable<Agency> findAll()
        {
            SqlCommand command;
            SqlDataReader reader;
            string sql = "";
            sql = "Select * from Agency";
            command = new SqlCommand(sql, conn);
            reader = command.ExecuteReader();
            List<Agency> agencies = new List<Agency>();
            while (reader.Read())
            {
                Agency ag = new Agency((string)reader.GetValue(0), (string)reader.GetValue(1));
                agencies.Add(ag);
            }

            command.Dispose();
            return agencies;
        }

        public void update(string id, int x)
        {
            //n-am nevoie :)
            throw new NotImplementedException();
        }
    }
}

