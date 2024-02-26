namespace Billing_System.Core.Services.Home
{
    using Billing_System.Core.Contracts.Home;
    using Billing_System.Core.ViewModels.Clients;
    using Billing_System.Core.ViewModels.Payments;
    using Billing_System.Data;
    using Billing_System.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using static Utilities.ValidationConstants.ValidationConstants;


    public class HomeService : IHomeService
    {
        private readonly BillingDbContext _context;
        private readonly HttpClient _httpClient;

        public HomeService(BillingDbContext dbContext, HttpClient httpClient)
        {
            _context = dbContext;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7231");
        }
        public async Task<ActiveISPClientsFormModel> ImportISPRouterDataAsync()
        {
            var clients = new List<ClientsFromISPModel>();

                try
                {
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

            var json = JsonConvert.SerializeObject(clientToUpdate);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var result =  await _httpClient.PatchAsync("/Clients/" + client.Id.ToString(), data);

            if (!result.IsSuccessStatusCode)
            {
                throw new Exception("Error updating ISP router info!");
            }
        }
    }
}
