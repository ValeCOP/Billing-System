namespace Billing_System.Controllers.Clients
{
    using Billing_System.Core.Contracts.Clients;
    using Billing_System.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class ClientsController : Controller
    {
        private readonly IClientsService _clientService;
        public ClientsController(IClientsService clientsInterface)
        {
            _clientService = clientsInterface;
        }
        public async Task<IActionResult> All([FromQuery] string orderBy, string searchString)
        {
            try
            {
                var model = await _clientService.GetAllClientsAsync(orderBy, searchString);
                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = ex.Message
                });
            }
        }
        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var model = await _clientService.GetClientDetailsAsync(id);
                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = ex.Message
                });
            }
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _clientService.DeleteClientAsync(id);
                TempData["Message"] = "Client deleted successfully";
                return RedirectToAction("All");
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = ex.Message
                });
            }
        }

    }
}
