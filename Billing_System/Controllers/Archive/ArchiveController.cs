namespace Billing_System.Controllers.Archive
{
    using Billing_System.Core.Contracts.Archive;
    using Billing_System.Core.ViewModels.ArchiveClients;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
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
                model.archiveMonthsDetails = monthDetails;
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
                ModelState.AddModelError(string.Empty, "Please select a month");
                return View("Index", model);
            }
            try
            {
                await _archiveService.ArchiveClients(model.SelectedMonth);
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty, "Archive failed");
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
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty, "Delete failed");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
