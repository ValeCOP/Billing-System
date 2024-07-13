namespace Billing_System.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Billing_System.Utilities.ValidationConstants.ValidationConstants.Invoices;

    public class Invoice
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string InvoiceNumber { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        [MaxLength(MOLMaxLength)]
        public string MOL { get; set; } = null!;

        [Required]
        [MaxLength(UINLength)]
        public string UIN { get; set; } = null!;

        [MaxLength(VATINLength)]
        public string? VATIN { get; set; }

        [Required]
        [MaxLength(RecipientMaxLength)]
        public string Recipient { get; set; } = null!;

        [Required]
        [MaxLength(CompilerMaxLength)]
        public string Compiler { get; set; } = null!;

        [Required]
        public bool BankTransfer { get; set; }
        [Required]
        public bool Cash { get; set; }

        [Required]
        [ForeignKey("Payment")]
        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; } = null!;

        [Required]
        [ForeignKey("ApplicationUser")]
        public Guid UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = null!;

    }
}
