namespace Billing_System.Core.ViewModels.TechnicalProblem
{
    public class AllTechProblemViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;
        public string Solution { get; set; } = null!;
        public string? ClientPhone { get; set; }
        public string? ClientAddress { get; set; }
        public string? ClientEmail { get; set; }
        public bool Solved { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? ResolvedOn { get; set; }
        public string ClientName { get; set; } = null!;
        public string RegisterProblemUserName { get; set; } = null!;
        public string? ResolvedProblemUserName { get; set; }
    }
}
