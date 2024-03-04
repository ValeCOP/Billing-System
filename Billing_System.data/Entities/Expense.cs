namespace Billing_System.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Utilities.ValidationConstants.ValidationConstants.Expense;

    public class Expense
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [Range(typeof(decimal),ValueMinLength, ValueMaxLength)]
        public decimal Value { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public string? ReceiptUrl { get; set; } 

        [ForeignKey("ApplicationUser")]
        public Guid UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = null!;
    }
}
