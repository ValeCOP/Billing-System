namespace ServiceTests
{
    using Billing_System.Core.Contracts.Home;
    using Billing_System.Core.Contracts.Payments;
    using Billing_System.Core.Contracts.Receipt;
    using Billing_System.Core.Services.Home;
    using Billing_System.Core.Services.Payments;
    using Billing_System.Core.Services.Receipt;
    using Billing_System.Core.ViewModels.Payments;
    using Billing_System.Data;
    using Billing_System.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using static ServiceTests.DatabaseSeeder;


    [TestFixture]
    public class Billing_System_TestPaymentService
    {
        private ApplicationUser _user;
        private BillingDbContext _dbContext;
        private IHomeService _homeService;
        private IReceiptService _receiptService;
        private IPaymentsService _paymentService;

        [OneTimeSetUp]
        public void Setup()
        {
            DbContextOptions<BillingDbContext> dbOptions = new DbContextOptionsBuilder<BillingDbContext>()
              .UseInMemoryDatabase("BillingInMemory" + Guid.NewGuid().ToString())
              .Options;
            _dbContext = new BillingDbContext(dbOptions);

            _dbContext.Database.EnsureCreated();

            DatabaseSeeder.SeedDatabase(_dbContext);

            _user = _dbContext.Users.FirstOrDefaultAsync().GetAwaiter().GetResult()!;
            _receiptService = new ReceiptService(_dbContext);
            _homeService = new HomeService(_dbContext);
            _paymentService = new PaymentService(_dbContext, _receiptService, _homeService);


        }
        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task AddPayment_Test_01()
        {
            // Arrange
            var payment = new AddPaymentView
            {
                Name = "Initial payment",
                Fee = 22,
                Pending = false,
                Receipt = true,
                FromDate = "2022-01-01",
                ToDate = "2022-12-31",
                ClientId = Guid.Parse("d11111e7-0b15-4065-af56-ad3b5efdc936")
            };
            Client client = new Client
            {
                Id = payment.ClientId,
                FullName = "Test Client",
                ActivationDate = DateTime.Now,
                ExpiredDate = DateTime.Now,
                Address = "Test Address",
            };

            await _dbContext.Clients.AddAsync(client);

            // Act
            await _paymentService.AddPaymentAsync(payment, _user.Id);

            // Assert
            var paymentFromDb = await _dbContext.Payments.FirstOrDefaultAsync();

            Assert.AreEqual(payment.Name, paymentFromDb.Name);
            Assert.AreEqual(payment.Fee, paymentFromDb.Fee);
            Assert.AreEqual(payment.FromDate, paymentFromDb.FromDate.ToString("yyyy-MM-dd"));
            Assert.AreEqual(payment.ToDate, paymentFromDb.ToDate.ToString("yyyy-MM-dd"));

        }
    }
}
