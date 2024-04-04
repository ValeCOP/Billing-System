namespace Billing_System.Controllers.Clients
{
    using Billing_System.Core.Contracts.Clients;
    using Billing_System.Core.ViewModels.Clients;
    using Billing_System.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using static Billing_System.Utilities.ValidationConstants.ValidationConstants.RolesConstants;


    [Authorize(Roles = CashierRoleName)]
    [AutoValidateAntiforgeryToken]
    public class ClientsController : Controller
    {
        private readonly IClientsService _clientService;
        public ClientsController(IClientsService clientsInterface)
        {
            _clientService = clientsInterface;
        }
        public async Task<IActionResult> All(FilteredClientsViewModel model)
        {
            try
            {
                FilteredClientsViewModel filteredClientsViewModel = new FilteredClientsViewModel
                {
                    Clients = await _clientService.GetAllClientsAsync(model),
                    Filter = model.Filter,
                    OrderBy = model.OrderBy,
                    Pending = model.Pending,
                    ClientsCount = model.ClientsCount,
                    CurrentPage = model.CurrentPage,
                };
                return View(filteredClientsViewModel);
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
