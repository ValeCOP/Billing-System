namespace Billing_System.Core.ViewModels.TechnicalProblem
{
    public class FilteredTechProblemsViewModel
    {
        public string? Filter { get; set; }
        public string? OrderBy { get; set; }
        public bool Resolved { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int ProblemsCount { get; set; }
        public ICollection<AllTechProblemViewModel> TechnicalProblems { get; set; } = new List<AllTechProblemViewModel>();

    }
}
