namespace Billing_System.Core.ViewModels.Invoice
{
    using Billing_System.Data.Entities;

    public class PaymentForInvoiceViewModel
    {
        public int InvoiceNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public Client Client { get; set; } = null!;
        public Payment Payment { get; set; } = null!;
    }
}
