using Middleware.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.repository
{
    public interface IRepositoryEmployee : IRepository<string, Employee>
    {
        bool user_validation(string login_user, string login_pswd);
    }
}
