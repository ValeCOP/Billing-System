namespace Billing_Systems_Tests
{
    using Billing_System.Core.Contracts.Home;
    using Billing_System.Core.Contracts.Payments;
    using Billing_System.Core.Contracts.Receipt;
    using Billing_System.Core.Services.Home;
    using Billing_System.Core.Services.Payments;
    using Billing_System.Core.Services.Receipt;
    using Billing_System.Core.ViewModels.Clients;
    using Billing_System.Core.ViewModels.Payments;
    using Billing_System.Data;
    using Billing_System.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using static Billing_Systems_Tests.Seed.DatabaseSeeder;

    [TestFixture]

    public class Billing_System_TestsHomeService
    {
        private ApplicationUser _user;
        private BillingDbContext _dbContext;
        private IHomeService _homeService;
        private  HttpClient _httpClient;


        [OneTimeSetUp]
        public void Setup()
        {
            DbContextOptions<BillingDbContext> dbOptions = new DbContextOptionsBuilder<BillingDbContext>()
               .UseInMemoryDatabase("BillingInMemory" + Guid.NewGuid().ToString())
               .Options;

            _dbContext = new BillingDbContext(dbOptions);

            _dbContext.Database.EnsureCreated();
            SeedDatabase(_dbContext);

            _user = _dbContext.Users.FirstOrDefaultAsync().GetAwaiter().GetResult()!;

            _httpClient  = new HttpClient();
            _homeService = new HomeService(_dbContext, _httpClient);

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
            ICollection<PaymentDetailsView> payments = new List<PaymentDetailsView>();

            ClientsFromISPModel client = new()
            {
                Id = Guid.NewGuid(),
                FullName = "Вал Ив Василев",
                ActivationDate = DateTime.Now.Date,
                ExpiredDate = DateTime.Now.Date
            };
            clients.Add(client);

            PaymentDetailsView payment = new()
            {
                TotalValue = 22,
                PendingValue = 22,
                ReceiptValue = 22,
            };
            payments.Add(payment);

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
                PaymentDetails = payments,
            };

            await _homeService.ActivateClientAsync(activateClientView, _user.Id.ToString());

            var clientFromDb = await _dbContext.Clients.FirstOrDefaultAsync(x => x.Id == activateClientView.ClientId);

            Assert.That(clientFromDb!.Id, Is.EqualTo(activateClientView.ClientId));
            Assert.That(clientFromDb!.FullName, Is.EqualTo(activateClientView.ClientFullName));
            Assert.That(clientFromDb!.ActivationDate, Is.EqualTo(activateClientView.ActivationDate));
            Assert.That(clientFromDb!.ExpiredDate, Is.EqualTo(activateClientView.ExpiredDate));

        }
    }
}
