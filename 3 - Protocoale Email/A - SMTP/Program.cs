using MimeKit;
using MailKit.Net.Smtp;

// Programul dat necesita MailKit
class Program
{
    static void Main()
    {
        Console.WriteLine("Client simplu de posta electronica");

        try
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Expeditor", "bb@mail.com"));
            message.To.Add(new MailboxAddress("Destinatar", "aa@mail.com"));
            message.Subject = "Mesaj de test";

            message.Body = new TextPart("plain")
            {
                Text = "Este un mesaj de test"
            };

            using (var client = new SmtpClient())
            {
                // Atentie la utilizarea credentialelor
                client.Connect("127.0.0.1", 25, false);

                client.Authenticate("Utilizator", "Parola");

                client.Send(message);
                client.Disconnect(true);
            }

            Console.WriteLine("Mesaj trimis cu succes.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}