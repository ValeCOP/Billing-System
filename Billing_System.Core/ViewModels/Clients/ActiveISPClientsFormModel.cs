namespace Billing_System.Core.ViewModels.Clients
{
    using Billing_System.Core.ValidationAttributes;
    using Billing_System.Core.ViewModels.Payments;
    using System.ComponentModel.DataAnnotations;
    using static Utilities.ValidationConstants.ValidationConstants.ActiveISPClientsForm;

    public class ActiveISPClientsFormModel
    {
        [Required]
        [Display(Name = "Clients")]
        public Guid ClientId { get; set; }

        [Required]
        public string ClientFullName { get; set; } = null!;

        [Required, Range(typeof(decimal), InstallationFeeMin, InstallationFeeMax)]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = FeeErrorMessage)]
        [Display(Name = "Installation Fee")]
        public decimal InstallationFee { get; set; }

        [Required, Range(typeof(decimal), FeeMin, FeeMax)]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = InstallationFeeErrorMessage)]
        [Display(Name = "Fee")]
        public decimal Fee { get; set; }

        [Required]
        public bool Pending { get; set; }

        [Required]
        [Display(Name = "Activation Date")]
        public DateTime ActivationDate { get; set; }

        [Required]
        [Display(Name = "Expired Date")]
        [DateComparison(nameof(ActivationDate), ErrorMessage = DateComparisonErrorMessage)]
        public DateTime ExpiredDate { get; set; }

        [MaxLength(CommentsMaxLength)]
        public string? Comments { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        [Required]
        public bool Receipt { get; set; }

        public ICollection<ClientsFromISPModel> Clients { get; set; } = new List<ClientsFromISPModel>();

        public ICollection<PaymentDetailsView> PaymentDetails { get; set; } = new List<PaymentDetailsView>();
    }
}
