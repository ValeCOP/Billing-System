namespace Billing_System.Core.ViewModels.Invoice
{
    using Billing_System.Data.Entities;

    public class AllInvoiceViewModel
    {
        public Guid Id { get; set; }
        public string InvoiceNumber { get; set; } = null!;
        public string MOL { get; set; } = null!;
        public string UIN { get; set; } = null!;
        public string? VATIN { get; set; }
        public string Recipient { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string ClientFullName { get; set; } = null!;
        public string ClientAddress { get; set; } = null!;
        public Payment Payment { get; set; } = null!;
        public bool BankTransfer { get; set; }
        public bool Cash { get; set; }
    }
}
