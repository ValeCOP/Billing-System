namespace Billing_System.SignalRHubs
{
    using Billing_System.Core.Contracts.Chat;
    using Billing_System.Core.ViewModels.Chat;
    using Microsoft.AspNetCore.SignalR;

    public class ChatHub : Hub
    {
        private readonly IMessageService _messageRepository;
        public ChatHub(IMessageService messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task SendMessage(string user, string message)
        {
            await _messageRepository.SaveMessageAsync(new ChatModel() { User = user, Message = message });

            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task<IEnumerable<string>> GetAllMessages()
        {
            var lastTenMessages = await _messageRepository.GetAllMessagesAsync();
            return lastTenMessages.Select(m => $"{m.User}: {m.Message}");
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Others.SendAsync("UserConnected", Context.User!.Identity!.Name);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.Others.SendAsync("UserDisconnected", Context.User!.Identity!.Name);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
