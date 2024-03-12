namespace Billing_System.Core.Contracts.Promotion
{
    using Billing_System.Data.Entities;

    public interface IPromotionService
    {
        Task Add(Guid clientId);
        Task<string> GetProfitableClientAsync();
        Task<bool> PromotionIsAdded();
    }
}
