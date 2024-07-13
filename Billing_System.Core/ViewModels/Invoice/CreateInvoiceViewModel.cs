namespace Billing_System.Core.ViewModels.Invoice
{
    using System.ComponentModel.DataAnnotations;
    using static Billing_System.Utilities.ValidationConstants.ValidationConstants.Invoices;

    public class CreateInvoiceViewModel
    {
        [Required]
        [StringLength(MOLMaxLength, MinimumLength = MOLMinLength , ErrorMessage = MOLErrorMessage)]
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


    }
}