namespace Billing_System.Core.ViewModels.Clients
{
    using Billing_System.Core.ViewModels.Payments;

    public class ActivatedClientsViewModel
    {
        public Guid ClientId { get; set; }

        public string FullName { get; set; } = null!;

        public string ActivationDate { get; set; } = null!;

        public string ExpiredDate { get; set; } = null!;

        public string? Comments { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string ApplicationUser { get; set; } = null!;

        public ICollection<PaymentsDetailsView> Payments { get; set; } = new List<PaymentsDetailsView>();
    }
}
