namespace Billing_System.Core.MailSender
{
    using System.Net.Mail;
    using System.Net;
    using Microsoft.Extensions.Configuration;
    using Billing_System.Core.Contracts.MailSender;

    public class SendMail : ISendMail
    {
        private readonly IConfiguration _configuration;

        public SendMail(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(string subject,string body, string clientName, string mailTo)
        {
            var smtpServer = _configuration["EmailSettings:SmtpServer"];
            var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);
            var smtpUsername = _configuration["EmailSettings:SmtpUsername"];
            var smtpPassword = _configuration["EmailSettings:SmtpPassword"];

            MailAddress from = new("office@infocastsystems.eu");

            MailMessage email = new();
            email.From = from;
            email.To.Add(mailTo);
            email.Subject = subject;
            email.Body = $"Client: {clientName} {Environment.NewLine}Description: {body}";

            SmtpClient smtp = new();
            smtp.Host = smtpServer;
            smtp.Port = smtpPort;
            smtp.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            smtp.Send(email);
        }
    }
}
