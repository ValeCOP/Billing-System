namespace Billing_System.Core.ViewModels.TechnicalProblem
{
    public class ResolveTechProblemView
    {
        public Guid Id { get; set; }
        public string Solution { get; set; } = null!;
        public bool Solved { get; set; }
        public bool SendMailToClient { get; set; }
        public string? ClientEmail { get; set; }
        public string? ClientName { get; set; }
    }
}
