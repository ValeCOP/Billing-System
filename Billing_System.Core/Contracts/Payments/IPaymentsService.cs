namespace Billing_System.Core.Contracts.Payments
{
    using Billing_System.Core.ViewModels.Payments;
    using Billing_System.Data.Entities;

    public interface IPaymentsService
    {
        Task<PaymentsDetailsView> GetPaymentDetailsAsync(Guid id);
        Task<EditPaymentViewModel> GetPaymentForEditAsync(Guid Id);
        Task<Payment> AddPaymentAsync(AddPaymentViewModel model, Guid userId);
        Task EditPaymentAsync(EditPaymentViewModel model, Guid paymentId);
        Task DeletePaymentAsync(Guid paymentId);
        Task<AddPaymentViewModel> Add(Guid clientId);
        Guid GetPaymentIdByClientId(Guid clientId);
        Task<Payment> GetPaymentByIdAsync(Guid paymentId);
    }
}
