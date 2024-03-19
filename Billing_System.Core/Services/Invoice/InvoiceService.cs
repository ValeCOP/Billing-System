namespace Billing_System.Core.Services.Invoice
{
    using Billing_System.Core.Contracts.Invoice;
    using Billing_System.Core.ViewModels.Invoice;
    using Billing_System.Data;
    using System.Threading.Tasks;
    using Billing_System.Data.Entities;
    public class InvoiceService : IInvoiceService
    {
        private readonly BillingDbContext _context;

        public InvoiceService(BillingDbContext context) 
        {
            _context = context;
        }

        public async Task CreateInvoiceAsync(CreateInvoiceViewModel model, Guid paymentId)
        {
            var invoice = new Invoice
            {
                MOL = model.MOL,
                UIN = model.UIN,
                VATIN = model.VATIN,
                Recipient = model.Recipient,
                Compiler = model.Compiler,
                PaymentId = paymentId,
                CreatedOn = DateTime.Now
            };
            await _context.Invoices.AddAsync(invoice);
            await _context.SaveChangesAsync();
        }

        public int GetNextInvoiceNumber()
        {
            return _context.Invoices.Count() + 49;
        }
    }
}
