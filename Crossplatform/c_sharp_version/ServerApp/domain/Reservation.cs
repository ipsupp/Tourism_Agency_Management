using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.domain
{
    public class Reservation
    {
        private string id;
        private string id_trip;
        public string name;
        public string phone_number;
        public int no_tickets;

        public Reservation(string reservation_id, string trip,
                           string last_name, string phone_number,
                           int no_tickets)
        {
            this.id = reservation_id;
            this.id_trip = trip;
            this.name = last_name;
            this.phone_number = phone_number;
            this.no_tickets = no_tickets;
        }


        public string getReservation_id()
        {
            return id;
        }

        public string getTripId()
        {
            return id_trip;
        }

        public void setTripId(string id)
        {
            this.id_trip = id;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string last_name)
        {
            this.name = last_name;
        }

        public string getPhoneNumber()
        {
            return phone_number;
        }

        public void setPhoneNumber(string phone_number)
        {
            this.phone_number = phone_number;
        }

        public int getNoTickets()
        {
            return no_tickets;
        }

        public void setNoTickets(int no_tickets)
        {
            this.no_tickets = no_tickets;
        }

        public override string ToString()
        {
            return id + " " + id_trip + " " + name + " " + phone_number+
                   " " + no_tickets + '\n';
        }


    }
}
