namespace Billing_System.SignalRHubs
{
    using Billing_System.Core.Contracts.Chat;
    using Billing_System.Core.ViewModels.Chat;
    using Microsoft.AspNetCore.SignalR;
    using System.Net;

    public class ChatHub : Hub
    {
        private readonly IMessageService _messageService;
        public ChatHub(IMessageService messageRepository)
        {
            _messageService = messageRepository;
        }

        public async Task SendMessage(string user, string msg)
        {

            user = Context.User.Identity.Name;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(msg))
            {
                return;
            }
            var message = WebUtility.HtmlEncode(msg);

            await _messageService.SaveMessageAsync(new ChatModel() { User = user, Message = message, CreatedOn = DateTime.Now });

            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task<IEnumerable<string>> GetAllMessages()
        {
            var lastTenMessages = await _messageService.GetAllMessagesAsync();
            return lastTenMessages.Select(m => $"{m.User}: {m.Message}");
        }
        public async Task StartTyping(string user)
        {
            user = Context.User.Identity.Name;

            await Clients.Others.SendAsync("UserTyping", user, true);
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
