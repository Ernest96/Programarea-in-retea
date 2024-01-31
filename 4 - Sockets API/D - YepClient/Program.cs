using System.Net.Sockets;
using System.Net;
using System.Text;

var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
var serverEndPoint = new IPEndPoint(ipAddress, 7070);

socket.Connect(serverEndPoint);

while (true)
{
    Console.WriteLine("Introdu textul: ");
    string text = Console.ReadLine();

    byte[] bytesData = Encoding.UTF8.GetBytes(text);
    socket.Send(bytesData);
    byte[] buffer = new byte[1024];


    int bytesReceived = socket.Receive(buffer);


    string inputLine = System.Text.Encoding.Default.GetString(buffer);

    Console.WriteLine(inputLine + "a venit");
}