using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace EchoServer
{
    class ServerProgram
    {
        static void Main(string[] args)
        {
            IPAddress ipAddress = Dns.GetHostEntry("localhost").AddressList[0];
            TcpListener server = new TcpListener(ipAddress, 8080);
            TcpClient client = new TcpClient();

            server.Start();
            Console.WriteLine("Server started....");

            while (true)
            {
                client = server.AcceptTcpClient();

                byte[] receivedBuffer = new byte[100];
                NetworkStream stream = client.GetStream();

                stream.Read(receivedBuffer, 0, receivedBuffer.Length);

                string msg = Encoding.ASCII.GetString(receivedBuffer, 0, receivedBuffer.Length);

                Console.WriteLine("The client says: " + msg);

            }

        }
    }
}
