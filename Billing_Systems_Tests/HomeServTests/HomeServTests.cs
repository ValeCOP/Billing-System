namespace Billing_Systems_Tests.HomeServTests
{
    using Billing_System.Core.Contracts.Home;
    using Billing_System.Core.Services.Home;
    using Billing_System.Core.ViewModels.Clients;
    using Billing_System.Data;
    using Billing_System.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Moq;
    using Moq.Protected;
    using System.Net.Http;
    using System.Web;
    using static Billing_Systems_Tests.Seed.DatabaseSeeder;

    [TestFixture]

    public class Billing_System_TestsHomeService
    {
        private ApplicationUser _user;
        private BillingDbContext _dbContext;
        private IHomeService _homeService;
        private IConfiguration _configuration;

        [OneTimeSetUp]
        public void Setup()
        {
            DbContextOptions<BillingDbContext> dbOptions = new DbContextOptionsBuilder<BillingDbContext>()
               .UseInMemoryDatabase("BillingInMemory" + Guid.NewGuid().ToString())
               .Options;

            _dbContext = new BillingDbContext(dbOptions);
            _dbContext.Database.EnsureCreated();
            SeedDatabase(_dbContext);

            var inMemorySettings = new Dictionary<string, string>
            {
                {"ConnectionStrings:DefaultConnection",
                    "Server=OFFICE\\SQLEXPRESS;Database=BillingSystem_Test;Integrated Security=True;Trust Server Certificate = true"  }
            };
            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            HttpResponseMessage result = new HttpResponseMessage();
            result.Content = new StringContent(
                "[{\"id\":\"1d315603-14bc-4f70-a832-ddcafdd4df21\"," +
                "\"fullName\":\"Александър Димитров Белчински\"," +
                "\"activationDate\":\"2024-03-23\"," +
                "\"expiredDate\":\"2024-06-01\"," +
                "\"address\":\"Address_729\"," +
                "\"email\":\"email_93531020@gmail.com\"," +
                "\"phone\":\"08821202757\"}]");

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
                    .Protected()
                    .Setup<Task<HttpResponseMessage>>(
                        "SendAsync",
                        ItExpr.IsAny<HttpRequestMessage>(),
                        ItExpr.IsAny<CancellationToken>()
                    )
                    .ReturnsAsync(result)
                    .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object);

            var mockHttpClientFactory = new Mock<IHttpClientFactory>();

            mockHttpClientFactory.Setup(_ => _.CreateClient("BillingServer")).Returns(httpClient);

            _user = _dbContext.Users.FirstOrDefaultAsync().GetAwaiter().GetResult()!;

            _homeService = new HomeService(_dbContext, mockHttpClientFactory.Object, _configuration);

        }
        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task ActivateClientAsyncTest_01()
        {
            ICollection<ClientsFromISPModel> clients = new List<ClientsFromISPModel>();

            ClientsFromISPModel client = new()
            {
                Id = Guid.NewGuid(),
                FullName = "Вал Ив Василев",
                ActivationDate = DateTime.Now.Date,
                ExpiredDate = DateTime.Now.Date
            };
            clients.Add(client);

            ActiveISPClientsFormModel activateClientView = new()
            {
                ClientId = Guid.Parse("d11111e7-0b15-4065-af56-ad3b5efdc936"),
                ClientFullName = "Тест Тестин Тестов",
                Fee = 22,
                InstallationFee = 0,
                Comments = "Test comment",
                Pending = false,
                Receipt = false,
                ActivationDate = DateTime.Now.Date,
                ExpiredDate = DateTime.Now.Date,
                Clients = clients,
            };

            await _homeService.ActivateClientAsync(activateClientView, _user.Id.ToString());

            var clientFromDb = await _dbContext.Clients.FirstOrDefaultAsync(x => x.Id == activateClientView.ClientId);

            Assert.That(clientFromDb!.Id, Is.EqualTo(activateClientView.ClientId));
            Assert.That(clientFromDb!.FullName, Is.EqualTo(activateClientView.ClientFullName));
            Assert.That(clientFromDb!.ActivationDate, Is.EqualTo(activateClientView.ActivationDate));
            Assert.That(clientFromDb!.ExpiredDate, Is.EqualTo(activateClientView.ExpiredDate));

        }

        [Test]
        public async Task GetActiveClientsAsyncTest_02()
        {
            var model = await _homeService.ImportISPRouterDataAsync();
            Assert.That(model.Clients.Count(), Is.EqualTo(1));
            Assert.That(model.Clients.FirstOrDefault().FullName, Is.EqualTo("Александър Димитров Белчински"));
        }

        [Test]
        public async Task UpdateISPRouterDataAsyncTest_04()
        {

            ICollection<ClientsFromISPModel> clients = new List<ClientsFromISPModel>();
            var userId = _user.Id.ToString();
            ClientsFromISPModel clientISP = new()
            {
                Id = Guid.NewGuid(),
                FullName = "Вал Ив Василев",
                ActivationDate = DateTime.Now.Date,
                ExpiredDate = DateTime.Now.Date
            };
            clients.Add(clientISP);

            ActiveISPClientsFormModel model = new()
            {
                ClientId = Guid.Parse("d11111e7-0b15-4065-af56-ad3b5efdc666"),
                ClientFullName = "Тест Тестин Тестов",
                Fee = 22,
                InstallationFee = 0,
                Comments = "Test comment",
                Pending = false,
                Receipt = false,
                ActivationDate = DateTime.Now.Date,
                ExpiredDate = DateTime.Now.Date,
                Clients = clients,
            };
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


            await _dbContext.Clients.AddAsync(client);
            await _dbContext.Payments.AddAsync(payment);
            await _dbContext.SaveChangesAsync();

            var clientsCount = await _dbContext.Clients.CountAsync();



            Guid id = Guid.Parse("d11111e7-0b15-4065-af56-ad3b5efdc666");
            await _homeService.UpdateISPRouterDataAsync(id);
            var cl = await _dbContext.Clients.FirstOrDefaultAsync(x => x.Id == id);
            Assert.That(client!.FullName, Is.EqualTo("Тест Тестин Тестов"));


        }
    }
}
