namespace Billing_System.Core.Services.TechnicalProblem
{
    using Billing_System.Core.Contracts.TechnicalProblemService;
    using Billing_System.Core.ViewModels.Clients;
    using Billing_System.Core.ViewModels.TechnicalProblem;
    using Billing_System.Data;
    using Billing_System.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TechnicalProblemService : ITechnicalProblemService
    {
        private readonly HttpClient _httpClient;
        private readonly BillingDbContext _context;

        public TechnicalProblemService(HttpClient httpClient,BillingDbContext dbContext)
        {
            _context = dbContext;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7231");
        }

        public async Task AddTechnicalProblemAsync(AddTechProblemView model)
        {
            TechnicalProblem technicalProblem = new()
            {
                Description = model.Description,
                ClientName = model.ClientName,
                RegisterProblemUserId = model.RegisterProblemUserId,
                RegisteredOn = DateTime.Now,
                Solved = false
            };
            _context.TechnicalProblems.Add(technicalProblem);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<AllTechProblemViewModel>> GetAllTechnicalProblemsAsync()
        {
           var allTechProblems = await _context.TechnicalProblems
                .Select(t => new AllTechProblemViewModel
                {
                    Id = t.Id,
                    Description = t.Description,
                    Solved = t.Solved,
                    RegisteredOn = t.RegisteredOn,
                    ClientName = t.ClientName,
                    RegisterProblemUserName = t.RegisterProblemUser.UserName,
                }).ToListAsync();
            return allTechProblems;
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
