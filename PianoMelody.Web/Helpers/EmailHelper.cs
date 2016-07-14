namespace PianoMelody.Web.Helpers
{
    using System.Net;
    using System.Net.Mail;

    // TODO: Get existing email and password
    public class EmailHelper
    {
        private readonly string host = "smtp.abv.bg";

        private readonly int port = 587; // 465, 587;

        private readonly bool ssl = true;

        private readonly string user = "melodia.ltd@abv.bg";

        private readonly string pass = "123456";

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
                    message.Subject = this.Subject;
                    message.Body = this.Body;
                    message.IsBodyHtml = true;
                    smtp.Send(message);
                }
            }
        }
    }
}