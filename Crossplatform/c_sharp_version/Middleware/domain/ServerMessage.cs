using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Middleware.domain
{
    [System.Serializable]
    public class ServerMessage
    {
        public string type;
        public string body;

        public ServerMessage()
        {
            type = null;
            body = null;
        }

        public ServerMessage(Object o)
        {
            type = "";
           body = Newtonsoft.Json.JsonConvert.SerializeObject(o);
        }
    }
}
