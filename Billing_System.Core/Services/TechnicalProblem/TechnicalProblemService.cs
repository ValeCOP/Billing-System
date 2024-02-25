namespace Billing_System.Core.Services.TechnicalProblem
{
    using Billing_System.Core.Contracts.TechnicalProblemService;
    using Billing_System.Core.ViewModels.Clients;
    using Billing_System.Core.ViewModels.TechnicalProblem;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TechnicalProblemService : ITechnicalProblemService
    {
        private readonly HttpClient _httpClient;

        public TechnicalProblemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7231");
        }
        public async Task<ICollection<ClientsInfoModel>> GetClientsAsync()
        {
            var clientsNames = new List<ClientsInfoModel>();

            HttpResponseMessage request = _httpClient.GetAsync("/Clients").Result;

            if (!request.IsSuccessStatusCode)
            {
                throw new Exception("Error reading ISP router info!");
            }

            var jsonString = await request.Content.ReadAsStringAsync();
            GetClientsFromISPViewModel[] clients_DTOs = JsonConvert.DeserializeObject<GetClientsFromISPViewModel[]>(jsonString)!;

            foreach (var client in clients_DTOs)
            {
               clientsNames.Add(new ClientsInfoModel
               {
                   Id = client.Id,
                   FullName = client.FullName,
                   ActivationDate = DateTime.Parse(client.ActivationDate),
                   ExpiredDate = DateTime.Parse(client.ExpiredDate),
                   Address = client.Address,
                   Email = client.Email,
                   Phone = client.Phone
               });
            }
            return clientsNames.OrderBy( c => c.FullName).ToList();
        }
    }
}
