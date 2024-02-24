namespace Billing_System.Core.ViewModels.ArchiveClients
{
    public class ArchiveMonthDetails
    {
        public string MonthName { get; set; } = null!;
        public int ClientsCount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}