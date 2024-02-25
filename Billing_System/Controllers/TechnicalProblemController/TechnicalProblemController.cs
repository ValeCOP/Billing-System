namespace Billing_System.Controllers.TechnicalProblemController
{
    using Billing_System.Core.Contracts.TechnicalProblemService;
    using Billing_System.Core.ViewModels.TechnicalProblem;
    using Billing_System.Data.Entities;
    using Billing_System.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using static Billing_System.Areas.Admin.Constants.AdminConstants;


    [Authorize(Roles = AdministratorRoleName)]
    public class TechnicalProblemController : Controller
    {
        private readonly ITechnicalProblemService _technicalProblemService;
        private readonly UserManager<ApplicationUser> _userManager;


        public TechnicalProblemController(ITechnicalProblemService technicalProblemService,UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _technicalProblemService = technicalProblemService;
        }

        public async Task<IActionResult> Add()
        {
            try
            {
                AddTechProblemView model = new()
                { 
                    RegisterProblemUserId = Guid.Parse(_userManager.GetUserId(User)),
                    Clients = await _technicalProblemService.GetClientsAsync()
                };
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

        [HttpPost]
        public async Task<IActionResult> Add(AddTechProblemView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _technicalProblemService.AddTechnicalProblemAsync(model);
                    return RedirectToAction("All");
                }
                model.Clients = await _technicalProblemService.GetClientsAsync();
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

        public async Task<IActionResult> All()
        {
            try
            {
                ICollection<AllTechProblemViewModel> model = await _technicalProblemService.GetAllTechnicalProblemsAsync();
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
    }
}
