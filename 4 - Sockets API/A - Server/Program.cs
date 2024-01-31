using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

ServerSocket serverSocket = new ServerSocket();
serverSocket.StartSocket();

Console.ReadLine();

class ServerSocket
{
    private Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    IPAddress ipAddress = IPAddress.Parse("127.0.0.1");


    public void StartSocket()
    {
        serverSocket.Bind(new IPEndPoint(ipAddress, 9000));

        serverSocket.Listen(5);

        bool isStopped = false;

        while (!isStopped)
        {

            Socket connection = serverSocket.Accept();
            Console.WriteLine("Connection accepted");

            Thread thread = new Thread(() => readFromConnection(connection));

            thread.Start();
        }
    }

    private void readFromConnection(Socket connection)
    {
        while (true)
        {
            byte[] buffer = new byte[1024];

            int bytesReceived = connection.Receive(buffer);
            string receivedText = Encoding.UTF8.GetString(buffer, 0, bytesReceived);

            Console.WriteLine(receivedText);
        }

    }
}