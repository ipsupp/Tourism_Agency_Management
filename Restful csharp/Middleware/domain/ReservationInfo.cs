using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.domain
{
    [System.Serializable]
    public class ReservationInfo
    {
        public string id;
        public string name;
        public string phone_number;
        public int number_tickets;

        public ReservationInfo(string id, string name, string phone_number, int number_tickets)
        {
            this.id = id;
            this.name = name;
            this.phone_number = phone_number;
            this.number_tickets = number_tickets;
        }
    }
}
