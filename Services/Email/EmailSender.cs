using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
 
namespace Dent.Services.Email
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse("ya.castortroy2014@yandex.ru"));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = "Сообщение от Dent";
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = htmlMessage
            };

            using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.ServerCertificateValidationCallback = (mysender, certificate, chain, sslPolicyErrors) => { return true; };
                client.CheckCertificateRevocation = false;

                await client.ConnectAsync("smtp.yandex.ru", 465, true).ConfigureAwait(false);
                await client.AuthenticateAsync("ya.castortroy2014@yandex.ru", "sbybvplcclrgcznm").ConfigureAwait(false);
                await client.SendAsync(message).ConfigureAwait(false);

                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }

    }
}
