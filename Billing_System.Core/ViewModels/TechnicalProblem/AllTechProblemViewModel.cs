namespace Billing_System.Core.ViewModels.TechnicalProblem
{
    public class AllTechProblemViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;
        public bool Solved { get; set; }

        public string Phone { get; set; } = null!;
        public string? Solution { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime ResolvedOn { get; set; }
        public Guid ClientId { get; set; }
        public string ClientName { get; set; } = null!;
        public Guid RegisterProblemUserId { get; set; }
        public string RegisterProblemUserName { get; set; } = null!;
        public Guid ResolvedProblemUserId { get; set; }
        public string ResolvedProblemUserName { get; set; } = null!;
    }
}
