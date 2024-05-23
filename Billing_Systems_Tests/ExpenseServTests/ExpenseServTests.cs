namespace Billing_Systems_Tests.ExpenseServTests
{
    using Billing_System.Core.Contracts.Expense;
    using Billing_System.Core.Services.Expense;
    using Billing_System.Core.ViewModels.Expense;
    using Billing_System.Data;
    using Billing_System.Data.Entities;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Internal;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using System.Text;

    [TestFixture]
    public class ExpenseServTests
    {
        private BillingDbContext _dbContext;
        private IExpenseService _expenseService;

        [SetUp]
        public void Setup()
        {
            DbContextOptions<BillingDbContext> dbOptions = new DbContextOptionsBuilder<BillingDbContext>()
               .UseInMemoryDatabase("BillingInMemory" + Guid.NewGuid().ToString())
               .Options;

            _dbContext = new BillingDbContext(dbOptions);

            _dbContext.Database.EnsureCreated();

            _expenseService = new ExpenseService(_dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
            var path = Path.Combine(Environment.CurrentDirectory, "wwwroot", "expense");
            if (Directory.Exists(path))
            {
                foreach (var file in Directory.GetFiles(path))
                {
                    File.Delete(file);
                }
            }

        }

        //[Test]
        //public void AddExpenseAsync_Test_01()
        //{
        //    var formFile = new Mock<IFormFile>();
        //    var PhysicalFile = new FileInfo(@"../../../45.jpg");
        //    var memory = new MemoryStream();
        //    var writer = new StreamWriter(memory);
        //    writer.Write(PhysicalFile.OpenRead());
        //    writer.Flush();
        //    memory.Position = 0;
        //    var fileName = PhysicalFile.Name;

        //    formFile.Setup(_ => _.FileName).Returns(fileName);
        //    formFile.Setup(_ => _.Length).Returns(memory.Length);
        //    formFile.Setup(_ => _.OpenReadStream()).Returns(memory);
        //    formFile.Verify();

        //    var file = formFile.Object;

        //    var model = new AddExpenseViewModel
        //    {
        //        Name = "Test",
        //        UserId = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb964a"),
        //        Value = 100,
        //        Description = "Test",
        //        File = file
        //    };
        //    var expense = new Expense
        //    {
        //        Name = model.Name,
        //        UserId = model.UserId,
        //        Value = model.Value,
        //        Date = DateTime.Now,
        //        Description = model.Description,
        //        ReceiptUrl = @"/images/expense/" + model.File.FileName
        //    };
        //    _dbContext.Expenses.Add(expense);
        //    _dbContext.SaveChanges();
        //    _expenseService.AddExpenseAsync(model).GetAwaiter().GetResult();

        //    var expense1 = _dbContext.Expenses.FirstOrDefaultAsync().GetAwaiter().GetResult();
        //    Assert.IsNotNull(expense1);
        //    Assert.AreEqual("Test", expense1.Name);
        //    Assert.AreEqual(Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb964a"), expense1.UserId);
        //    Assert.AreEqual(100, expense1.Value);
        //    Assert.AreEqual("Test", expense1.Description);
        //    Assert.AreEqual(@"/images/expense/45.jpg", expense1.ReceiptUrl);
        //}

        [Test]
        public void DeleteExpenseAsync_Test_02()
        {
            IFormFile file = CreateFile();

            var model = new AddExpenseViewModel
            {
                Name = "Test",
                UserId = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb964a"),
                Value = 100,
                Description = "Test",
                File = file
            };
            var expense = new Expense
            {
                Name = model.Name,
                UserId = model.UserId,
                Value = model.Value,
                Date = DateTime.Now,
                Description = model.Description,
                ReceiptUrl = @"/images/expense/" + model.File.FileName
            };
            _dbContext.Expenses.Add(expense);
            _dbContext.SaveChanges();
            var expense1 = _dbContext.Expenses.FirstOrDefaultAsync().GetAwaiter().GetResult();
            Assert.IsNotNull(expense1);

            _expenseService.DeleteExpenseAsync(expense.Id).GetAwaiter().GetResult();
            var expense2 = _dbContext.Expenses.FirstOrDefaultAsync().GetAwaiter().GetResult();

            Assert.IsNull(expense2);
        }



        [Test]
        //GetExpenseAsync
        public void GetExpenseAsync_Test_03()
        {
            IFormFile file = CreateFile();
            ICollection<AddExpenseViewModel> models = new List<AddExpenseViewModel>
            {
                new AddExpenseViewModel
                {
                    Name = "Test",
                    UserId = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb964a"),
                    Value = 100,
                    Description = "Test",
                    File = file
                },
                new AddExpenseViewModel
                {
                    Name = "Test1",
                    UserId = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb964a"),
                    Value = 200,
                    Description = "Test1",
                    File = file
                },
                new AddExpenseViewModel
                {
                    Name = "Test2",
                    UserId = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb964a"),
                    Value = 300,
                    Description = "Test2",
                    File = file
                },
                new AddExpenseViewModel
                {
                    Name = "Test3",
                    UserId = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb964a"),
                    Value = 400,
                    Description = "Test3",
                    File = file
                }
            };

            foreach (var model in models)
            {
                var expense = new Expense
                {
                    Name = model.Name,
                    UserId = model.UserId,
                    Value = model.Value,
                    Date = DateTime.Now,
                    Description = model.Description,
                    ReceiptUrl = @"/expense/" + model.File.FileName
                };
                _dbContext.Expenses.Add(expense);

            }

            _dbContext.SaveChanges();

            var filteredModel = new FilteredExpensesViewModel()
            {
                Filter = "Test",
                OrderBy = "Name",
            };
            var expenses = _expenseService.GetExpenseAsync(filteredModel).GetAwaiter().GetResult();
            Assert.AreEqual(3, expenses.Count);

            filteredModel.Filter = "Test1";
            var expenses1 = _expenseService.GetExpenseAsync(filteredModel).GetAwaiter().GetResult();
            Assert.AreEqual(1, expenses1.Count);

            filteredModel.Filter = "";
            filteredModel.OrderBy = "ValueDesc";
            var expenses2 = _expenseService.GetExpenseAsync(filteredModel).GetAwaiter().GetResult();
            Assert.That(expenses2.First().Value, Is.EqualTo(400));

            filteredModel.OrderBy = "DateDesc";
            var expenses3 = _expenseService.GetExpenseAsync(filteredModel).GetAwaiter().GetResult();
            Assert.That(expenses3.First().Name, Is.EqualTo("Test3"));

            filteredModel.OrderBy = "Date";
            var expenses4 = _expenseService.GetExpenseAsync(filteredModel).GetAwaiter().GetResult();
            Assert.That(expenses4.First().Name, Is.EqualTo("Test"));

        }
        private static IFormFile CreateFile()
        {
            var formFile = new Mock<IFormFile>();
            var PhysicalFile = new FileInfo(@"../../../45.jpg");
            var memory = new MemoryStream();
            var writer = new StreamWriter(memory);
            writer.Write(PhysicalFile.OpenRead());
            writer.Flush();
            memory.Position = 0;
            var fileName = PhysicalFile.Name;

            formFile.Setup(_ => _.FileName).Returns(fileName);
            formFile.Setup(_ => _.Length).Returns(memory.Length);
            formFile.Setup(_ => _.OpenReadStream()).Returns(memory);
            formFile.Verify();

            var file = formFile.Object;
            return file;
        }
    }
}
