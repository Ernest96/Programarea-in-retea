using MailKit.Net.Pop3;
using MimeKit;
using System;

// Programul dat necesita instalarea Mail Kit din Nuget Packages

class Program
{
    static void Main()
    {
        Console.WriteLine("Client simplu - citire mesaj");

        try
        {
            using (var client = new Pop3Client())
            {
                // ATENTIE LA UTILIZAREA CREDENTIALELOR
                client.Connect("127.0.0.1", 110, false);

                client.Authenticate("aa", "aa");

                int messageCount = client.Count;

                Console.WriteLine($"Mesaje: {messageCount}");

                if (messageCount > 0)
                {
                    Console.WriteLine("Primul mesaj:");

                    var message = client.GetMessage(0);

                    Console.WriteLine($"From: {message.From}");
                    Console.WriteLine($"Subject: {message.Subject}");
                    Console.WriteLine($"Date: {message.Date}");
                    Console.WriteLine("Body:");
                    Console.WriteLine(message.TextBody);

                    foreach (var attachment in message.Attachments)
                    {
                        Console.WriteLine($"Attachment: {attachment.ContentId}");

                        attachment.WriteTo("C:\\cale\\" + attachment.ContentId);
                    }
                }
                client.Disconnect(true);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
