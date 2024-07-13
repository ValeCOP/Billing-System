namespace Billing_System.Core.Contracts.Chat
{
    using Billing_System.Core.ViewModels.Chat;

    public interface IMessageService
    {
        Task SaveMessageAsync(ChatModel model);

        Task<IEnumerable<ChatModel>> GetAllMessagesAsync();
        Task SaveMessageImmediateAsync(ChatModel model);
    }
}
