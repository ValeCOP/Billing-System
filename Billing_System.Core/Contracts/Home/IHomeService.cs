namespace Billing_System.Core.Contracts.Home
{
    using Billing_System.Core.ViewModels.Clients;

    public interface IHomeService
    {
        Task ActivateClientAsync(ActiveISPClientsFormModel model, string userId);
        Task<ActiveISPClientsFormModel> ImportISPRouterDataAsync();
        Task UpdateISPRouterDataAsync(Guid clientId);
        Task<string> GetJWTAsync();
    }
}
