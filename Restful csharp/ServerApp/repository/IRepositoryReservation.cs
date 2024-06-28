using Middleware.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.repository
{
    public interface IRepositoryReservation : IRepository<string, Reservation>
    {
    }
}
