namespace Billing_System.Core.Services.Home
{
    using Billing_System.Core.Contracts.Home;
    using Billing_System.Core.ViewModels.Clients;
    using Billing_System.Core.ViewModels.Payments;
    using Billing_System.Data;
    using Billing_System.Data.Entities;
    using Castle.Core.Configuration;
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
        private readonly HttpClient _httpClient;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;

        public HomeService(BillingDbContext dbContext, HttpClient httpClient, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _configuration = configuration;
            _context = dbContext;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7231");
        }
        public async Task<ActiveISPClientsFormModel> ImportISPRouterDataAsync()
        {
            var clients = new List<ClientsFromISPModel>();

            var token = await GetJWTAsync();
            
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await _httpClient.GetAsync("/Clients");

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
            catch (Exception ex)
            {
                throw new Exception("Error reading ISP router info!");
            }

            var paymentDetails = await _context.Payments.Select(x => new PaymentDetailsView
            {
                TotalValue = x.Fee + x.InstallationFee,
                PendingValue = x.Pending ? x.Fee + x.InstallationFee : 0,
                ReceiptValue = x.Receipt ? x.Fee + x.InstallationFee : 0,
            }).ToListAsync();

            var model = new ActiveISPClientsFormModel
            {
                Clients = clients.OrderBy(c => c.FullName).ToArray(),
                PaymentDetails = paymentDetails,
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
                Fee = model.Fee,
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

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetJWTAsync());

            var jsonContentOnPatch = JsonConvert.SerializeObject(clientToUpdate);

            var content = new StringContent(jsonContentOnPatch, Encoding.UTF8, "application/json");

            var result = await _httpClient.PatchAsync("/Clients/" + client.Id.ToString(), content);

            if (!result.IsSuccessStatusCode)
            {
                throw new Exception("Error updating ISP router info!");
            }
        }
        public async Task<string> GetJWTAsync()
        {
            var apiUrl = "https://localhost:7231/Login/login";

            var loginModel = new
            {
                //Username = _configuration.GetSection("JWTCredentials:Username").Value,
                //Password = _configuration.GetSection("JWTCredentials:Password").Value,
                Username = "admin", 
                Password = "admin",
            };
            var jsonContentOnPost = JsonConvert.SerializeObject(loginModel);
            var content = new StringContent(jsonContentOnPost, Encoding.UTF8, "application/json");

            var responseOnPost = await _httpClient.PostAsync(apiUrl, content);

            if (!responseOnPost.IsSuccessStatusCode)
            {
                throw new Exception("Error reading ISP router info! Invalid credentials");
            }
            var token = await responseOnPost.Content.ReadAsStringAsync();
            return token;
        }
    }
}
