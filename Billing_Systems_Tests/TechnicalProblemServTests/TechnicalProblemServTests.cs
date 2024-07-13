namespace Billing_Systems_Tests.TechnicalProblemServTests
{
    using Billing_System.Core.Contracts.Home;
    using Billing_System.Core.Contracts.TechnicalProblemService;
    using Billing_System.Core.Services.TechnicalProblem;
    using Billing_System.Core.ViewModels.TechnicalProblem;
    using Billing_System.Data;
    using Billing_System.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using static Billing_System.Utilities.ValidationConstants.ValidationConstants;

    [TestFixture]
    public class TechnicalProblemServTests
    {
        private BillingDbContext _dbContext;
        private ITechnicalProblemService _technicalProblemService;
        private IHttpClientFactory _clientFactory;
        private IHomeService _homeService;
        private ApplicationUser _user;



        [SetUp]
        public void Setup()
        {
            DbContextOptions<BillingDbContext> dbOptions = new DbContextOptionsBuilder<BillingDbContext>()
              .UseInMemoryDatabase("BillingInMemory" + Guid.NewGuid().ToString())
              .Options;

            _dbContext = new BillingDbContext(dbOptions);
            _dbContext.Database.EnsureCreated();
            _technicalProblemService = new TechnicalProblemService(_clientFactory, _dbContext, _homeService);
            _user = _dbContext.Users.FirstOrDefaultAsync().GetAwaiter().GetResult()!;

        }
        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.ChangeTracker.Clear();
        }
        [Test]
        public async Task AddTechnicalProblem_Test_01()
        {
            //Arrange
            var model = new AddTechProblemView
            {
                Description = "Test",
                ClientName = "Test",
                RegisterProblemUserId = _user.Id,
                ClientPhone = "Test",
                ClientAddress = "Test",
                ClientEmail = "Test"
            };
            //Act
            await _technicalProblemService.AddTechnicalProblemAsync(model);
            //Assert
            Assert.AreEqual(1, _dbContext.TechnicalProblems.Count());
        }
        
        [Test]
        public async Task GetTechnicalProblems_Test_02()
        {
            //Arrange
            await SeedData();

            var model = new FilteredTechProblemsViewModel
            {
                Filter = "Test",
                OrderBy = "Test"
            };
            //Act
            var result = await _technicalProblemService.GetTechnicalProblemsAsync(model);
            //Assert
            Assert.AreEqual(3, result.Count);

            model.Filter = "Test2";
            result = await _technicalProblemService.GetTechnicalProblemsAsync(model);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Test2", result.First().ClientName);

            model.OrderBy = "FullName";
            result = await _technicalProblemService.GetTechnicalProblemsAsync(model);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Test2", result.First().ClientName);

            model.OrderBy = "FullNameDesc";
            model.Filter = "Test";
            result = await _technicalProblemService.GetTechnicalProblemsAsync(model);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("Test3", result.First().ClientName);

            model.OrderBy = "RegisteredOn";
            model.Filter = "Test";
            result = await _technicalProblemService.GetTechnicalProblemsAsync(model);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("Test", result.First().ClientName);

            model.OrderBy = "RegisteredOnDesc";
            model.Filter = "Test";
            result = await _technicalProblemService.GetTechnicalProblemsAsync(model);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("Test3", result.First().ClientName);
        }

        [Test]
        public async Task GetTechnicalProblemById_Test_03()
        {
            //Arrange
            await SeedData();
            var technicalProblem = _dbContext.TechnicalProblems.FirstOrDefaultAsync().GetAwaiter().GetResult()!;
            //Act
            var result = await _technicalProblemService.GetTechnicalProblemByIdAsync(technicalProblem.Id);
            //Assert
            Assert.AreEqual(technicalProblem.Id, result.Id);
            Assert.AreEqual(technicalProblem.Description, result.Description);
            Assert.AreEqual(technicalProblem.ClientName, result.ClientName);
            Assert.AreEqual(technicalProblem.RegisteredOn, result.RegisteredOn);
            Assert.AreEqual(technicalProblem.Solved, result.Solved);
            Assert.AreEqual(technicalProblem.ClientPhone, result.ClientPhone);
            Assert.AreEqual(technicalProblem.ClientAddress, result.ClientAddress);
            Assert.AreEqual(technicalProblem.ClientEmail, result.ClientEmail);
        }

        //[Test]
        //public async Task ResolveTechnicalProblem_Test_04()
        //{
        //    //Arrange
        //    await SeedData();
        //    var technicalProblem = _dbContext.TechnicalProblems.FirstOrDefaultAsync().GetAwaiter().GetResult()!;
        //    //Act
        //    await _technicalProblemService.ResolveTechnicalProblemAsync("Test", true, technicalProblem.Id, _user.Id);
        //    //Assert
        //    Assert.AreEqual("Test", technicalProblem.Solution);
        //    Assert.AreEqual(true, technicalProblem.Solved);
        //}

        [Test]
        public async Task DeleteTechnicalProblem_Test_05()
        {
            //Arrange
            await SeedData();
            var technicalProblem = _dbContext.TechnicalProblems.FirstOrDefaultAsync().GetAwaiter().GetResult()!;
            //Act
            await _technicalProblemService.DeleteTechnicalProblemAsync(technicalProblem.Id);
            //Assert
            Assert.AreEqual(2, _dbContext.TechnicalProblems.Count());
        }
        [Test]
        public async Task GetTechnicalCount_Test_06()
        {
            //Arrange
            await SeedData();
            //Act
            var result = await _technicalProblemService.GetTechnicalCountAsync();
            //Assert
            Assert.AreEqual(3, result);
        }

        private async Task SeedData()
        {
            var technicalProblems = new List<TechnicalProblem>()
            {
                new TechnicalProblem
                {
                    Description = "Test",
                    ClientName = "Test",
                    RegisterProblemUserId = _user.Id,
                    RegisteredOn = DateTime.Now,
                    Solved = false,
                    ClientPhone = "Test",
                    ClientAddress = "Test",
                    ClientEmail = "Test"
                },
                new TechnicalProblem
                {
                    Description = "Test2",
                    ClientName = "Test2",
                    RegisterProblemUserId = _user.Id,
                    RegisteredOn = DateTime.Now,
                    Solved = false,
                    ClientPhone = "Test2",
                    ClientAddress = "Test2",
                    ClientEmail = "Test2"
                },
                new TechnicalProblem
                {
                    Description = "Test3",
                    ClientName = "Test3",
                    RegisterProblemUserId = _user.Id,
                    RegisteredOn = DateTime.Now,
                    Solved = false,
                    ClientPhone = "Test3",
                    ClientAddress = "Test3",
                    ClientEmail = "Test3"
                }
            };
            _dbContext.TechnicalProblems.AddRange(technicalProblems);
            await _dbContext.SaveChangesAsync();
        }
    }
}
