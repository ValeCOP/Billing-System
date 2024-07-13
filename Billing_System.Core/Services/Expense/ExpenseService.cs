namespace Billing_System.Core.Services.Expense
{
    using Billing_System.Core.Contracts.Expense;
    using Billing_System.Core.ViewModels.Expense;
    using Billing_System.Data;
    using Billing_System.Data.Entities;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Net;
    using System.Reflection;
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
                    throw new Exception("File size must be less than 5MB");
                }
                if (!IsJpeg(model.File))
                {
                    throw new Exception("File must be an image");
                }
            }

            var fileName = Path.GetFileName(model.File!.FileName);
            var fileExtension = Path.GetExtension(fileName);
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            var sanitizedFileName = WebUtility.HtmlEncode(fileNameWithoutExtension) + fileExtension;

            var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string path = Path.Combine(currentDirectory, "..\\..\\..\\","wwwroot", "images", "expense", sanitizedFileName);
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
                    ReceiptUrl = @"/images/expense/" + sanitizedFileName
                };
                await _context.Expenses.AddAsync(expense);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public Task DeleteExpenseAsync(Guid id)
        {
            var expense = _context.Expenses.Find(id);
            if (expense == null)
            {
                throw new Exception("Expense not found");
            }
            _context.Expenses.Remove(expense);

            var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.Combine(currentDirectory , "..\\..\\..\\", "wwwroot","images","expense", expense.ReceiptUrl!.Split("/")[3]);  

            if (File.Exists(path))
            {
                File.Delete(path);
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
            allExpenses = allExpenses.Skip((modelGetForm.CurrentPage - 1) * 3).Take(3);
            modelGetForm.ExpensesCount = allExpenses.Count();
            modelGetForm.Expenses = await allExpenses.Select(e => new AllExpenseViewModel
            {
                Id = e.Id,
                Name = e.Name,
                Value = e.Value,
                Date = e.Date,
                Description = e.Description,
                ReceiptUrl = e.ReceiptUrl,
                UserName = e.ApplicationUser.UserName
            }).ToListAsync();
            return modelGetForm.Expenses;
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
