namespace Billing_System.Core.Services.Invoice
{
    using Billing_System.Core.Contracts.Invoice;
    using Billing_System.Core.ViewModels.Invoice;
    using Billing_System.Data;
    using System.Threading.Tasks;
    using Billing_System.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

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
                InvoiceNumber = GetNextInvoiceNumber(),
                MOL = model.MOL,
                UIN = model.UIN,
                VATIN = model.VATIN,
                Recipient = model.Recipient,
                Compiler = model.Compiler,
                PaymentId = paymentId,
                CreatedOn = DateTime.Now
            };
            if (model.BankTransfer)
            {
                invoice.BankTransfer = true;
            }
            else
            {
                invoice.Cash = true;
            }
            await _context.Invoices.AddAsync(invoice);
            await _context.SaveChangesAsync();
        }

        public Task<ICollection<AllInvoiceViewModel>> GetAllInvoicesAsync(FilteredInvoiceViewModel model)
        {
            var allInvoicesQueryable = _context.Invoices
                .Include(i => i.Payment)
                .ThenInclude(p => p.Client)
                .AsQueryable();

            if (!string.IsNullOrEmpty(model.Filter))
            {
                allInvoicesQueryable = allInvoicesQueryable.Where(i => i.MOL.Contains(model.Filter) || i.UIN.Contains(model.Filter) || i.VATIN.Contains(model.Filter) || i.Recipient.Contains(model.Filter) || i.Compiler.Contains(model.Filter));
            }
            if (!string.IsNullOrEmpty(model.OrderBy))
            {
                allInvoicesQueryable = model.OrderBy switch
                {
                    
                    "CreatedOn" => allInvoicesQueryable.OrderBy(i => i.CreatedOn),
                    "CreatedOnDesc" => allInvoicesQueryable.OrderByDescending(i => i.CreatedOn),
                    _ => allInvoicesQueryable.OrderByDescending(i => i.CreatedOn)
                };
            }

            model.InvoicesCount = allInvoicesQueryable.Count();
            allInvoicesQueryable = allInvoicesQueryable.Skip((model.CurrentPage - 1) * 2).Take(2);
            model.Invoices = allInvoicesQueryable.Select(i => new AllInvoiceViewModel
            {
                InvoiceNumber = i.InvoiceNumber,
                MOL = i.MOL,
                UIN = i.UIN,
                VATIN = i.VATIN,
                Recipient = i.Recipient,
                Issuer = i.Compiler,
                CreatedOn = i.CreatedOn,
                ClientFullName = i.Payment.Client.FullName,
                ClientAddress = i.Payment.Client.Address,
                Payment = i.Payment,
                BankTransfer = i.BankTransfer,
                Cash = i.Cash
            }).ToList();
            return Task.FromResult(model.Invoices);
        }

        public async Task<Invoice> GetInvoiceAsync(Guid id)
        {
            var invoice = await _context.Invoices
                .Include(i => i.Payment)
                .ThenInclude(p => p.Client)
                .FirstOrDefaultAsync(i => i.PaymentId == id);

            return  invoice;
        }

        public int GetNextInvoiceNumber()
        {
            return _context.Invoices.Count() + 49;
        }
    }
}
