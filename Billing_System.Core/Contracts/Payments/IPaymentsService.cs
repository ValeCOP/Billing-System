namespace Billing_System.Core.Contracts.Payments
{
    using Billing_System.Core.ViewModels.Payments;
    using Billing_System.Data.Entities;

    public interface IPaymentsService
    {
        Task<PaymentsDetailsView> GetPaymentDetailsAsync(Guid id);
        Task<EditPaymentView> GetPaymentForEditAsync(Guid Id);
        Task<Payment> AddPaymentAsync(AddPaymentView model, Guid userId);
        Task EditPaymentAsync(EditPaymentView model, Guid paymentId);
        Task DeletePaymentAsync(Guid paymentId);
        Task<AddPaymentView> Add(Guid clientId);
        Guid GetPaymentIdByClientId(Guid clientId);
    }
}
