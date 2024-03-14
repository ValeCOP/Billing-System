namespace Billing_System.Core.ViewModels.Payments
{
    using Billing_System.Data.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Billing_System.Utilities.ValidationConstants.ValidationConstants.Payments;
    using static Billing_System.Utilities.ValidationConstants.ValidationConstants.ActiveISPClientsForm;

    public class AddPaymentViewModel
    {

        [Required, MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required, Column(TypeName = "decimal(18,2)")]

        [Range(ValueMinLength, ValueMaxLength)]
        public decimal Fee { get; set; }

        [Required]
        [Display(Name = "Months")]
        [Range(MonthsMin, MonthsMax)]
        public int Months { get; set; }

        [Required]
        public bool Pending { get; set; }
        [Required]
        public bool Receipt { get; set; }

        [Required]
        public string FromDate { get; set; } = null!;

        [Required]
        public string ToDate { get; set; } = null!;

        [Required]
        public Guid ClId { get; set; }
        
        public virtual  Client? Client { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
