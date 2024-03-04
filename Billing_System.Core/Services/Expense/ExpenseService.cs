namespace Billing_System.Core.Services.Expense
{
    using Billing_System.Core.Contracts.Expense;
    using Billing_System.Core.ViewModels.Expense;
    using Billing_System.Data;
    using Billing_System.Data.Entities;
    using Microsoft.AspNetCore.Http;
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
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "expense", model.File!.FileName);
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
                    ReceiptUrl = path
                };
                await _context.Expenses.AddAsync(expense);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new System.Exception(e.Message);
            }

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
