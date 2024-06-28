using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

static void Main()
{
    // Set the IP address and port
    IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
    int port = 8888;

    // Create a TCP/IP socket
    TcpListener server = new TcpListener(ipAddress, port);

    try
    {
        // Start listening for client requests
        server.Start();

        // Display server information
        Console.WriteLine("Server started on {0}:{1}", ipAddress, port);

        while (true)
        {
            Console.WriteLine("Waiting for a connection...");

            // Accept a pending connection request
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Client connected!");

            // Get the network stream
            NetworkStream stream = client.GetStream();

            // Read data from the client
            byte[] data = new byte[256];
            int bytesRead = stream.Read(data, 0, data.Length);
            string message = Encoding.ASCII.GetString(data, 0, bytesRead);
            Console.WriteLine("Received: {0}", message);

            // Send a response back to the client
            string response = "Message received!";
            byte[] responseData = Encoding.ASCII.GetBytes(response);
            stream.Write(responseData, 0, responseData.Length);
            Console.WriteLine("Response sent to client");

            // Close the connection
            client.Close();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: {0}", ex.Message);
    }
    finally
    {
        // Stop listening for new clients
        server.Stop();
    }
}

Main();