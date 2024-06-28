using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.domain
{
    [System.Serializable]
    public class ChatMessage
    {
        public string message;
        public string sender;
       
        public ChatMessage(string message,string sender)
        {
            this.message = message;
            this.sender = sender;
        }
        public ChatMessage()
        {
            this.message = null;
            this.sender = null;
        }
    }
}
