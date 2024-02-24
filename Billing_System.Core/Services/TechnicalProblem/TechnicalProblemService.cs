namespace Billing_System.Core.Services.TechnicalProblem
{
    using Billing_System.Core.Contracts.TechnicalProblemService;
    using Billing_System.Core.ViewModels.Clients;
    using Billing_System.Core.ViewModels.TechnicalProblem;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Globalization;

    public class TechnicalProblemService : ITechnicalProblemService
    {
        public ICollection<ClientsNamesModel> GetClients()
        {
            var clientsNames = new List<ClientsNamesModel>();

            var currentDirectory = Directory.GetCurrentDirectory();

            //this is info from the ISP router
            string jsonString;
            try
            {
                jsonString = File.ReadAllText(currentDirectory + @"\clients.json");
            }
            catch (Exception)
            {
                throw new Exception("Error reading ISP router info! Check if the file exists");
            }

            GetClientsFromISPViewModel[] clients_DTOs = JsonConvert.DeserializeObject<GetClientsFromISPViewModel[]>(jsonString)!;

            foreach (var client in clients_DTOs)
            {
               clientsNames.Add(new ClientsNamesModel
               {
                   Id = client.Id,
                   FullName = client.FullName,
               });
            }
            return clientsNames.OrderBy( c => c.FullName).ToList();
        }
    }
}
