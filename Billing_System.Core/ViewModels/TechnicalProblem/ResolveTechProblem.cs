namespace Billing_System.Core.ViewModels.TechnicalProblem
{
    using System.ComponentModel.DataAnnotations;

    public class ResolveTechProblem
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;
        public bool Solved { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? ResolvedOn { get; set; }
        public string ClientName { get; set; } = null!;

        [Display(Name = "User")]
        public string RegisterProblemUserName { get; set; } = null!;
    }
}
