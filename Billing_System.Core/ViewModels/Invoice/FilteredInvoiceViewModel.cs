namespace Billing_System.Core.ViewModels.Invoice
{
    using Billing_System.Core.ViewModels.TechnicalProblem;

    public class FilteredInvoiceViewModel
    {
        public string? Filter { get; set; }
        public string? OrderBy { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int InvoicesCount { get; set; }
        public ICollection<AllInvoiceViewModel> Invoices { get; set; } = new List<AllInvoiceViewModel>();
    }
}
