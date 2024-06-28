using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.domain
{
    public class Employee
    {
        private string id;
        private string id_agency;
        private string login_user;
        private string login_pswd;

        public Employee(string id, string id_agency, string user, string pswd)
        {
            this.id = id;
            this.id_agency = id_agency;
            this.login_user = user;
            this.login_pswd = pswd;
        }

        public string getEmployeeId()
        {
            return id;
        }
        public void setEmployeeId(string id)
        {
            this.id = id;
        }

        public string getAgencyId()
        {
            return id_agency;
        }
        public void setAgencyId(string id)
        {
            this.id_agency = id;
        }

        public string getLoginUser()
        {
            return login_user;
        }
        public void setLoginUser(string user)
        {
            this.login_user = user;
        }

        public string getLoginPswd()
        {
            return this.login_pswd;
        }

        public void setLoginPswd(string pswd)
        {
            this.login_pswd = pswd;
        }

        public override string ToString()
        {
            return id + " "  +id_agency+ " " + login_user + '\n';
        }
    }
}
