namespace Billing_System.Core.Services.Expense
{
    using Billing_System.Core.Contracts.Expense;
    using Billing_System.Core.ViewModels.Expense;
    using Billing_System.Data;
    using Billing_System.Data.Entities;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ExpenseService : IExpenseService
    {
        private const long MaxFileSize = 5 * 1024 * 1024; // 5 МБ

        private readonly BillingDbContext _context;

        public ExpenseService(BillingDbContext context)
        {
            _context = context;
        }

        public async Task AddExpenseAsync(AddExpenseViewModel model)
        {
            if (model.File != null)
            {
                if (model.File.Length > MaxFileSize)
                {
                    throw new System.Exception("File size must be less than 5MB");
                }
                if (!IsJpeg(model.File))
                {
                    throw new System.Exception("File must be an image");
                }
            }
            string path = Path.Combine(Environment.CurrentDirectory, "wwwroot", "expense", model.File!.FileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.File.CopyToAsync(stream);
                };
                Expense expense = new Expense
                {
                    Name = model.Name,
                    UserId = model.UserId,
                    Value = model.Value,
                    Date = DateTime.Now,
                    Description = model.Description,
                    ReceiptUrl = @"/expense/" + model.File!.FileName
                };
                await _context.Expenses.AddAsync(expense);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new System.Exception(e.Message);
            }

        }

        public Task DeleteExpenseAsync(Guid id)
        {
            var expense = _context.Expenses.Find(id);
            if (expense == null)
            {
                throw new System.Exception("Expense not found");
            }
            _context.Expenses.Remove(expense);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","expense", expense.ReceiptUrl!.Split("/")[2]);
            //delete file
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            return _context.SaveChangesAsync();
        }


        public async Task<ICollection<AllExpenseViewModel>> GetExpenseAsync(FilteredExpensesViewModel modelGetForm)
        {
            var allExpenses = _context.Expenses
                .OrderByDescending(e => e.Date)
                .AsQueryable();
            if (!string.IsNullOrEmpty(modelGetForm.Filter))
            {
                allExpenses = allExpenses.Where(e => e.Name.ToLower().Contains(modelGetForm.Filter.ToLower()));
            }
            if (!string.IsNullOrEmpty(modelGetForm.OrderBy))
            {
                allExpenses = modelGetForm.OrderBy switch
                {
                    "Name" => allExpenses.OrderBy(e => e.Name),
                    "NameDesc" => allExpenses.OrderByDescending(e => e.Name),
                    "Date" => allExpenses.OrderBy(e => e.Date),
                    "DateDesc" => allExpenses.OrderByDescending(e => e.Date),
                    "Value" => allExpenses.OrderBy(e => e.Value),
                    "ValueDesc" => allExpenses.OrderByDescending(e => e.Value),
                    "ApplicationUser" => allExpenses.OrderBy(e => e.ApplicationUser.UserName),
                    "ApplicationUserDesc" => allExpenses.OrderByDescending(e => e.ApplicationUser.UserName),
                    _ => allExpenses.OrderByDescending(e => e.Date)
                };
            }
            allExpenses = allExpenses.Skip((modelGetForm.CurrentPage - 1) * 6).Take(6);
            return await allExpenses.Select(e => new AllExpenseViewModel
            {
                Id = e.Id,
                Name = e.Name,
                Value = e.Value,
                Date = e.Date,
                Description = e.Description,
                ReceiptUrl = e.ReceiptUrl,
                UserName = e.ApplicationUser.UserName
            }).ToListAsync();
        }

        private bool IsJpeg(IFormFile file)
        {
            if (file.ContentType == "image/jpeg" ||
                file.ContentType == "image/jpg" ||
                file.ContentType == "image/pjpeg")
            {
                return true;
            }

            string extension = Path.GetExtension(file.FileName);
            if (extension != null && (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg"))
            {
                return true;
            }

            return false;
        }
    }
}
