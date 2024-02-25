namespace Billing_System.Core.ViewModels.TechnicalProblem
{
    public class AllTechProblemViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;
        public bool Solved { get; set; }
        public string Phone { get; set; } = null!;
        public string? Address { get; set; }
        public DateTime RegisteredOn { get; set; }
        public string ClientName { get; set; } = null!;
        public string RegisterProblemUserName { get; set; } = null!;
    }
}
