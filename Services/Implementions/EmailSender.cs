using MimeKit;
using System.Threading.Tasks;
using MimeKit.Text;
using Servises.Interfaces;

namespace Servises.Implementions
{
    public class EmailSender : IEmailSender
    {
        public async Task<bool> SendEmailAsync(string email, string message)
        {
            // create email message
            var Email = new MimeMessage();

            Email.From.Add(MailboxAddress.Parse("info@bugland.ir")); // Your Email
            Email.To.Add(MailboxAddress.Parse(email)); // User Email
            Email.Subject = "موضوع";
            Email.Body = new TextPart(TextFormat.Html) { Text = $"<h2> {message}</h2>" };

            // send email
            using var smtp = new MailKit.Net.Smtp.SmtpClient();



            try
            {
                // Enter Your Host and Port. Like: gmail.com - 465
                await smtp.ConnectAsync("bugland.ir", 465);

                // Your Email and Password For Login
                await smtp.AuthenticateAsync("info@bugland.ir", "**********");

                await smtp.SendAsync(Email);
                await smtp.DisconnectAsync(true);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
