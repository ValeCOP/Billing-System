namespace Billing_System.Core.Services.TechnicalProblem
{
    using Billing_System.Core.Contracts.Home;
    using Billing_System.Core.Contracts.TechnicalProblemService;
    using Billing_System.Core.ViewModels.Clients;
    using Billing_System.Core.ViewModels.TechnicalProblem;
    using Billing_System.Data;
    using Billing_System.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http.Headers;
    using static Utilities.ValidationConstants.ValidationConstants;


    public class TechnicalProblemService : ITechnicalProblemService
    {

        private readonly BillingDbContext _context;
        private readonly IHomeService _homeService;
        private readonly IHttpClientFactory _clientFactory;
        private string clientsUrl = ApiUrl;

        public TechnicalProblemService(IHttpClientFactory clientFactory, BillingDbContext dbContext, IHomeService homeService)
        {
            _homeService = homeService;
            _context = dbContext;
            _clientFactory = clientFactory;
        }

        public async Task AddTechnicalProblemAsync(AddTechProblemView model)
        {
            TechnicalProblem technicalProblem = new()
            {
                Description = model.Description,
                ClientName = model.ClientName,
                RegisterProblemUserId = model.RegisterProblemUserId,
                RegisteredOn = DateTime.Now,
                Solved = false,
                ClientPhone = model.ClientPhone,
                ClientAddress = model.ClientAddress,
                ClientEmail = model.ClientEmail
            };
            _context.TechnicalProblems.Add(technicalProblem);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<AllTechProblemViewModel>> GetTechnicalProblemsAsync(FilteredTechProblemsViewModel modelGetForm)
        {

            var allTechProblems = _context.TechnicalProblems
                .OrderByDescending(t => !t.Solved)
                .ThenBy(t => t.RegisteredOn)
                .AsQueryable();
            if (modelGetForm.Resolved)
            {
                allTechProblems = allTechProblems.Where(t => t.Solved);
            }
            if (!modelGetForm.Resolved)
            {
                allTechProblems = allTechProblems.Where(t => !t.Solved);
            }
            if (!string.IsNullOrEmpty(modelGetForm.Filter))
            {
                allTechProblems = allTechProblems.Where(t => t.ClientName.ToLower().Contains(modelGetForm.Filter.ToLower()));
            }
            if (!string.IsNullOrEmpty(modelGetForm.OrderBy))
            {
                allTechProblems = modelGetForm.OrderBy switch
                {
                    "FullName" => allTechProblems.OrderBy(t => t.ClientName),
                    "FullNameDesc" => allTechProblems.OrderByDescending(t => t.ClientName),
                    "RegisteredOn" => allTechProblems.OrderBy(t => t.RegisteredOn),
                    "RegisteredOnDesc" => allTechProblems.OrderByDescending(t => t.RegisteredOn),
                    "ResolvedOn" => allTechProblems.OrderBy(t => t.ResolvedOn),
                    "ResolvedOnDesc" => allTechProblems.OrderByDescending(t => t.ResolvedOn),
                    "ApplicationUser" => allTechProblems.OrderBy(t => t.RegisterProblemUser.UserName),
                    "ApplicationUserDesc" => allTechProblems.OrderByDescending(t => t.RegisterProblemUser.UserName),
                    _ => allTechProblems.OrderByDescending(t => t.RegisteredOn)
                };
            }
            allTechProblems = allTechProblems.Skip((modelGetForm.CurrentPage - 1) * 3).Take(3);
            modelGetForm.ProblemsCount = await allTechProblems.CountAsync();
            return await allTechProblems.Select(t => new AllTechProblemViewModel
            {
                Id = t.Id,
                Description = t.Description,
                Solution = t.Solution!,
                Solved = t.Solved,
                RegisteredOn = t.RegisteredOn,
                ResolvedOn = t.ResolvedOn,
                ClientName = t.ClientName,
                ClientPhone = t.ClientPhone,
                ClientAddress = t.ClientAddress,
                ClientEmail = t.ClientEmail,
                RegisterProblemUserName = t.RegisterProblemUser.UserName,
                ResolvedProblemUserName = t.ResolvedProblemUser.UserName,
                
            }).ToListAsync();
        }

        public async Task<ICollection<ClientsInfoModel>> GetClientsAsync()
        {
            var clientsNames = new List<ClientsInfoModel>();

            var token = await _homeService.GetJWTAsync();
            var httpClient = _clientFactory.CreateClient("BillingServer");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage request = httpClient.GetAsync(clientsUrl).Result;

            if (!request.IsSuccessStatusCode)
            {
                throw new Exception("Error reading ISP router info!");
            }

            var jsonString = await request.Content.ReadAsStringAsync();
            GetClientsFromISPViewModel[] clients_DTOs = JsonConvert.DeserializeObject<GetClientsFromISPViewModel[]>(jsonString)!;

            foreach (var client in clients_DTOs)
            {
                if (client.Id.ToString() == null || string.IsNullOrEmpty(client.FullName))
                {
                    continue;
                }

                DateTime activationDate;
                if (!DateTime.TryParseExact(client.ActivationDate, AppExpiredDateFormat,
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out activationDate))
                {
                    throw new Exception("Error reading ISP router info! Invalid Activation Date format");
                }

                DateTime expiredDate;
                if (!DateTime.TryParseExact(client.ExpiredDate, AppExpiredDateFormat,
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out expiredDate))
                {
                    throw new Exception("Error reading ISP router info! Invalid Expired Date format");
                }
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
            return clientsNames.OrderBy(c => c.FullName).ToList();
        }

        public async Task<ResolveTechProblem> GetTechnicalProblemByIdAsync(Guid id)
        {
            var technicalProblem = await _context.TechnicalProblems
                .Where(t => t.Id == id)
                .Select(t => new ResolveTechProblem
                {
                    Id = t.Id,
                    Description = t.Description,
                    Solved = t.Solved,
                    RegisteredOn = t.RegisteredOn,
                    ClientName = t.ClientName,
                    ClientPhone = t.ClientPhone,
                    ClientAddress = t.ClientAddress,
                    ClientEmail = t.ClientEmail,
                    RegisterProblemUserName = t.RegisterProblemUser.UserName,
                }).FirstOrDefaultAsync();

            if (technicalProblem == null)
            {
                throw new ArgumentNullException("Technical problem not found");
            }

            return technicalProblem;
        }

        public async Task ResolveTechnicalProblemAsync(ResolveTechProblemView model, Guid userId)
        {
            var technicalProblem = await _context.TechnicalProblems.FindAsync(model.Id);
            technicalProblem!.Solved = model.Solved;
            technicalProblem.ResolvedOn = DateTime.Now;
            technicalProblem.ResolvedProblemUserId = userId;
            technicalProblem.Solution = model.Solution;
            _context.TechnicalProblems.Update(technicalProblem);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetTechnicalCountAsync()
        {
            var count = await _context.TechnicalProblems.CountAsync();
            return count;
        }

        public async Task DeleteTechnicalProblemAsync(Guid id)
        {
            var technicalProblem = await _context.TechnicalProblems.FindAsync(id);
            _context.TechnicalProblems.Remove(technicalProblem!);
            await _context.SaveChangesAsync();
        }
    }
}
