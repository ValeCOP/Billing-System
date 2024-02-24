namespace Billing_System.Data.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using static Billing_System.Utilities.ValidationConstants.ValidationConstants.Payments;

    public class Payment
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required, Column(TypeName = "decimal(18,2)")]

        [Range(ValueMinLength, ValueMaxLength)]
        public decimal Fee { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        [Range(InstallationFeeMinLength, InstallationFeeMaxLength)]
        public decimal InstallationFee { get; set; }

        [Required]
        public bool Pending { get; set; }
        [Required]
        public bool Receipt { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        [Required]
        public DateTime ToDate { get; set; }

        [Required]
        [ForeignKey("ActivatedClient")]
        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; } = null!;

        [Required]
        [ForeignKey("ApplicationUser")]
        public Guid UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; } = null!;
    }
}