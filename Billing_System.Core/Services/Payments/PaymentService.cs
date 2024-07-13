namespace Billing_System.Core.Services.Payments
{
    using Billing_System.Core.Contracts.Payments;
    using Billing_System.Core.ViewModels.Payments;
    using Billing_System.Data;
    using Billing_System.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;
    using static Billing_System.Utilities.ValidationConstants.ValidationConstants;

    public class PaymentService : IPaymentsService
    {
        private readonly BillingDbContext _context;
        public PaymentService(BillingDbContext context)
        {
            _context = context;
        }
        public async Task<AddPaymentViewModel> Add(Guid clientId)
        {
            var client = await _context.Clients
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(c => c.Id == clientId);
                ;

            var addPaymentView = new AddPaymentViewModel()
            {
                ClId = clientId,
                Client = client!,
                UserId = client!.ApplicationUser.Id,
            };
            return addPaymentView;
        }
        public async Task<Payment> AddPaymentAsync(AddPaymentViewModel payment, Guid userId)
        {

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var newPayment = new Payment
            {
                Id = Guid.NewGuid(),
                Name = payment.Name,
                Fee = payment.Fee * payment.Months,
                Pending = payment.Pending,
                Receipt = payment.Receipt,
                FromDate = DateTime.Parse(payment.FromDate),
                ToDate = DateTime.Parse(payment.ToDate),
                ApplicationUser = user,
                ClientId = payment.ClId
            };
            
            var client = await _context.Clients.FindAsync(newPayment.ClientId);
            client!.ExpiredDate = newPayment.ToDate;

            _context.Clients.Update(client);
            await _context.Payments.AddAsync(newPayment);
            await _context.SaveChangesAsync();
            return newPayment;
        }
        public async Task EditPaymentAsync(EditPaymentViewModel model, Guid paymentId)
        {
            var payment = await _context.Payments
               .Include(p => p.ApplicationUser)
               .Include(p => p.Client)
               .FirstOrDefaultAsync(p => p.Id == paymentId);

            if (payment == null)
            {
                throw new Exception("Payment not found");
            }
            payment.Name = model.Name;
            payment.Fee = model.Fee;
            payment.Pending = model.Pending;
            payment.FromDate = model.FromDate;
            payment.ToDate = model.ToDate;
            payment.ClientId = model.ClId;
            payment.ApplicationUser.Id = model.UserId;

            var client = await _context.Clients.FindAsync(payment.ClientId);
            client!.ExpiredDate = model.ToDate;

            _context.Clients.Update(client);
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
        }
        public async Task<EditPaymentViewModel> GetPaymentForEditAsync(Guid Id)
        {
            var payment = await _context.Payments
                .Include(p => p.ApplicationUser)
                .Include(p => p.Client)
                .ThenInclude(c => c.ApplicationUser)
                .FirstOrDefaultAsync(p => p.Id == Id);

            if (payment == null)
            {
                throw new Exception("Payment not found");
            }
            var paymentForEdit = new EditPaymentViewModel
            {
                Name = payment.Name + $" - edited",
                Fee = payment.Fee,
                Pending = payment.Pending,
                FromDate = payment.FromDate,
                ToDate = payment.ToDate,
                ClId = payment.ClientId,
                Client = payment.Client!,
                UserId = payment.ApplicationUser.Id
            };
            return paymentForEdit;
        }
        public async Task<PaymentsDetailsView> GetPaymentDetailsAsync(Guid paymentId)
        {
            var payment = await _context.Payments.FindAsync(paymentId);
            if (payment == null)
            {
                throw new Exception("Payment not found");
            }
            var paymentDetails = new PaymentsDetailsView
            {
                Name = payment.Name,
                Value = payment.Fee,
                InstallationFee = payment.InstallationFee,
                Pending = payment.Pending,
                Receipt = payment.Receipt,
                FromDate = payment.FromDate.ToString(AppActivationDateFormatForDb),
                ToDate = payment.ToDate.ToString(AppExpiredDateFormat),
                ApplicationUser = payment.ApplicationUser.UserName
            };
            return paymentDetails;

        }
        public async Task DeletePaymentAsync(Guid id)
        {
            var payment = _context.Payments.Find(id);
            if (payment == null)
            {
                throw new Exception("Payment not found");
            }
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
        }
        public Guid GetPaymentIdByClientId(Guid clientId)
        {
            var payment = _context.Payments
                .FirstOrDefault(p => p.ClientId == clientId);
            if (payment == null)
            {
                throw new Exception("Payment not found");
            }
            return payment.Id;
        }
        public Task<Payment> GetPaymentByIdAsync(Guid paymentId)
        {
            var payment = _context.Payments
                .Include(p => p.Client)
                .FirstOrDefaultAsync(p => p.Id == paymentId);
            if (payment == null)
            {
                throw new Exception("Payment not found");
            }
            return payment!;
        }
    }
}
