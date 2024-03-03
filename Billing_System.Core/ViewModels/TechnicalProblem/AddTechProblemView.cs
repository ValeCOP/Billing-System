namespace Billing_System.Core.ViewModels.TechnicalProblem
{
    using Billing_System.Core.ViewModels.Clients;
    using System.ComponentModel.DataAnnotations;
    using static Utilities.ValidationConstants.ValidationConstants.TechnicalProblems;

    public class AddTechProblemView
    {
        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength,
            ErrorMessage = DescriptionErrorMessage)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime RegisteredOn { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Send Mail")]
        public bool SendMail { get; set; }

        [Required]
        public Guid ClientId { get; set; }
        public string? ClientPhone { get; set; }
        public string? ClientAddress { get; set; }
        public string? ClientEmail { get; set; }

        [Required]
        public string ClientName { get; set; } = null!;

        [Required]
        public Guid RegisterProblemUserId { get; set; }
        public ICollection<ClientsInfoModel> ClientsFromISPRouter { get; set; } = new List<ClientsInfoModel>();

    }
}
