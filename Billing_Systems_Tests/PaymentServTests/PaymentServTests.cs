namespace Billing_Systems_Tests.PaymentServTests
{
    using Billing_System.Core.Contracts.Payments;
    using Billing_System.Core.Services.Payments;
    using Billing_System.Core.ViewModels.Payments;
    using Billing_System.Data;
    using Billing_System.Data.Entities;
    using Microsoft.EntityFrameworkCore;


    [TestFixture]
    public class Billing_System_TestPaymentService
    {
        private ApplicationUser _user;
        private BillingDbContext _dbContext;
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

            _paymentService = new PaymentService(_dbContext);


        }
        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.ChangeTracker.Clear();
        }

        [Test]
        public async Task AddPayment_Test_01()
        {
            // Arrange
            var payment = new AddPaymentViewModel
            {
                Name = "Initial2",
                Fee = 22,
                Months = 10,
                Pending = false,
                Receipt = true,
                FromDate = "2022-01-01",
                ToDate = "2022-12-31",
                ClId = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb964a")
            };
            // Act

            var paymentFromDb = await _paymentService.AddPaymentAsync(payment, _user.Id);

            // Assert
           

            Assert.AreEqual(payment.Name, paymentFromDb.Name);
            Assert.AreEqual(payment.Fee * payment.Months, paymentFromDb.Fee);
            Assert.AreEqual(payment.FromDate, paymentFromDb.FromDate.ToString("yyyy-MM-dd"));
            Assert.AreEqual(payment.ToDate, paymentFromDb.ToDate.ToString("yyyy-MM-dd"));

        }

        //EditPaymentAsync
        [Test]
        public async Task EditPayment_Test_02()
        {
            // Arrange
            await SeedData();


            var editModel = new EditPaymentViewModel
            {
                Id = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb964a"),
                Name = "Edited Name",
                Fee = 50,
                Pending = false,
                FromDate = DateTime.Parse("2024-01-01"),
                ToDate = DateTime.Parse("2024-12-31"),
                ClId = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb9333"),
                UserId = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb9666")
            };
            // Act

            
            await _paymentService.EditPaymentAsync(editModel, editModel.Id);
            var editedPayment = await _dbContext.Payments.FirstOrDefaultAsync(p => p.Id == editModel.Id);
            // Assert
            Assert.IsNotNull(editedPayment);
            Assert.AreEqual(editModel.Name, editedPayment.Name);
            Assert.AreEqual(editModel.Fee, editedPayment.Fee);
            Assert.AreEqual(editModel.FromDate, editedPayment.FromDate);
            Assert.AreEqual(editModel.ToDate, editedPayment.ToDate);

        }

        [Test]
        public async Task GetPaymentForEdit_Test_03()
        {
            // Arrange
            await SeedData();

            var paymentId = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb964a");
            // Act
            EditPaymentViewModel paymentForEdit = await _paymentService.GetPaymentForEditAsync(paymentId);
            // Assert
            Assert.IsNotNull(paymentForEdit);
            Assert.AreEqual(paymentForEdit.Name, "Initial2 - edited");
        }

        [Test]
        public async Task GetPaymentDetails_Test_04()
        {
            // Arrange
            await SeedData();

            var paymentId = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb964a");
            // Act
            var paymentDetails = await _paymentService.GetPaymentDetailsAsync(paymentId);
            // Assert
            Assert.IsNotNull(paymentDetails);
            Assert.AreEqual(paymentDetails.Name, "Initial2");
        }
        
        [Test]
        public async Task DeletePayment_Test_05()
        {
            // Arrange
            await SeedData();

            var paymentId = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb964a");
            // Act
            await _paymentService.DeletePaymentAsync(paymentId);
            var deletedPayment = await _dbContext.Payments.FirstOrDefaultAsync(p => p.Id == paymentId);
            // Assert
            Assert.IsNull(deletedPayment);
        }

        [Test]
        public async Task GetPaymentIdByClientId_Test_06()
        {
            // Arrange
            await SeedData();

            var clientId = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb9333");
            // Act
            var paymentId = _paymentService.GetPaymentIdByClientId(clientId);
            // Assert
            Assert.AreEqual(paymentId, Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb964a"));
        }

        [Test]
        public async Task GetPaymentByIdAsync_Test_07()
        {
            // Arrange
            await SeedData();

            var paymentId = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb964a");
            // Act
            var payment = await _paymentService.GetPaymentByIdAsync(paymentId);
            // Assert
            Assert.IsNotNull(payment);
            Assert.AreEqual(payment.Name, "Initial2");
        }


        private async Task SeedData()
        {
            var user = new ApplicationUser()
            {
                Id = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb9666"),
                UserName = "Pesho",
                NormalizedUserName = "PESHO",
                Email = "pesho@agents.com",
                NormalizedEmail = "PESHO@AGENTS.COM",
                EmailConfirmed = true,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "caf271d7-0ba7-4ab1-8d8d-6d0e3711c27d",
                SecurityStamp = "ca32c787-626e-4234-a4e4-8c94d85a2b1c",
                TwoFactorEnabled = false,
            };
            var client = new Client
            {
                Id = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb9333"),
                FullName = "Вал Вас",
                Address = "26",
                Phone = "0888888882",
                Email = "admin@gmail.com",
                ExpiredDate = DateTime.Parse("2022-12-31"),
                ActivationDate = DateTime.Parse("2022-01-01"),
                UserId = user.Id
            };
            var payment = new Payment
            {
                Id = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb964a"),
                Name = "Initial2",
                Fee = 22,
                Pending = false,
                FromDate = DateTime.Parse("2022-01-01"),
                ToDate = DateTime.Parse("2022-12-31"),
                ClientId = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb9333"),
                UserId = user.Id,
            };
            await _dbContext.Users.AddAsync(user);
            await _dbContext.Clients.AddAsync(client);
            await _dbContext.Payments.AddAsync(payment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
