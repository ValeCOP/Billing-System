namespace Billing_System.Core.ViewModels.Clients
{
    public class ClientsInfoModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public DateTime ActivationDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

    }
}