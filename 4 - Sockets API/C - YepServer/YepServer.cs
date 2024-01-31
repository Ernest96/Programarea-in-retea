using System.Net.Sockets;
using System.Text;

namespace YepServerExample
{
    class YepServer
    {
        public void Start(Socket client)
        {
            try
            {
                string inputLine;
                do
                {

                    byte[] buffer = new byte[1024];
                    int bytesReceived = client.Receive(buffer);

                    buffer = buffer.Take(bytesReceived).ToArray();

                    inputLine = System.Text.Encoding.Default.GetString(buffer);

                    Console.WriteLine("Message: " + inputLine);

                    string echo = this.ProcessInput(inputLine);

                    byte[] data = Encoding.UTF8.GetBytes(echo);

                    client.Send(data);

                    Console.WriteLine("Echo sent: " + echo);

                } while (inputLine != "stop");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        private string ProcessInput(string message)
        {
            string replyText = "nak";

            if (!string.IsNullOrEmpty(message))
            {
                string msgTag = message.Substring(0, 3);
                string msgText = message.Substring(4);
                replyText += ":" + msgText;

                if (msgTag == "msg" &&
                    (message[3] == ':') &&
                    (msgText.Length <= IYepProtocol.VALID_MSG_LENGTH))
                {
                    replyText = "ack" + ":" + msgText;
                }
            }

            return replyText;
        }

    }
}
