using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.domain
{
    public class TCompany
    {
        protected string id;
        protected string company_name;

        public TCompany(string company_id, string company_name)
        {
            this.id = company_id;
            this.company_name = company_name;
        }

        public string getCompany_id()
        {
            return id;
        }

        public void setCompany_id(string id)
        {
            this.id = id;
        }

        public string getCompany_name()
        {
            return this.company_name;
        }

        public void setCompany_name(string name)
        {
            this.company_name = name;
        }

        public override string ToString()
        {
            return id + " " +company_name + '\n';
        }
    }
}
