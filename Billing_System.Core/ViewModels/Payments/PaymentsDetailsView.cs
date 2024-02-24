namespace Billing_System.Core.ViewModels.Payments
{
    public class PaymentsDetailsView  
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Value { get; set; }
        public decimal InstallationFee { get; set; }
        public bool Pending { get; set; }
        public bool Receipt { get; set; }
        public string FromDate { get; set; } = null!;
        public string ToDate { get; set; } = null!;
        public Guid ClientId { get; set; }
        public string ApplicationUser { get; set; } = null!;
    }
}
