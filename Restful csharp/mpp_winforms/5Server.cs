using Middleware.domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace mpp_winforms
{
    public partial class _5Server : Form
    {
        public string currentUser;
        public Form2 form2;
        
        public _5Server()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            sendMessage(enterMessageBox.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void messageBoardTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void onlineFriendsTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void enterMessageBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void logOut2Button_Click(object sender, EventArgs e)
        {
            ServerMessage serverMessage = new ServerMessage(new LoginLogger(currentUser));

            string json = JsonConvert.SerializeObject(serverMessage);

            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 8888;

            TcpClient client = new TcpClient();
            client.Connect(ipAddress, port);

            NetworkStream stream = client.GetStream();

            byte[] data = Encoding.ASCII.GetBytes(json);
            stream.Write(data, 0, data.Length);

            data = new byte[2048];
            int bytesRead = stream.Read(data, 0, data.Length);
            onlineFriendsTable.Items.Clear();
            List<string> onlineFriends = JsonConvert.DeserializeObject<List<string>>(Encoding.ASCII.GetString(data, 0, bytesRead));
            for (int i = 0; i < onlineFriends.Count; i++)
            {
                onlineFriendsTable.Items.Add(onlineFriends[i]);
            }
            this.Close();    
            form2.Close();
        }
        private void sendMessage(string message)
        {
            ChatMessage msg = new ChatMessage(message, currentUser);
            ServerMessage serverMessage = new ServerMessage(msg);

            string json = JsonConvert.SerializeObject(serverMessage);

            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 8888;

            TcpClient client = new TcpClient();
            client.Connect(ipAddress, port);

            NetworkStream stream = client.GetStream();

            byte[] data = Encoding.ASCII.GetBytes(json);
            stream.Write(data, 0, data.Length);

            data = new byte[2048];
            int bytesRead = stream.Read(data, 0, data.Length);

            ChatLogs deserializedMessage = JsonConvert.DeserializeObject<ChatLogs>(Encoding.ASCII.GetString(data, 0, bytesRead));
            userCheck();

            if (deserializedMessage.chatMessages.Count >= messageBoardTable.Items.Count)
            {
                messageBoardTable.Items.Clear();
                for (int i = 0; i < deserializedMessage.chatMessages.Count; i++)
                {
                    messageBoardTable.Items.Add(deserializedMessage.chatMessages[i].sender+": "+deserializedMessage.chatMessages[i].message);
                }
            }

        }

        private void _5Server_Load(object sender, EventArgs e)
        {


        }
        private void userCheck()
        {
            ServerMessage serverMessage = new ServerMessage(new LoginLogger());

            string json = JsonConvert.SerializeObject(serverMessage);

            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 8888;

            TcpClient client = new TcpClient();
            client.Connect(ipAddress, port);

            NetworkStream stream = client.GetStream();

            byte[] data = Encoding.ASCII.GetBytes(json);
            stream.Write(data, 0, data.Length);

            data = new byte[2048];
            int bytesRead = stream.Read(data, 0, data.Length);
            onlineFriendsTable.Items.Clear();
            List<string> onlineFriends = JsonConvert.DeserializeObject<List<string>>(Encoding.ASCII.GetString(data, 0, bytesRead));
            for (int i = 0; i < onlineFriends.Count; i++)
            {
                onlineFriendsTable.Items.Add(onlineFriends[i]);
            }
        }
        private void _5Server_Click(object sender, EventArgs e)
        {
            ServerMessage serverMessage = new ServerMessage(new ChatMessage());

            string json = JsonConvert.SerializeObject(serverMessage);

            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 8888;

            TcpClient client = new TcpClient();
            client.Connect(ipAddress, port);

            NetworkStream stream = client.GetStream();

            byte[] data = Encoding.ASCII.GetBytes(json);
            stream.Write(data, 0, data.Length);

            data = new byte[2048];
            int bytesRead = stream.Read(data, 0, data.Length);

            ChatLogs deserializedMessage = JsonConvert.DeserializeObject<ChatLogs>(Encoding.ASCII.GetString(data, 0, bytesRead));
            userCheck();

            if (deserializedMessage.chatMessages.Count >= messageBoardTable.Items.Count)
            {
                messageBoardTable.Items.Clear();
                for (int i = 0; i < deserializedMessage.chatMessages.Count; i++)
                {
                    messageBoardTable.Items.Add(deserializedMessage.chatMessages[i].sender+": "+deserializedMessage.chatMessages[i].message);
                }
            }
        }

        private void _5Server_FormClosing(object sender, FormClosingEventArgs e)
        {
           ServerMessage serverMessage = new ServerMessage(new LoginLogger(currentUser));
        
           string json = JsonConvert.SerializeObject(serverMessage);
        
           IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
           int port = 8888;
        
           TcpClient client = new TcpClient();
           client.Connect(ipAddress, port);
       
           NetworkStream stream = client.GetStream();
        
           byte[] data = Encoding.ASCII.GetBytes(json);
           stream.Write(data, 0, data.Length);
        
           data = new byte[2048];
           int bytesRead = stream.Read(data, 0, data.Length);
           form2.Close();
        }
    }
}
