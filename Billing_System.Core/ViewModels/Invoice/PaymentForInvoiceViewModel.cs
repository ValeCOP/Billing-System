namespace Billing_System.Core.ViewModels.Invoice
{
    using Billing_System.Data.Entities;
    using System.ComponentModel.DataAnnotations;
    using static Billing_System.Utilities.ValidationConstants.ValidationConstants.Invoices;

    public class PaymentForInvoiceViewModel
    {
        [Required]
        [StringLength(MOLMaxLength, MinimumLength = MOLMinLength, ErrorMessage = MOLErrorMessage)]
        public string MOL { get; set; } = null!;

        [Required]
        [StringLength(UINLength, MinimumLength = UINLength, ErrorMessage = UINErrorMessage)]
        public string UIN { get; set; } = null!;

        [StringLength(VATINLength, MinimumLength = VATINLength, ErrorMessage = VATINErrorMessage)]
        public string? VATIN { get; set; }


        [Required]
        [StringLength(RecipientMaxLength, MinimumLength = RecipientMinLength, ErrorMessage = RecipientErrorMessage)]
        public string Recipient { get; set; } = null!;

        [Required]
        [StringLength(CompilerMaxLength, MinimumLength = CompilerMinLength, ErrorMessage = CompilerErrorMessage)]
        public string Compiler { get; set; } = null!;

        [Required]
        public bool BankTransfer { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public Client Client { get; set; } = null!;
        public Payment Payment { get; set; } = null!;
    }
}
