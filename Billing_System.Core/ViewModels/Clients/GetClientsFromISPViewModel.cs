namespace Billing_System.Core.ViewModels.Clients
{
    public class GetClientsFromISPViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string ActivationDate { get; set; } = null!;
        public string ExpiredDate { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
