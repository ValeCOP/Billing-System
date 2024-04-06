namespace Billing_Systems_Tests.ClientServTests
{
    using Billing_System.Core.Contracts.Clients;
    using Billing_System.Core.Services.Clients;
    using Billing_System.Core.ViewModels.Clients;
    using Billing_System.Data;
    using Microsoft.EntityFrameworkCore;


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
            FilteredClientsViewModel model = new FilteredClientsViewModel()
            {
                Filter = "",
                OrderBy = ""
            };
            // Act
            var clients = _clientService.GetAllClientsAsync(model).GetAwaiter().GetResult();

            // Assert
            Assert.That(clients.Count, Is.EqualTo(1));
        }
        [Test]
        public void GetClientBySearchingString_Test_02()
        {
            FilteredClientsViewModel model = new FilteredClientsViewModel()
            {
                Filter = "Валентин Иванов Василев",
                OrderBy = ""
            };
            // Act
            var clients = _clientService.GetAllClientsAsync(model).GetAwaiter().GetResult();

            // Assert
            Assert.That(clients.Count, Is.EqualTo(1));
            Assert.That(clients.FirstOrDefault().FullName, Is.EqualTo("Валентин Иванов Василев"));
        }

        [Test]
        public void GetClientsByOrdering_Test_03()
        {
            FilteredClientsViewModel model = new FilteredClientsViewModel()
            {
                Filter = "",
                OrderBy = "FullName"
            };
            // Act
            var clients = _clientService.GetAllClientsAsync(model).GetAwaiter().GetResult();

            // Assert
            Assert.That(clients.Count, Is.EqualTo(1));
            Assert.That(clients.First().FullName, Is.EqualTo("Валентин Иванов Василев"));
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

        [Test]
        public void GetClientShort_Test_06()
        {
            // Act
            var clients = _clientService.GetClientShortAsync().GetAwaiter().GetResult();
            // Assert
            Assert.That(clients.Count, Is.EqualTo(1));
        }

        [Test]
        public void DeleteClient_Test_07()
        {
            // Arrange
            var client = _dbContext.Clients.FirstOrDefaultAsync().GetAwaiter().GetResult();
            // Act
            _clientService.DeleteClientAsync(client.Id).GetAwaiter().GetResult();
            // Assert
            Assert.That(_dbContext.Clients.Count(), Is.EqualTo(0));
        }
    }
}
