namespace Billing_System.Core.Contracts.Invoice
{
    using Billing_System.Core.ViewModels.Invoice;
    using System.Threading.Tasks;
    using Billing_System.Data.Entities;
    using System.Collections.Generic;

    public interface IInvoiceService
    {
        Task CreateInvoiceAsync(CreateInvoiceViewModel model, Guid paymentId, string userId);
        Task DeleteInvoiceAsync(Guid id);
        Task<ICollection<AllInvoiceViewModel>> GetAllInvoicesAsync(FilteredInvoiceViewModel model);
        Task<Invoice> GetInvoiceByPaymentIdAsync(Guid id);
        Task<AllInvoiceViewModel> GetInvoiceForPrintAsync(Guid id);
        int GetNextInvoiceNumber();
    }
}
