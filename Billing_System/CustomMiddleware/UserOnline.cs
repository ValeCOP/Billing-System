namespace Billing_System.CustomMiddleware
{
    public class UserOnline
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;
        public DateTime LastSeen { get; set; }
    }
}