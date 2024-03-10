namespace Billing_System.Core.Contracts.Promotion
{
    public interface IPromotionServise
    {
        Task Add(Guid clientId);
    }
}
