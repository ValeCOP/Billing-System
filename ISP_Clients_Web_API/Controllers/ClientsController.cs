namespace ISP_Clients_Web_API.Controllers
{
    using ISP_Clients_Web_API.Data;
    using ISP_Clients_Web_API.Data.Entities;
    using ISP_Clients_Web_API.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Globalization;

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly BillingApiDBContext _context;

        public ClientsController(BillingApiDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Produces("application/json")]
        public  ActionResult<IEnumerable<Client>> Get()
        {
            return _context.ClientsISP
                .OrderBy(c => c.FullName)
                .ToList();
        }
        [HttpGet("{id}")]
        [Produces("application/json")]
        public ActionResult<Client> GetById(Guid Id)
        {
            return _context.ClientsISP
                .FirstOrDefault(c => c.Id == Id)!;
        }

        [HttpPatch("{id}")]
        [Produces("application/json")]
        public IActionResult Patch(Guid id, [FromBody] CreateClientViewModel client)
        {
            Client clientToUpdate = _context.ClientsISP.FirstOrDefault(c => c.Id == id)!;

            clientToUpdate.ActivationDate = client.ActivationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            clientToUpdate.ExpiredDate = client.ExpiredDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

            _context.SaveChanges();
            return Ok();
        }


    }
}
