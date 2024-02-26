namespace Billing_System.Core.Contracts.TechnicalProblemService
{
    using Billing_System.Core.ViewModels.Clients;
    using Billing_System.Core.ViewModels.TechnicalProblem;
    using System.Collections.Generic;

    public interface ITechnicalProblemService
    {
        Task AddTechnicalProblemAsync(AddTechProblemView model);
        Task<ICollection<AllTechProblemViewModel>> GetAllTechnicalProblemsAsync();
        Task<ICollection<ClientsInfoModel>> GetClientsAsync();
    }
}
