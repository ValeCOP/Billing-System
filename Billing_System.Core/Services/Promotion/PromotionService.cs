namespace Billing_System.Core.Services.Promotion
{
    using Billing_System.Core.Contracts.Promotion;
    using Billing_System.Data.Entities;
    using System;
    using System.Globalization;
    using System.Threading.Tasks;
    using Billing_System.Data;
    using Microsoft.EntityFrameworkCore;

    public class PromotionService : IPromotionService
    {
        private readonly BillingDbContext _context;

        public PromotionService(BillingDbContext context)
        {
            _context = context;
        }
        public async Task Add(Guid clientId)
        {
            var client = await _context.Clients.FindAsync(clientId);
            if (client == null)
            {
                throw new Exception("Client not found");
            }

            var promotion = new Promotion()
            {
                Name = "Promotion_Month_FREE_" + CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month),
                Month = DateTime.Now.Month,
                ClientFullName = client.FullName
            };
            _context.Promotions.Add(promotion);
            await _context.SaveChangesAsync();
        }

        public async Task<string> GetProfitableClientAsync()
        {
            string? clientName  = await _context.Promotions
                .Select(g => g.ClientFullName)
                .FirstOrDefaultAsync();
            return clientName!;
        }

        public async Task<bool> PromotionIsAdded()
        {
           return await _context.Promotions.AnyAsync();
        }
    }
}
