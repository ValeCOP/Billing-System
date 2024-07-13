namespace Billing_System.Core.ViewModels.Expense
{
    public class FilteredExpensesViewModel
    {
        public string? Filter { get; set; }
        public string? OrderBy { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int ExpensesCount { get; set; }
        public ICollection<AllExpenseViewModel> Expenses { get; set; } = new List<AllExpenseViewModel>();
    }
}
