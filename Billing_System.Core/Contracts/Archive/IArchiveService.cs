using Billing_System.Core.ViewModels.ArchiveClients;

namespace Billing_System.Core.Contracts.Archive
{
    public interface IArchiveService
    {
        Task ArchiveClients(int month);
        Task DeleteMonth(string monthName);
        Task<ICollection<ArchiveMonthDetails>> GetMonthDetailsAsync();
    }
}
