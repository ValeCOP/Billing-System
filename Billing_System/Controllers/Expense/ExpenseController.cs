namespace Billing_System.Controllers.Expense
{
    using Billing_System.Core.Contracts.Expense;
    using Billing_System.Core.CustomExtensions;
    using Billing_System.Core.ViewModels.Expense;
    using Billing_System.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using static Billing_System.Utilities.ValidationConstants.ValidationConstants.RolesConstants;


    [Authorize(Roles = AdministratorRoleName)]
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        public IActionResult Add()
        {
            AddExpenseViewModel model = new AddExpenseViewModel();
            model.UserId = Guid.Parse(User.GetId());
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddExpenseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid input");
                return View(model);
            }
            if (model.Value < 0.10m && model.Value > 10000.00m)
            {
                ModelState.AddModelError(string.Empty, "Value must be between 0.10 and 10000.00");
                return View(model);
            }

            try
            {
                await _expenseService.AddExpenseAsync(model);
                TempData["message"] = $"Expense for {model.Name} added successfully";
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(model);
            }
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> All(FilteredExpensesViewModel modelGetForm)
        {
            try
            {
                FilteredExpensesViewModel model = new FilteredExpensesViewModel()
                {
                    Expenses = await _expenseService.GetExpenseAsync(modelGetForm)
                };
                model.ExpensesCount = model.Expenses.Count;
                model.CurrentPage = modelGetForm.CurrentPage;
                return View(model);

            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = ex.Message
                });
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _expenseService.DeleteExpenseAsync(id);
            }
            catch (Exception e)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = e.Message
                });
            }
            return RedirectToAction("All");
        }

    }
}
