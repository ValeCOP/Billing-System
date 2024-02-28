namespace Billing_System.Core.Contracts.TechnicalProblemService
{
    using Billing_System.Core.ViewModels.Clients;
    using Billing_System.Core.ViewModels.TechnicalProblem;
    using System;
    using System.Collections.Generic;

    public interface ITechnicalProblemService
    {
        Task AddTechnicalProblemAsync(AddTechProblemView model);
        Task<ICollection<AllTechProblemViewModel>> GetTechnicalProblemsAsync(FilteredTechProblemsViewModel modelGetForm);
        Task<ICollection<ClientsInfoModel>> GetClientsAsync();
        Task<ResolveTechProblem> GetTechnicalProblemByIdAsync(Guid id);
        Task ResolveTechnicalProblemAsync(string desc,bool solved,Guid tpId, Guid userId);
        Task<int> GetTechnicalCountAsync();
    }
}
