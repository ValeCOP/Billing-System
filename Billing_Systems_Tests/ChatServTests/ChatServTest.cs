namespace Billing_Systems_Tests.ChatServTests
{
    using Billing_System.Core.Contracts.Chat;
    using Billing_System.Core.Contracts.Clients;
    using Billing_System.Core.Services.Chat;
    using Billing_System.Core.Services.Clients;
    using Billing_System.Core.ViewModels.Chat;
    using Billing_System.Core.ViewModels.Clients;
    using Billing_System.Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Memory;

    [TestFixture]
    public class ClientServTests
    {
        private BillingDbContext _dbContext;
        private IMessageService _messagesService;
        private IMemoryCache _memoryCache;

        [SetUp]
        public void Setup()
        {
            DbContextOptions<BillingDbContext> dbOptions = new DbContextOptionsBuilder<BillingDbContext>()
               .UseInMemoryDatabase("BillingInMemory" + Guid.NewGuid().ToString())
               .Options;

            _dbContext = new BillingDbContext(dbOptions);

            _dbContext.Database.EnsureCreated();
            var memoryCacheOptions = new MemoryCacheOptions();
            _memoryCache = new MemoryCache(memoryCacheOptions);
            _messagesService = new MessageService(_dbContext, _memoryCache);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
            _memoryCache.Dispose();
        }


        [Test]
        public void GetAllMessagesAsync_Test_01()
        {
            // Arrange
            ChatModel chatModel = new ChatModel()
            {
                User = "User4",
                Message = "Message",
                CreatedOn = DateTime.Now
            };
            _messagesService.SaveMessageAsync(chatModel).GetAwaiter().GetResult();

            // Act
            var messages = _messagesService.GetAllMessagesAsync().GetAwaiter().GetResult();

            // Assert
            Assert.That(messages.Count, Is.EqualTo(1));
            var message = messages.FirstOrDefault();
            Assert.That(message.User, Is.EqualTo("User4"));
            var msgFromDb = _dbContext.Chats.CountAsync().GetAwaiter().GetResult();
            Assert.That(msgFromDb, Is.EqualTo(0));
        }
        [Test]
        public void GetAndSaveTenMessagesAsync_Test_01()
        {
            for (int i = 0; i < 11; i++)
            {
                ChatModel chatModel = new ChatModel()
                {
                    User = "User" + i,
                    Message = "Message" + i,
                    CreatedOn = DateTime.Now
                };
                _messagesService.SaveMessageAsync(chatModel).GetAwaiter().GetResult();
            }

            // Act
            var messages = _messagesService.GetAllMessagesAsync().GetAwaiter().GetResult();

            // Assert
            Assert.That(messages.Count, Is.EqualTo(10));
            var message = messages.FirstOrDefault();
            Assert.That(message.User, Is.EqualTo("User10"));
            var msgFromDb = _dbContext.Chats.CountAsync().GetAwaiter().GetResult();
            Assert.That(msgFromDb, Is.EqualTo(10));
        }
    }
}