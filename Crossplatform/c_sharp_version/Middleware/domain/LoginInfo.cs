using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.domain
{
    [System.Serializable]
    public class LoginInfo
    {
        public string username;
        public string password;

        public LoginInfo(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
