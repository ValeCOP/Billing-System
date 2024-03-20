namespace Billing_System.Core.Contracts.Invoice
{
    using Billing_System.Core.ViewModels.Invoice;
    using System.Threading.Tasks;
    using Billing_System.Data.Entities;
    using System.Collections.Generic;

    public interface IInvoiceService
    {
        Task CreateInvoiceAsync(CreateInvoiceViewModel model, Guid paymentId);
        Task<ICollection<AllInvoiceViewModel>> GetAllInvoicesAsync(FilteredInvoiceViewModel model);
        Task<Invoice> GetInvoiceAsync(Guid id);
        int GetNextInvoiceNumber();
    }
}
