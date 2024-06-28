using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.domain
{
    public class Agency
    {
        protected string id;
        protected string agency_name;


        public Agency(string id, string agency_name)
        {
            this.id = id;
            this.agency_name = agency_name;
        }

        public string getAgencyId()
        {
            return id;
        }

        public void setAgencyId(string id)
        {
            this.id = id;
        }

        public string getAgencyName()
        {
            return agency_name;
        }

        public void setAgencyName(string name)
        {
            this.agency_name = name;
        }

        public override string ToString()
        {
            return id + " " + agency_name + '\n';
        }
    }
    }
