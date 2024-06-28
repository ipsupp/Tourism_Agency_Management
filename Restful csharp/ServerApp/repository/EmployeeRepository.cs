using Middleware.domain;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.repository
{
    public class EmployeeRepository : IRepositoryEmployee
    {
        protected SqlConnection conn;

        public EmployeeRepository(SqlConnection conn)
        {
            this.conn = conn;
        }

        public void add(Employee elem)
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";
            sql = "insert into Employee(id,id_agency,login_user,login_pswd) values ("+ elem.getEmployeeId() + "," + elem.getAgencyId() + ","+ elem.getLoginUser() + ","+ elem.getLoginPswd()+ ")";
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
            sql = "Delete from Employee where id = " + id;
            command = new SqlCommand(sql, conn);
            adapter.DeleteCommand = new SqlCommand(sql, conn);
            adapter.DeleteCommand.ExecuteNonQuery();
            command.Dispose();
        }

        public IEnumerable<Employee> findAll()
        {
            SqlCommand command;
            SqlDataReader reader;
            string sql = "";
            sql = "Select * from Employee";
            command = new SqlCommand(sql, conn);
            reader = command.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (reader.Read())
            {
                Employee ag = new Employee((string)reader.GetValue(0), (string)reader.GetValue(1),(string)reader.GetValue(2),(string)reader.GetValue(3));
                employees.Add(ag);
            }

            command.Dispose();
            return employees;
        }

        public void update(string id, int x)
        {
           //nu imi trebuie :(
            throw new NotImplementedException();
        }

        public bool user_validation(string login_user, string login_pswd)
        {
            SqlCommand command;
            SqlDataReader reader;
            string sql = "";
            sql = "Select * from Employee where login_user= " + login_user;
            command = new SqlCommand(sql, conn);
            reader = command.ExecuteReader();
            while (reader.Read()) {
               if ((string)reader.GetValue(3) == login_pswd)
                    return true;
            }
            command.Dispose();
            return false;
        }
    }
}
