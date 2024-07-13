namespace Billing_System.Controllers.Chat
{
    using Billing_System.Core.Contracts.Chat;
    using Billing_System.Core.ViewModels.Chat;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static Billing_System.Utilities.ValidationConstants.ValidationConstants.RolesConstants;
    [Authorize(Roles = "Technician, Cashier")]

    public class ChatController : Controller
    {

        private readonly IMessageService _messageService;

        public ChatController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public async Task<IActionResult> Chat()
        { 
            var chatModels = await _messageService.GetAllMessagesAsync();

            return View(chatModels);
        }

        [HttpPost]
        public async Task<IActionResult> SaveChat([FromBody] ChatModel model)
        {
            await _messageService.SaveMessageImmediateAsync(model);
            return Ok();
        }
    }
}
