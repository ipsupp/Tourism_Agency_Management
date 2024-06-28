using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Middleware.domain;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Net;

namespace mpp_winforms
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public DataTable GetTripSearchFromTable(string location, int start, int end)
        {

         //   GetTripsFromSearch blankTable = new GetTripsFromSearch(new DataTable());
            Search info = new Search(location,start,end);
            ServerMessage serverMessage = new ServerMessage(info);

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

            GetTripsFromSearch table = JsonConvert.DeserializeObject<GetTripsFromSearch>(Encoding.ASCII.GetString(data, 0, bytesRead));

            return table.dataTable;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        //asta folosim
        private void dataGridViewLDT(string location, int start_time, int end_time)
        {
            SqlConnection cnn = new SqlConnection(CurrentAppData.connectionString);
            string query = "select id, location, departure_time, price, available_seats from Trip where location =@Location and departure_time >=@Start_time and departure_time <=@End_time";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("location", location);
            cmd.Parameters.AddWithValue("start_time", start_time);
            cmd.Parameters.AddWithValue("end_time", end_time);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cnn.Open();
            cmd.ExecuteNonQuery();
            dataSearchLDT.DataSource = dataTable;
            cmd.Dispose();
            cnn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string location = locationBox.Text;
            string dtstart = tstartBox.Text;
            string dtend = tendBox.Text;
            int start_time = Convert.ToInt32(dtstart);
            int end_time = Convert.ToInt32(dtend);
    //        dataGridViewLDT(location, start_time, end_time);
            DataTable table = GetTripSearchFromTable(location,start_time,end_time);
            dataSearchLDT.DataSource = table;

        }
    }
}
