using Middleware.domain;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.repository
{
    public class TCompanyRepository : IRepositoryTCompany
    {
        protected SqlConnection conn;

        public TCompanyRepository(SqlConnection conn)
        {
            this.conn = conn;
        }

        public void add(TCompany elem)
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";
            sql = "insert into TCompany(id,company_name) values (" + elem.getCompany_id() + "," + elem.getCompany_name() + ")";
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
            sql = "Delete from TCompany where id = " + id;
            command = new SqlCommand(sql, conn);
            adapter.DeleteCommand = new SqlCommand(sql, conn);
            adapter.DeleteCommand.ExecuteNonQuery();
            command.Dispose();
        }

        public IEnumerable<TCompany> findAll()
        {
            SqlCommand command;
            SqlDataReader reader;
            string sql = "";
            sql = "Select * from TCompany";
            command = new SqlCommand(sql, conn);
            reader = command.ExecuteReader();
            List<TCompany> comps = new List<TCompany>();
            while (reader.Read())
            {
                TCompany comp = new TCompany((string)reader.GetValue(0), (string)reader.GetValue(1));
                comps.Add(comp);
            }

            command.Dispose();
            return comps;
        }


        public void update(string id, int x)
        {
            //n-am nevoie :>
            throw new NotImplementedException();
        }
    }
}
