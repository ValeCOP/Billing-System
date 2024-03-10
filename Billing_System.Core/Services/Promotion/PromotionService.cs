namespace Billing_System.Core.Services.Promotion
{
    using Billing_System.Core.Contracts.Promotion;
    using Billing_System.Data.Entities;
    using System;
    using System.Globalization;
    using System.Threading.Tasks;
    using Billing_System.Data;

    public class PromotionService : IPromotionServise
    {
        private readonly BillingDbContext _context;

        public PromotionService(BillingDbContext context)
        {
            _context = context;
        }
        public async Task Add(Guid clientId)
        {
           
            var promotion = new Promotion()
            {
                Name = "Promotion_Month_FREE_" + CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month),
                Mounth = DateTime.Now.Month,
                ClientId = clientId
            };
            _context.Promotions.Add(promotion);
            await _context.SaveChangesAsync();
        }
    }
}
