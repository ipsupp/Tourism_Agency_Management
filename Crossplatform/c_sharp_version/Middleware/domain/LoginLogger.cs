using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.domain
{
    [System.Serializable]
    public class LoginLogger
    {
        public string onlineUser;
      public LoginLogger() 
     { 
            this.onlineUser = null;
     }
     public LoginLogger(string onlineUser)
        {
            this.onlineUser=onlineUser;
        }
    }
}
