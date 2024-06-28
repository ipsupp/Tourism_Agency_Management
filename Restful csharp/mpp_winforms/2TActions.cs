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
using Middleware.domain;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net.Sockets;
using System.Net;

namespace mpp_winforms
{
    public partial class Form2 : Form
    {
        public static Form2 mainForm;
        public string user;

        public Form2()
        {
            mainForm = this;
            InitializeComponent();
            dataToGridView();
        }

        public DataTable GetTripsTableFromServer()
        {
            GetTripsTableData blankTable = new GetTripsTableData(new DataTable());
            ServerMessage serverMessage = new ServerMessage(blankTable);

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
            GetTripsTableData table = JsonConvert.DeserializeObject<GetTripsTableData>(Encoding.ASCII.GetString(data, 0, bytesRead));

            return table.dataTable;
        }


        public void dataToGridView()
        {
            DataTable table = GetTripsTableFromServer();
            dataGridView1.DataSource = table;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToInt32(row.Cells[6].Value) == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 settingsForm = new Form3();
            settingsForm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void make_rez_Click(object sender, EventArgs e)
        {
            Form4 settingsForm = new Form4();
            settingsForm.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            dataToGridView();
        }

        private void logout_button_Click(object sender, EventArgs e)
        {
            ServerMessage serverMessage = new ServerMessage(new LoginLogger(user));

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

            this.Close();
        }

        private void serverButton_Click(object sender, EventArgs e)
        {
            _5Server _5Server = new _5Server();
            _5Server.currentUser = user;
            _5Server.form2 = this;
            _5Server.Show();
        }

        private void Form2_Click(object sender, EventArgs e)
        {
            dataToGridView();
        }
    }
}
