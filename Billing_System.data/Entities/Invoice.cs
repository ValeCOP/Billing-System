namespace Billing_System.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Invoice
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int InvoiceNumber { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey("Payment")]
        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; } = null!;
    }
}
