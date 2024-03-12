namespace Billing_System.Core.ViewModels.Clients
{
    public class ShortInfoForActivatedClients
    {
        public Guid ClientId { get; set; }
        public string FullName { get; set; } = null!;
        public string ActivationDate { get; set; } = null!;
        public string ExpiredDate { get; set; } = null!;
        public  bool Pending { get; set; }
    }
}
