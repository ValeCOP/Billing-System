namespace Billing_System.Core.Contracts.Invoice
{
    using Billing_System.Core.ViewModels.Invoice;
    using System.Threading.Tasks;

    public interface IInvoiceService
    {
        Task CreateInvoiceAsync(CreateInvoiceViewModel model, Guid paymentId);
        int GetNextInvoiceNumber();
    }
}
