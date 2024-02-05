using System;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;

class Program
{   
    static void Main(string[] args)
    {
        using (var client = new ImapClient())
        {

            client.Connect("imap.example.com", 993, true);
            client.Authenticate("username", "password");

            var inbox = client.Inbox;

            inbox.Open(FolderAccess.ReadOnly);


            var uids = inbox.Search(SearchQuery.All);

            foreach (var uid in uids)
            {
                var message = inbox.GetMessage(uid);

                Console.WriteLine("Subject:{0}", message.Subject);
                Console.WriteLine("From: {0}", message.From);
                Console.WriteLine("Body: {0}", message.TextBody);

                if (message.Attachments.Count() > 0)
                {
                    foreach (var attachment in message.Attachments)
                    {

                        var fileName = attachment.ContentDisposition?.FileName;
                        using (var stream = File.Create(fileName))
                        {
                            if (attachment is MimePart)
                            {
                                var mimePart = (MimePart)attachment;
                                mimePart.Content.DecodeTo(stream);
                            }
                        }
                        Console.WriteLine("Attachment saved: {0}", fileName);
                    }
                }
                Console.WriteLine("----------------------------");
            }

            client.Disconnect(true);
        }
    }

}