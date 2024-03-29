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

        public async Task CreateInvoiceAsync(CreateInvoiceViewModel model, Guid paymentId, string userId)
        {
            var invoice = new Invoice
            {
                InvoiceNumber = GetNextInvoiceNumber().ToString(),
                MOL = model.MOL,
                UIN = model.UIN,
                VATIN = model.VATIN,
                Recipient = model.Recipient,
                Compiler = model.Compiler,
                PaymentId = paymentId,
                CreatedOn = DateTime.Now,
                UserId = Guid.Parse(userId)
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

        public Task DeleteInvoiceAsync(Guid id)
        {
            var invoice = _context.Invoices.FirstOrDefault(i => i.Id == id);
            _context.Invoices.Remove(invoice);
            return _context.SaveChangesAsync();
        }

        public async Task<ICollection<AllInvoiceViewModel>> GetAllInvoicesAsync(FilteredInvoiceViewModel model)
        {
            var allInvoicesQueryable =  _context.Invoices
                .Include(i => i.Payment)
                .ThenInclude(p => p.Client)
                .OrderByDescending(i => i.CreatedOn)
                .AsQueryable();

            if (!string.IsNullOrEmpty(model.Filter))
            {
                allInvoicesQueryable = allInvoicesQueryable.Where(
                    i => i.Payment.Client.FullName.ToUpper().Contains(model.Filter.ToUpper()) ||
                    i.UIN.ToUpper().Contains(model.Filter.ToUpper()) ||
                    i.VATIN.ToUpper().Contains(model.Filter.ToUpper()) ||
                    i.Recipient.ToUpper().Contains(model.Filter.ToUpper()) ||
                    i.Compiler.ToUpper().Contains(model.Filter.ToUpper()) ||
                    i.MOL.ToUpper().Contains(model.Filter.ToUpper()) ||
                    i.InvoiceNumber.ToUpper().Contains(model.Filter.ToUpper()));
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

            allInvoicesQueryable = allInvoicesQueryable.Skip((model.CurrentPage - 1) * 2).Take(2);
            model.InvoicesCount = allInvoicesQueryable.Count();
            model.Invoices = await allInvoicesQueryable.Select(i => new AllInvoiceViewModel
            {
                Id = i.Id,
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
            }).ToListAsync();
            return model.Invoices;
        }

        public async Task<Invoice> GetInvoiceByPaymentIdAsync(Guid id)
        {
            var invoice = await _context.Invoices
                .Include(i => i.Payment)
                .ThenInclude(p => p.Client)
                .FirstOrDefaultAsync(i => i.PaymentId == id);

            return  invoice;
        }

        public async Task<AllInvoiceViewModel> GetInvoiceForPrintAsync(Guid id)
        {
            var invoice = await _context.Invoices
                .Include(i => i.Payment)
                .ThenInclude(p => p.Client)
                .FirstOrDefaultAsync(i => i.Id == id);
            return new AllInvoiceViewModel
            {
                Id = invoice.Id,
                InvoiceNumber = invoice.InvoiceNumber,
                MOL = invoice.MOL,
                UIN = invoice.UIN,
                VATIN = invoice.VATIN,
                Recipient = invoice.Recipient,
                Issuer = invoice.Compiler,
                CreatedOn = invoice.CreatedOn,
                ClientFullName = invoice.Payment.Client.FullName,
                ClientAddress = invoice.Payment.Client.Address,
                Payment = invoice.Payment,
                BankTransfer = invoice.BankTransfer,
                Cash = invoice.Cash
            };

        }

        public int GetNextInvoiceNumber()
        {
            return _context.Invoices.Count() + 49;
        }
    }
}
