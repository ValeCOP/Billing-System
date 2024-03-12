namespace Billing_System.Core.ViewModels.ArchiveClients
{
    public class ArchiveMonthDetails
    {
        public string MonthName { get; set; } = null!;
        public int ClientsCount { get; set; }
        public decimal TotalAmount { get; set; }
        public int TotalTechnicalProblems { get; set; }
        public decimal TotalExpenses { get; set; }
        public string? PromoClientName { get; set; }
    }
}