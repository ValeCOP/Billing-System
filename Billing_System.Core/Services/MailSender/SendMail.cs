namespace Billing_System.Utilities.MailSender
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
        public void SendEmail(string subject,string body, string description)
        {
            var smtpServer = _configuration["EmailSettings:SmtpServer"];
            var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);
            var smtpUsername = _configuration["EmailSettings:SmtpUsername"];
            var smtpPassword = _configuration["EmailSettings:SmtpPassword"];

            MailAddress from = new("office@infocastsystems.eu");

            MailMessage email = new();
            email.From = from;
            email.To.Add("359888719126@sms.mtel.net,adminraiovo@gmail.com,359883339303@sms.mtel.net");
            email.Subject = subject;
            email.Body = $"Text: {description} {Environment.NewLine}Description: {body}";

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
