using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.domain
{
    [System.Serializable]
    public class ChatLogs
    {
        public List<ChatMessage> chatMessages = new List<ChatMessage>();
        public ChatLogs() 
        {

        }
        public ChatLogs(List<ChatMessage> messages)
        {
            this.chatMessages = messages;
        }
        public void addLog(ChatMessage message)
        {
            chatMessages.Add(message);
        }
        
    }
}
