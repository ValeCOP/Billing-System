namespace Billing_System.Core.Contracts.Receipt
{
    public interface IReceiptService
    {
        Task CreateReceiptAsync (Guid paymentId);
    }
}
