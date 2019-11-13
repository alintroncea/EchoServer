using System;
using System.Net.Sockets;
using System.Text;

namespace EchoClient
{
    class ClientProgram
    {
        static void Main(string[] args)
        {
            string serverIP = "localhost";
            int port = 8080;

            TcpClient client = new TcpClient(serverIP, port);

            while (true)
            {
                string msg = Console.ReadLine();

                int byteCount = Encoding.ASCII.GetByteCount(msg);

                byte[] sendData = new byte[byteCount];

                sendData = Encoding.ASCII.GetBytes(msg);

                NetworkStream stream = client.GetStream();

                stream.Write(sendData, 0, sendData.Length);

                stream.Close();
                client.Close();
            }
        }
    }
}
