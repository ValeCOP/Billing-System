namespace Billing_System.Core.Services.Invoice
{
    using Billing_System.Core.Contracts.Invoice;
    using Billing_System.Data;

    public class InvoiceService : IInvoiceService
    {
        private readonly BillingDbContext _context;

        public InvoiceService(BillingDbContext context) 
        {
            _context = context;
        }
        public int GetNextInvoiceNumber()
        {
            return _context.Invoices.Count() + 1;
        }
    }
}
