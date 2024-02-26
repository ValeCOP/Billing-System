namespace Billing_System.Core.ViewModels.Clients
{
    public class ClientsFromISPModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public DateTime ActivationDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

    }
}
