namespace PianoMelody.Web.Helpers
{
    using System.Configuration;
    using System.Net;
    using System.Net.Mail;

    public class EmailHelper
    {
        private readonly string host = ConfigurationManager.AppSettings["host"];

        private readonly int port = int.Parse(ConfigurationManager.AppSettings["port"]);

        private readonly bool ssl = bool.Parse(ConfigurationManager.AppSettings["ssl"]);

        private readonly string user = ConfigurationManager.AppSettings["user"];

        private readonly string pass = ConfigurationManager.AppSettings["pass"];

        public string Name { get; set; }

        public string Email { get; set; }

        public string Recipient { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public void Send()
        {
            using (var smtp = new SmtpClient())
            {
                smtp.Host = this.host;
                smtp.Port = this.port;
                smtp.EnableSsl = this.ssl;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(this.user, this.pass);

                using (var message = new MailMessage(this.user, this.Recipient))
                {
                    message.From = new MailAddress(this.Email);
                    message.Subject = this.Subject;
                    message.Body = this.Body;
                    message.IsBodyHtml = true;
                    smtp.Send(message);
                }
            }
        }
    }
}