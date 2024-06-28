using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.domain
{
    public class Trip
    {
        public string id;
        public string id_agency;
        public string id_company;
        public string location;
        public int departure_time;
        public float ticket_price;
        public int available_tickets;

        public Trip(string id, string id_agency, string id_company, string location,
                    int departure_time, float ticket_price, int available_tickets)
        {
            this.id = id;
            this.id_agency = id_agency;
            this.id_company = id_company;
            this.location = location;
            this.departure_time = departure_time;
            this.ticket_price = ticket_price;
            this.available_tickets = available_tickets;
        }

        public string getId()
        {
            return id;
        }

        public void setId(string trip_id)
        {
            this.id = trip_id;
        }

        public string getAgencyId()
        {
            return id_agency;
        }

        public void setAgencyId(string id)
        {
            this.id_agency = id;
        }

        public string getCompanyId()
        {
            return id_company;
        }

        public void setCompanyId(string id)
        {
            this.id_company = id;
        }


        public string getLocation()
        {
            return location;
        }

        public void setLocation(string location)
        {
            this.location = location;
        }

        public int getDepartureTime()
        {
            return departure_time;
        }

        public void setDepartureTtime(int departure_time)
        {
            this.departure_time = departure_time;
        }

        public float getTicketPrice()
        {
            return ticket_price;
        }

        public void setTicketPrice(float ticket_price) { 
            this.ticket_price = ticket_price;
        }

        public int getAvailableTickets()
        {
            return available_tickets;
        }

        public void setAvailableTickets(int available_tickets)
        {
            this.available_tickets = available_tickets;
        }

        public override string ToString()
        {
            return id + " " + id_agency + " " + id_company + " " + location+ " " +
                departure_time + " " + ticket_price + " " + available_tickets + '\n';
        }
    }
}
