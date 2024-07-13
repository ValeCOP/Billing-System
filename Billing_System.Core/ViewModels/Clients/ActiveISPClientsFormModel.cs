namespace Billing_System.Core.ViewModels.Clients
{
    using Billing_System.Core.ValidationAttributes;
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
        [Display(Name = "Installation Fee")]
        public decimal InstallationFee { get; set; }

        [Required, Range(typeof(decimal), FeeMin, FeeMax)]
        [Display(Name = "Fee")]
        public decimal Fee { get; set; }

        [Required]
        [Display(Name = "Months")]
        [Range(MonthsMin, MonthsMax)]
        public int Months { get; set; }

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

    }
}
