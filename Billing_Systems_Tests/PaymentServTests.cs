namespace Billing_Systems_Tests
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
    using System.Net.Http;
    using static Billing_Systems_Tests.Seed.DatabaseSeeder;


    [TestFixture]
    public class Billing_System_TestPaymentService
    {
        private ApplicationUser _user;
        private BillingDbContext _dbContext;
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

            _user = _dbContext.Users.FirstOrDefaultAsync().GetAwaiter().GetResult()!;

            _receiptService = new ReceiptService(_dbContext);
            _paymentService = new PaymentService(_dbContext, _receiptService);


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
                Name = "Initial2",
                Fee = 22,
                Pending = false,
                Receipt = true,
                FromDate = "2022-01-01",
                ToDate = "2022-12-31",
                ClientId = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb964a")
            };


            // Act
           
            await _paymentService.AddPaymentAsync(payment, _user.Id);
            // Assert
            var paymentFromDb = await _dbContext.Payments.FirstOrDefaultAsync(
                p => p.ClientId == Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb964a") &&
                p.Name == "Initial2");

            Assert.AreEqual(payment.Name, paymentFromDb.Name);
            Assert.AreEqual(payment.Fee, paymentFromDb.Fee);
            Assert.AreEqual(payment.FromDate, paymentFromDb.FromDate.ToString("yyyy-MM-dd"));
            Assert.AreEqual(payment.ToDate, paymentFromDb.ToDate.ToString("yyyy-MM-dd"));

        }
    }
}
