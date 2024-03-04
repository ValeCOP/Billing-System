namespace Billing_System.Controllers.Expense
{
    using Billing_System.Core.Contracts.Expense;
    using Billing_System.Core.CustomExtensions;
    using Billing_System.Core.ViewModels.Expense;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
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
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(model);
            }
            return RedirectToAction("All");
        }
       
    }
}
