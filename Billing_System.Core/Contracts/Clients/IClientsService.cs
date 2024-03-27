namespace Billing_System.Core.Contracts.Clients
{
    using Billing_System.Core.ViewModels.Clients;
    using System;
    using System.Threading.Tasks;

    public interface IClientsService
    {
        Task DeleteClientAsync(Guid id);
        Task<ICollection<ActivatedClientsViewModel>> GetAllClientsAsync(FilteredClientsViewModel model);
        Task<ActivatedClientsViewModel> GetClientDetailsAsync(Guid id);
        Task<ICollection<ShortInfoForActivatedClients>> GetClientShortAsync();
       
    }
}
