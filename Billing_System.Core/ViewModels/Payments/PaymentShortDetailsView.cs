namespace Billing_System.Core.ViewModels.Payments
{
    public class PaymentDetailsView
    {
        public decimal TotalValue { get; set; }
        public decimal PendingValue { get; set; }
        public decimal ReceiptValue { get; set; }
    }
}
