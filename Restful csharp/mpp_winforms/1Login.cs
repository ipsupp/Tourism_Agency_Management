using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net.Sockets;
using System.Net;
using Middleware.domain;
using Newtonsoft.Json;

namespace mpp_winforms
{
    public partial class Login : Form
    {
        private bool once = false;
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_load(object sender, EventArgs e)
        {

        }


        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPswd_TextChanged(object sender, EventArgs e)
        {
            if (!once)
            {
                once = true;
                txtPswd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnterKeyPress);
            }
        }

        private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return && txtPswd.Text != "")
            {
                EventArgs e2 = new EventArgs(); 
                Proceed_Click(sender, e2);
            }
        }

        /* 
            string username=txtUser.Text;
            string password = txtPswd.Text;
            Console.WriteLine(username + " " + password);      
            string connectionString;
            SqlConnection cnn;
            string sql = "select * from Employee where login_user="+ username +" and login_pswd="+ password;
            connectionString = @"Data Source=JUBILLEE\SQLEXPRESS01;Initial Catalog=mpp; Trusted_Connection=True;MultipleActiveResultSets=true";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            MessageBox.Show("connection established.");
            SqlCommand cmd = new SqlCommand(sql,cnn);
            SqlDataReader dataReader;
            try
            {
                dataReader = cmd.ExecuteReader();
                if(dataReader.Read())
                {
                    MessageBox.Show("Successfully loged in");
                    //after successful it will redirect  to next page .  
                    Form2 settingsForm = new Form2();
                    settingsForm.Show();
                }
                   else
                {
                    MessageBox.Show("Please enter Correct Username and Password");
                }
                cnn.Close();
                cmd.Dispose();
            }
            catch (SqlException ex) {
                MessageBox.Show("uhoh");
            }
         */

        private bool ValidateLoginFromServer(string username, string password)
        {
            LoginInfo loginInfo = new LoginInfo(username, password);
            ServerMessage serverMessage = new ServerMessage(loginInfo);
            
            string json = JsonConvert.SerializeObject(serverMessage);

            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 8888;

            TcpClient client = new TcpClient();
            client.Connect(ipAddress, port);

            NetworkStream stream = client.GetStream();

            byte[] data = Encoding.ASCII.GetBytes(json);
            stream.Write(data, 0, data.Length);

            data = new byte[256];
            int bytesRead = stream.Read(data, 0, data.Length);

            BoolData boolData = JsonConvert.DeserializeObject<BoolData>(Encoding.ASCII.GetString(data, 0, bytesRead));

            return boolData.status;
        }

        private void Proceed_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPswd.Text;

            bool ok = ValidateLoginFromServer(username, password);

            if (ok)
            {
                MessageBox.Show("Successfully logged in");
                Form2 settingsForm = new Form2();
                settingsForm.user = username;
                settingsForm.Show();
                settingsForm.dataToGridView();
            }
            else
            {
                MessageBox.Show("Please enter Correct Username and Password");
            }

        }
    }
}
