using System.Net;
using System.Net.Sockets;
using System.Text;

ClientSocket clientSocket = new ClientSocket();

while (true)
{
    clientSocket.Send();
}

class ClientSocket
{
    Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    IPAddress serverIp = IPAddress.Parse("127.0.0.1");
    int serverPort = 9000;
    public ClientSocket()
    {
        client.Connect(new IPEndPoint(serverIp, serverPort));
        Console.WriteLine("Connected to the server");
    }
    public void Send()
    {
        Console.WriteLine("Enter some text to send to server: ");
        string text = Console.ReadLine() ?? "";

        byte[] bytesData = Encoding.UTF8.GetBytes(text);

        client.Send(bytesData);
    }

}