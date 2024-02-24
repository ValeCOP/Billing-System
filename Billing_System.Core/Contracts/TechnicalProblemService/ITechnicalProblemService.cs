namespace Billing_System.Core.Contracts.TechnicalProblemService
{
    using Billing_System.Core.ViewModels.TechnicalProblem;
    using System.Collections.Generic;

    public interface ITechnicalProblemService
    {
        ICollection<ClientsNamesModel> GetClients();
    }
}
