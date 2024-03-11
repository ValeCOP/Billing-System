namespace Billing_System.Core.ViewModels.Payments
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using static Billing_System.Utilities.ValidationConstants.ValidationConstants.Payments;
    using Billing_System.Data.Entities;

    public class EditPaymentViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required, MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required, Column(TypeName = "decimal(18,2)")]

        [Range(ValueMinLength, ValueMaxLength)]
        public decimal Fee { get; set; }

        [Required]
        public bool Pending { get; set; }

        [Required]
        [Display(Name = "From Date")]
        public DateTime FromDate { get; set; } 

        [Required]
        [Display(Name = "To Date")] 
        public DateTime ToDate { get; set; } 

        [Required]
        public Guid ClId { get; set; }

        public virtual Client? Client { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
