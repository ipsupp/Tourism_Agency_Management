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
using System.Collections;
using Middleware.domain;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Net;

namespace mpp_winforms
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewRez(string id)
        {
            dataGridView1.DataSource = GetTripTableFromServer();
        }

        private DataTable GetTripTableFromServer()
        {
            return null;
        }

        private void labelTripId_Click(object sender, EventArgs e)
        {

        }

        private bool TryMakeReservationFromServer(string id, string name, string pn, int tickets)
        {
            ReservationInfo reservationInfo = new ReservationInfo(id,name,pn,tickets);
            ServerMessage serverMessage = new ServerMessage(reservationInfo);

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

            //  GetTripsFromSearch table = JsonConvert.DeserializeObject<GetTripsFromSearch>(Encoding.ASCII.GetString(data, 0, bytesRead));
            BoolData boolData = JsonConvert.DeserializeObject<BoolData>(Encoding.ASCII.GetString(data, 0, bytesRead));

            return boolData.status;
        }

        private DataTable GetReservationInfoTableFromServer(string id,int tickets)
        {
            GetReservationTable blankTable = new GetReservationTable(new DataTable());
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


            GetReservationTable table = JsonConvert.DeserializeObject<GetReservationTable>(Encoding.ASCII.GetString(data, 0, bytesRead));

            return table.dataTable;
        }

        private void attempt_rez_Click(object sender, EventArgs e)
        {
            int tickets = 0;
            string t = ntickBox.Text;
            tickets = Convert.ToInt32(t);

            string id = idTripBox.Text;
            string name = nameBox.Text; 
            string pn = pnBox.Text;
            
       

            bool ok = TryMakeReservationFromServer(id, name, pn, tickets);
            if (!ok)
            {
                MessageBox.Show("Not enough available seats");
                return;
            }
            else
            {
             //   dataGridView1.DataSource = GetReservationInfoTableFromServer(id, tickets);
                MessageBox.Show("Reservation made!");

            }

            this.Close();
         //   Form2.mainForm.dataToGridView();
        }
    }
}
