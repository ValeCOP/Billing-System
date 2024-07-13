namespace Billing_System.Core.Contracts.MailSender
{
    public interface ISendMail
    {
        public void SendEmail(string subject,string body, string clientName, string mailTo);
    }
}
