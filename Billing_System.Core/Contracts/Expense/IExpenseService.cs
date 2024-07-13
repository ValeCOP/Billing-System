namespace Billing_System.Core.Contracts.Expense
{
    using Billing_System.Core.ViewModels.Expense;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Threading.Tasks;

    public interface IExpenseService
    {
        Task AddExpenseAsync(AddExpenseViewModel model);
        Task DeleteExpenseAsync(Guid id);
        Task<ICollection<AllExpenseViewModel>> GetExpenseAsync(FilteredExpensesViewModel modelGetForm);
    }
}
