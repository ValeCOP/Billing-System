namespace Billing_System.Core.ViewModels.TechnicalProblem
{
    public class ResolveTechProblemView
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;
        public bool Solved { get; set; }
       
    }
}
