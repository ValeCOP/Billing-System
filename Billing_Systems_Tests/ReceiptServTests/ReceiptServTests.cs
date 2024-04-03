namespace Billing_Systems_Tests.ReceiptServTests
{
    using Billing_System.Core.Contracts.Receipt;
    using Billing_System.Core.Services.Receipt;
    using Billing_System.Data;
    using Billing_System.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Text;

    [TestFixture]
    public class ReceiptServTests
    {
        private BillingDbContext _dbContext;
        private IReceiptService _receiptService;

        [OneTimeSetUp]
        public void Setup()
        {
            DbContextOptions<BillingDbContext> dbOptions = new DbContextOptionsBuilder<BillingDbContext>()
              .UseInMemoryDatabase("BillingInMemory" + Guid.NewGuid().ToString())
              .Options;
            _dbContext = new BillingDbContext(dbOptions);
            _dbContext.Database.EnsureCreated();
            _receiptService = new ReceiptService(_dbContext);

        }
        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.ChangeTracker.Clear();

            string filePath = Directory.GetCurrentDirectory();
            File.Delete(filePath + @"\ReceiptPrint.inp");

        }
        //CreateReceiptAsync
        [Test]
        public async Task CreateReceiptAsync_Test_01()
        {
            // Arrange
            await SeedData();
            var payment = await _dbContext.Payments
                .FirstOrDefaultAsync(p => p.Id == Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb964a"));
            // Act
            await _receiptService.CreateReceiptAsync(payment.Id);
            // Assert
            string filePath = Directory.GetCurrentDirectory();
            Assert.IsTrue(File.Exists(filePath + @"\ReceiptPrint.inp"));
            string[] lines = File.ReadAllLines(filePath + @"\ReceiptPrint.inp");
            

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("P,1,______,_,__;Клиент:;");
            stringBuilder.AppendLine("P,1,______,_,__;Вал Вас;");
            stringBuilder.AppendLine("P,1,______,_,__;Пуснат до:;");
            stringBuilder.AppendLine($"P,1,______,_,__;{payment.ToDate};");
            stringBuilder.AppendLine("S,1,______,_,__;;22;1.000;1;1;2;0;0;");
            stringBuilder.AppendLine("T,1,______,_,__;");

            string[] expected = stringBuilder.ToString().Split(Environment.NewLine);

            Assert.AreEqual(expected, lines);

            File.Delete(filePath + @"\ReceiptPrint.inp");
            Assert.IsFalse(File.Exists(filePath + @"\ReceiptPrint.inp"));
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
