namespace Billing_System.Core.Services.Home
{
    using Billing_System.Core.Contracts.Home;
    using Billing_System.Core.ViewModels.Clients;
    using Billing_System.Data;
    using Billing_System.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using static Utilities.ValidationConstants.ValidationConstants;


    public class HomeService : IHomeService
    {
        private readonly BillingDbContext _context;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;
        private readonly string clientsUrl = ApiUrl;
        private readonly string loginUrl = LoginApiUrl;

        public HomeService(BillingDbContext dbContext,
            IHttpClientFactory clientFactory,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _clientFactory = clientFactory;
            _context = dbContext;
        }

        public async Task<ActiveISPClientsFormModel> ImportISPRouterDataAsync()
        {
            var clients = new List<ClientsFromISPModel>();
            try
            {
                var httpClient = _clientFactory.CreateClient("BillingServer");
                
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetJWTAsync());

                HttpResponseMessage response = await httpClient.GetAsync(clientsUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();

                    var clients_DTOs = JsonConvert.DeserializeObject<GetClientsFromISPViewModel[]>(jsonContent);

                    foreach (var client in clients_DTOs!)
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

                        clients.Add(new ClientsFromISPModel
                        {
                            Id = client.Id,
                            FullName = client.FullName,
                            ExpiredDate = expiredDate,
                            ActivationDate = activationDate,
                            Address = client.Address,
                            Email = client.Email,
                            Phone = client.Phone,
                        });
                    }
                }

            }
            catch (Exception)
            {
                throw new Exception("Error reading ISP router info!");
            }


            var model = new ActiveISPClientsFormModel
            {
                Clients = clients.OrderBy(c => c.FullName).ToArray(),
            };

            return model;
        }
        public async Task ActivateClientAsync(ActiveISPClientsFormModel model, string userId)
        {
            Client client = new()
            {
                Id = model.ClientId,
                FullName = model.ClientFullName,
                ActivationDate = model.ActivationDate,
                ExpiredDate = model.ExpiredDate,
                Comments = HttpUtility.HtmlEncode(model.Comments),
                UserId = Guid.Parse(userId),
                Address = model.Address,
                Email = model.Email,
                Phone = model.Phone,
            };
            Payment payment = new()
            {
                Id = Guid.NewGuid(),
                Client = client,
                Name = $"Initial payment",
                Fee = model.Fee * model.Months,
                InstallationFee = model.InstallationFee,
                Pending = model.Pending,
                Receipt = model.Receipt,
                FromDate = model.ActivationDate,
                ToDate = model.ExpiredDate,
                UserId = Guid.Parse(userId),
                ClientId = client.Id,
            };
            client.Payments.Add(payment);

            await _context.Clients.AddAsync(client);
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateISPRouterDataAsync(Guid clientId)
        {
            var client = await _context.Clients.FindAsync(clientId);

            GetClientsFromISPViewModel clientToUpdate = new()
            {
                Id = client!.Id,
                FullName = client.FullName,
                ActivationDate = client.ActivationDate.ToString(AppExpiredDateFormat),
                ExpiredDate = client.ExpiredDate.ToString(AppExpiredDateFormat),
            };

            var httpClient = _clientFactory.CreateClient("BillingServer");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetJWTAsync());

            var jsonContentOnPatch = JsonConvert.SerializeObject(clientToUpdate);

            var content = new StringContent(jsonContentOnPatch, Encoding.UTF8, "application/json");

            var result = await httpClient.PatchAsync(Path.Combine(clientsUrl,client.Id.ToString()), content);

            if (!result.IsSuccessStatusCode)
            {
                throw new Exception("Error updating ISP router info!");
            }
        }
        public async Task<string> GetJWTAsync()
        {

            var httpClient = _clientFactory.CreateClient("BillingServer");

            var loginModel = new
            {
                Username = _configuration.GetSection("JWTCredentials:Username").Value,
                Password = _configuration.GetSection("JWTCredentials:Password").Value,
                //Username = "admin",
                //Password = "admin",
            };
            var jsonContentOnPost = JsonConvert.SerializeObject(loginModel);
            var content = new StringContent(jsonContentOnPost, Encoding.UTF8, "application/json");

            var responseOnPost = await httpClient.PostAsync(loginUrl, content);

            if (!responseOnPost.IsSuccessStatusCode)
            {
                throw new Exception("Error reading ISP router info! Invalid credentials");
            }
            var token = await responseOnPost.Content.ReadAsStringAsync();
            return token;
        }
    }
}
