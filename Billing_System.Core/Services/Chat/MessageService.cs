namespace Billing_System.Core.Services.Chat
{
    using Billing_System.Core.Contracts.Chat;
    using Billing_System.Core.ViewModels.Chat;
    using Billing_System.Data;
    using Billing_System.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Memory;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MessageService : IMessageService
    {
        private readonly BillingDbContext _context;
        private readonly IMemoryCache _cache;

        public MessageService(BillingDbContext context, IMemoryCache cache)
        {
            _cache = cache;
            _context = context;
        }
        public async Task<IEnumerable<ChatModel>> GetAllMessagesAsync()
        {
            var lastTenMessages = await _context.Chats
                .OrderByDescending(m => m.CreatedOn)
                .Select(m => new ChatModel
                {
                    User = m.User,
                    Message = m.Message,
                    CreatedOn = m.CreatedOn

                })
                .ToListAsync();

            _cache.TryGetValue("ChatMessages", out List<ChatModel> messages);
            if (messages != null)
            {
                lastTenMessages.AddRange(messages);
                lastTenMessages = lastTenMessages.OrderByDescending(m => m.CreatedOn).Take(10).ToList();
            }
            return lastTenMessages;
        }

        public async Task SaveMessageAsync(ChatModel chatModels)
        {
            
            if (!_cache.TryGetValue("ChatMessages", out List<ChatModel> messages))
            {
                messages = new List<ChatModel>();
            }

            messages.Add(chatModels);

            _cache.Set("ChatMessages", messages);

            if (messages.Count == 10)
            {
                foreach (var message in messages)
                {
                    var chat = new Chat
                    {
                        User = message.User,
                        Message = message.Message,
                        CreatedOn = message.CreatedOn
                    };
                    _context.Chats.Add(chat);
                }
                await _context.SaveChangesAsync();
                _cache.Remove("ChatMessages");
            }
        }

        public async Task SaveMessageImmediateAsync(ChatModel model)
        {
            var chats = new List<Chat>();

            _cache.TryGetValue("ChatMessages", out List<ChatModel> messages1);
            if (messages1 != null)
            {
                foreach (var message in messages1)
                {
                    var chatMessage = new Chat
                    {
                        User = message.User,
                        Message = message.Message,
                        CreatedOn = message.CreatedOn
                    };
                    chats.Add(chatMessage);
                }
            }
            if (model != null)
            {
                var chat = new Chat
                {
                    User = model.User,
                    Message = model.Message,
                    CreatedOn = DateTime.Now
                };
                chats.Add(chat);
            }
            if (chats.Count == 0)
            {
                return;
            }

            _context.Chats.AddRange(chats);
            await _context.SaveChangesAsync();
            _cache.Remove("ChatMessages");
        }
    }
}
