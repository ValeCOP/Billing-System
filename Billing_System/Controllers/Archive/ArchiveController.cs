namespace Billing_System.Controllers.Archive
{
    using Billing_System.Core.Contracts.Archive;
    using Billing_System.Core.ViewModels.ArchiveClients;
    using Billing_System.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using static Billing_System.Areas.Admin.Constants.AdminConstants;

    [Authorize(Roles = AdministratorRoleName)]
    public class ArchiveController : Controller
    {
        private readonly IArchiveService _archiveService;

        public ArchiveController(IArchiveService archiveService)
        {
            _archiveService = archiveService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new MonthSelectViewModel();
            try
            {
                var monthDetails = await _archiveService.GetMonthDetailsAsync();
                model.ArchiveMonthsDetails = monthDetails;
            }
            catch (Exception)
            {

                throw;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Archive(MonthSelectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid Input");
                return View("Index", model);
            }
            try
            {
                await _archiveService.ArchiveClients(model.SelectedMonth);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View("Index", model);
            }
            return RedirectToAction("All", "Clients");

        }
        public async Task<IActionResult> Remove(string monthName)
        {
            try
            {
                await _archiveService.DeleteMonth(monthName);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = ex.Message
                });
            }
            return RedirectToAction("Index");
        }

    }
}
