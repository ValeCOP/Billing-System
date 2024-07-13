namespace Billing_Systems_Tests.InvoiceServTests
{
    using Billing_System.Core.Contracts.Invoice;
    using Billing_System.Core.Contracts.Payments;
    using Billing_System.Core.Services.Invoice;
    using Billing_System.Core.Services.Payments;
    using Billing_System.Core.ViewModels.Invoice;
    using Billing_System.Data;
    using Billing_System.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using static Billing_Systems_Tests.Seed.DatabaseSeeder;


    [TestFixture]
    public class InvoiceServTests
    {
        private ApplicationUser _user;
        private BillingDbContext _dbContext;
        private IInvoiceService _invoiceService;
        private IPaymentsService _paymentsService;

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

            _paymentsService = new PaymentService(_dbContext);

            _invoiceService = new InvoiceService(_dbContext);


        }
        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
        }
        [Test]
        public async Task CreateInvoiceAsync_Test_01()
        {
            var payment = _dbContext.Payments.FirstOrDefaultAsync().GetAwaiter().GetResult();
            var invoice = new CreateInvoiceViewModel
            {
                MOL = "Initial2",
                UIN = "22",
                VATIN = "10",
                Recipient = "2022-01-01",
                Compiler = "2022-12-31",
                BankTransfer = false
            };
            // Act
            _invoiceService.CreateInvoiceAsync(invoice, payment.Id, _user.Id.ToString()).GetAwaiter().GetResult();

            Assert.AreEqual(2, _dbContext.Invoices.Count());

        }

        [Test]
        public async Task DeleteInvoiceAsync_Test_02()
        {
            Invoice invoice = new Invoice
            {
                MOL = "Initial2",
                UIN = "22",
                VATIN = "10",
                Recipient = "2022-01-01",
                Compiler = "2022-12-31",
                BankTransfer = false,
                ApplicationUser = _user,
                Cash = true,
                CreatedOn = DateTime.Now,
                InvoiceNumber = "48",
                UserId = _user.Id
            };
            _dbContext.Invoices.Add(invoice);
            _dbContext.SaveChanges();
            var invoiceToDelete = await _dbContext.Invoices.FirstOrDefaultAsync();

            Assert.IsNotNull(invoiceToDelete);

            var inviceCount = _dbContext.Invoices.Count();

            Assert.AreEqual(1, inviceCount);

            _invoiceService.DeleteInvoiceAsync(invoiceToDelete.Id).GetAwaiter().GetResult();

            Assert.AreEqual(0, _dbContext.Invoices.Count());
        }

        [Test]
        public async Task GetAllInvoicesAsync_Test_03()
        {

            var client = new Client()
            {
                Id = new Guid("1d315603-14bc-4f70-a832-ddcafdd4df22"),
                FullName = "Pesho Peshov",
                ActivationDate = new DateTime(2022, 1, 1),
                ExpiredDate = new DateTime(2023, 1, 1),
                ApplicationUser = _user
            };

            Payment payment = new Payment
            {
                Name = "Initial",
                Fee = 100,
                Pending = false,
                Receipt = false,
                FromDate = new DateTime(2022, 1, 1),
                ToDate = new DateTime(2023, 1, 1),
                ClientId = Guid.Parse("1d315603-14bc-4f70-a832-ddcafdd4df22"),
                Client = client
            };

            var invoices = new List<Invoice>
            {
            new Invoice
            {
                MOL = "Initial2",
                UIN = "22",
                VATIN = "10",
                Recipient = "Тест Тестов",
                Compiler = "Пешо Пешев",
                BankTransfer = false,
                ApplicationUser = _user,
                Cash = true,
                CreatedOn = DateTime.Now,
                InvoiceNumber = "48",
                UserId = _user.Id,
                Payment = payment,
            },
            new Invoice
            {
                MOL = "Initial3",
                UIN = "23",
                VATIN = "11",
                Recipient = "Тест1 Тестов1",
                Compiler = "Пешо1 Пешев1",
                BankTransfer = false,
                ApplicationUser = _user,
                Cash = true,
                CreatedOn = DateTime.Now,
                InvoiceNumber = "49",
                UserId = _user.Id,
                Payment = payment,
            },
            new Invoice
            {
                MOL = "Initial4",
                UIN = "20",
                VATIN = "09",
                Recipient = "Тест2 Тестов2",
                Compiler = "Пешо2 Пешев2",
                BankTransfer = false,
                ApplicationUser = _user,
                Cash = true,
                CreatedOn = DateTime.Now,
                InvoiceNumber = "50",
                UserId = _user.Id,
                Payment = payment,
            }};
            await _dbContext.Clients.AddAsync(client);
            await _dbContext.Payments.AddAsync(payment);
            await _dbContext.Invoices.AddRangeAsync(invoices);
            await _dbContext.SaveChangesAsync();

            var filter = new FilteredInvoiceViewModel()
            {
                Filter = "",
                OrderBy = "",
            };
            var models = await _invoiceService.GetAllInvoicesAsync(filter);

            Assert.AreEqual(2, models.Count);

            filter.Filter = "Initial4";
            models = await _invoiceService.GetAllInvoicesAsync(filter);
            Assert.AreEqual(1, models.Count);

            filter.Filter = "itial";
            models = await _invoiceService.GetAllInvoicesAsync(filter);
            Assert.AreEqual(2, models.Count);

            filter.OrderBy = "CreatedOnDesc";
            models = await _invoiceService.GetAllInvoicesAsync(filter);
            Assert.That(models.First().InvoiceNumber, Is.EqualTo("50"));

            filter.OrderBy = "CreatedOn";
            models = await _invoiceService.GetAllInvoicesAsync(filter);
            Assert.That(models.First().InvoiceNumber, Is.EqualTo("48"));
        }

        [Test]
        public async Task GetInvoiceByPaymentIdAsync_Test_04()
        {
            Client client = new Client()
            {
                Id = new Guid("1d315603-14bc-4f70-a832-ddcafdd4d777"),
                FullName = "Pesho Peshov",
                ActivationDate = new DateTime(2022, 1, 1),
                ExpiredDate = new DateTime(2023, 1, 1),
                ApplicationUser = _user
            };
            Payment payment = new Payment
            {
                Id = Guid.Parse("1d315603-14bc-4f70-a832-ddcafdd4df22"),
                Name = "Initial",
                Fee = 100,
                Pending = false,
                Receipt = false,
                FromDate = new DateTime(2022, 1, 1),
                ToDate = new DateTime(2023, 1, 1),
                ClientId = Guid.Parse("1d315603-14bc-4f70-a832-ddcafdd4d777"),
                Client = client
            };
            var model = new Invoice
            {
                MOL = "Initial4",
                UIN = "22",
                VATIN = "10",
                Recipient = "Тест Тестов",
                Compiler = "Пешо Пешев",
                BankTransfer = false,
                ApplicationUser = _user,
                Cash = true,
                CreatedOn = DateTime.Now,
                InvoiceNumber = "50",
                UserId = _user.Id,
                Payment = payment,
                PaymentId = payment.Id
            };
            _dbContext.Clients.Add(client);
            _dbContext.Invoices.Add(model);
            _dbContext.Payments.Add(payment);
            _dbContext.SaveChanges();
            // Act
          
            var invoiceFromDb = _invoiceService.GetInvoiceByPaymentIdAsync(payment.Id).GetAwaiter().GetResult();

            Assert.IsNotNull(invoiceFromDb);
            Assert.AreEqual("Initial4", invoiceFromDb.MOL);
            Assert.AreEqual("22", invoiceFromDb.UIN);
            Assert.AreEqual("10", invoiceFromDb.VATIN);
            Assert.AreEqual("Тест Тестов", invoiceFromDb.Recipient);
            Assert.AreEqual("Пешо Пешев", invoiceFromDb.Compiler);
            Assert.AreEqual(false, invoiceFromDb.BankTransfer);
        }

        [Test]
        //GetInvoiceForPrintAsync
        public async Task GetInvoiceForPrintAsync_Test_05()
        {
            Client client = new Client()
            {
                Id = new Guid("1d315603-14bc-4f70-a832-ddcafdd4d797"),
                FullName = "Pesho Peshov",
                ActivationDate = new DateTime(2022, 1, 1),
                ExpiredDate = new DateTime(2023, 1, 1),
                ApplicationUser = _user
            };
            Payment payment = new Payment
            {
                Id = Guid.Parse("1d315603-14bc-4f70-a832-ddcafdd4df82"),
                Name = "Initial",
                Fee = 100,
                Pending = false,
                Receipt = false,
                FromDate = new DateTime(2022, 1, 1),
                ToDate = new DateTime(2023, 1, 1),
                ClientId = Guid.Parse("1d315603-14bc-4f70-a832-ddcafdd4d797"),
                Client = client
            };
            var model = new Invoice
            {
                MOL = "Initial4",
                UIN = "22",
                VATIN = "10",
                Recipient = "Тест Тестов",
                Compiler = "Пешо Пешев",
                BankTransfer = false,
                ApplicationUser = _user,
                Cash = true,
                CreatedOn = DateTime.Now,
                InvoiceNumber = "50",
                UserId = _user.Id,
                Payment = payment,
                PaymentId = payment.Id
            };
            _dbContext.Clients.Add(client);
            _dbContext.Invoices.Add(model);
            _dbContext.Payments.Add(payment);
            _dbContext.SaveChanges();
            // Act
            var invoice = _dbContext.Invoices.FirstOrDefaultAsync().GetAwaiter().GetResult();

            var invoiceFromDb = _invoiceService.GetInvoiceForPrintAsync(invoice.Id).GetAwaiter().GetResult();

            Assert.IsNotNull(invoiceFromDb);
            Assert.AreEqual("Initial4", invoiceFromDb.MOL);
            Assert.AreEqual("22", invoiceFromDb.UIN);
            Assert.AreEqual("10", invoiceFromDb.VATIN);
            Assert.AreEqual("Тест Тестов", invoiceFromDb.Recipient);
            Assert.AreEqual(false, invoiceFromDb.BankTransfer);
        }

    }
}
