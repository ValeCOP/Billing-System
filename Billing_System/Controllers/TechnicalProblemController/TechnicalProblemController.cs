namespace Billing_System.Controllers.TechnicalProblemController
{
    using Billing_System.Core.Contracts.MailSender;
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
        private readonly ISendMail _sendMail;

        public TechnicalProblemController(ITechnicalProblemService technicalProblemService,
            UserManager<ApplicationUser> userManager,
            ISendMail sendMail)
        {
            _userManager = userManager;
            _technicalProblemService = technicalProblemService;
            _sendMail = sendMail;
        }

        public async Task<IActionResult> Add()
        {
            try
            {
                AddTechProblemView model = new()
                { 
                    RegisterProblemUserId = Guid.Parse(_userManager.GetUserId(User)),
                    Clients = await _technicalProblemService.GetClientsAsync(),
                    TechnicalProblems = await _technicalProblemService.GetAllTechnicalProblemsAsync()
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
                    if (model.SendMail)
                    {
                        _sendMail.SendEmail("Technical Problem", model.Description, model.ClientName);
                    }
                    return RedirectToAction("All");
                }
               
                model.Clients = await _technicalProblemService.GetClientsAsync();
                model.TechnicalProblems = await _technicalProblemService.GetAllTechnicalProblemsAsync();

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
