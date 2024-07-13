namespace Billing_System.Controllers.Clients
{
    using Billing_System.Core.Contracts.Clients;
    using Billing_System.Core.ViewModels.Clients;
    using Microsoft.AspNetCore.Mvc;

    [Route("Api/Get")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IClientsService _clientsService;
        public ApiController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(ICollection<ShortInfoForActivatedClients>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clients = await _clientsService.GetClientShortAsync();
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
