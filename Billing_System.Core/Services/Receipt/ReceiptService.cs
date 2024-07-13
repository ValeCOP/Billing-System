namespace Billing_System.Core.Services.Receipt
{
    using Billing_System.Core.Contracts.Receipt;
    using Billing_System.Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Text;
    using System.Threading.Tasks;

    public class ReceiptService : IReceiptService
    {
        private readonly BillingDbContext _context;

        public ReceiptService(BillingDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task CreateReceiptAsync(Guid paymentId)
        {
            var payment = await _context.Payments
                .Include(p => p.Client)
                .FirstOrDefaultAsync(p => p.Id == paymentId);
            if (payment == null)
            {
                throw new Exception("Payment not found");
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"P,1,______,_,__;Клиент:;");
            sb.AppendLine($"P,1,______,_,__;{payment.Client!.FullName};");
            sb.AppendLine($"P,1,______,_,__;Пуснат до:;");
            sb.AppendLine($"P,1,______,_,__;{payment.ToDate};");
            sb.AppendLine($"S,1,______,_,__;;{payment.Fee + payment.InstallationFee};1.000;1;1;2;0;0;");
            sb.AppendLine($"T,1,______,_,__;");

            string filePath = Directory.GetCurrentDirectory();

            using (StreamWriter writer = new StreamWriter(filePath + @"\ReceiptPrint.inp", true, Encoding.GetEncoding("utf-8")))
            {
                writer.WriteLine(sb);
            }
        }
    }
}
