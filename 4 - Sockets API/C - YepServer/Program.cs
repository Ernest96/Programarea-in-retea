using System.Net;
using System.Net.Sockets;
using YepServerExample;

IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
YepServer yepServer = new YepServer();

Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
serverSocket.Bind(new IPEndPoint(ipAddress, 7070));

serverSocket.Listen(5);

Socket client = serverSocket.Accept();

Console.WriteLine("Client Accepted");

yepServer.Start(client);