namespace Billing_System.Core.ViewModels.TechnicalProblem
{
    using System.ComponentModel.DataAnnotations;

    public class ResolveTechProblem
    {
        public Guid Id { get; set; }

        [Display(Name = "Description:")]
        public string Description { get; set; } = null!;

        [Display(Name = "Solution:")]
        [MinLength(20)]
        public string Solution { get; set; } = null!;

        public bool Solved { get; set; }

        [Display(Name = "Registered On:")]
        public DateTime RegisteredOn { get; set; }

        public DateTime? ResolvedOn { get; set; }


        [Display(Name = "Client Name:")]
        public string ClientName { get; set; } = null!;


        [Display(Name = "Client Tel:")]
        public string? ClientPhone { get; set; }


        [Display(Name = "Client Email:")]
        public string? ClientEmail { get; set; }


        [Display(Name = "Client Address:")]
        public string? ClientAddress { get; set; }

        [Display(Name = "User:")]
        public string RegisterProblemUserName { get; set; } = null!;

    }
}
