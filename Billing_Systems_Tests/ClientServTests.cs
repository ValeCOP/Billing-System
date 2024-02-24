namespace Billing_Systems_Tests
{
    using Billing_System.Core.Contracts.Clients;
    using Billing_System.Core.Services.Clients;
    using Billing_System.Data;
    using Microsoft.EntityFrameworkCore;
    using static Billing_Systems_Tests.Seed.DatabaseSeeder;


    [TestFixture]
    public class ClientServTests
    {
        private BillingDbContext _dbContext;
        private IClientsService _clientService;

        [SetUp]
        public void Setup()
        {
            DbContextOptions<BillingDbContext> dbOptions = new DbContextOptionsBuilder<BillingDbContext>()
               .UseInMemoryDatabase("BillingInMemory" + Guid.NewGuid().ToString())
               .Options;

            _dbContext = new BillingDbContext(dbOptions);

            _dbContext.Database.EnsureCreated();

            _clientService = new ClientService(_dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
        }


        [Test]
        public void GetAllClients_Test_01()
        {
            // Act
            var clients = _clientService.GetAllClientsAsync("", "").GetAwaiter().GetResult();

            // Assert
            Assert.That(clients.Count, Is.EqualTo(2));
        }
        [Test]
        public void GetClientBySearchingString_Test_02()
        {
            // Act
            var clients = _clientService.GetAllClientsAsync("", "Валентин Иванов Василев").GetAwaiter().GetResult();

            // Assert
            Assert.That(clients.Count, Is.EqualTo(1));
            Assert.That(clients.FirstOrDefault().FullName, Is.EqualTo("Валентин Иванов Василев"));
        }

        [Test]
        public void GetClientsByOrdering_Test_03()
        {
            // Act
            var clients = _clientService.GetAllClientsAsync("FullName", "").GetAwaiter().GetResult();

            // Assert
            Assert.That(clients.Count, Is.EqualTo(2));
            Assert.That(clients.First().FullName, Is.EqualTo("Авксентия Мариус Койнарска"));
        }
        [Test]
        public void DeleteClient_Test_04()
        {
            // Arrange
            var client = _dbContext.Clients.FirstOrDefaultAsync().GetAwaiter().GetResult();
            // Act
            _clientService.DeleteClientAsync(client.Id).GetAwaiter().GetResult();
            var clients = _clientService.GetAllClientsAsync("", "").GetAwaiter().GetResult();
            // Assert
            Assert.That(clients.Count, Is.EqualTo(1));
        }
        [Test]
        public void GetClientDetails_Test_05()
        {
            // Arrange
            var client = _dbContext.Clients.FirstOrDefaultAsync().GetAwaiter().GetResult();
            // Act
            var clientDetails = _clientService.GetClientDetailsAsync(client.Id).GetAwaiter().GetResult();
            // Assert
            Assert.That(clientDetails.ClientId, Is.EqualTo(client.Id));
            Assert.That(clientDetails.FullName, Is.EqualTo(client.FullName));
        }
    }
}
