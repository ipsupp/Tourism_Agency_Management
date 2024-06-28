using Middleware.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.repository
{
    public interface IRepositoryTrip : IRepository<string, Trip>
    {
         List<Trip> find_by_location_time(string location, int min, int max);
         int ticketsPerTripId(string id);
        // void updateTicketsTripId(int new_nr_tickets, string id);

    }
}
