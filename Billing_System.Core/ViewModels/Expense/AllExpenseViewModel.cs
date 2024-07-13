namespace Billing_System.Core.ViewModels.Expense
{
    public class AllExpenseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = null!;
        public string ReceiptUrl { get; set; } = null!;
        public string UserName { get; set; } = null!;
    }
}