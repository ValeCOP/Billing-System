namespace Billing_System.Core.ViewModels.Users
{
    using Billing_System.Data.Entities;

    public class UsersViewWithPayments
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    }
}
