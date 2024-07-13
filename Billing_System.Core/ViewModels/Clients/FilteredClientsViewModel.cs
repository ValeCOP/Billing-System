namespace Billing_System.Core.ViewModels.Clients
{
    public class FilteredClientsViewModel
    {
        public string? Filter { get; set; }
        public string? OrderBy { get; set; }
        public bool Pending { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int ClientsCount { get; set; }
        public ICollection<ActivatedClientsViewModel> Clients { get; set; } = new List<ActivatedClientsViewModel>();
    }
}
