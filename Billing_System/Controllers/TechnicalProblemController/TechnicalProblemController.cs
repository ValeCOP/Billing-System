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
                    ClientsFromISPRouter = await _technicalProblemService.GetClientsAsync()
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
                        try
                        {
                            _sendMail.SendEmail("Technical Problem", model.Description, model.ClientName);
                        }
                        catch (Exception)
                        {
                            TempData["message"] = "Email not sent!";
                            RedirectToAction("All");
                        }
                    }
                    return RedirectToAction("All");
                }

                model.ClientsFromISPRouter = await _technicalProblemService.GetClientsAsync();

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
        //resolve
        public async Task<IActionResult> Resolve(Guid id)
        {
            try
            {
                ResolveTechProblem model = await _technicalProblemService.GetTechnicalProblemByIdAsync(id);
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
        public async Task<IActionResult> Resolve(ResolveTechProblemView model)
        {
            if (ModelState.IsValid)
            {
                await _technicalProblemService.ResolveTechnicalProblemAsync(
                    model.Description,
                    model.Solved,
                    model.Id,
                    Guid.Parse(_userManager.GetUserId(User)));
                return RedirectToAction("All");
            }
            ModelState.AddModelError(string.Empty, "Invalid data!");
            return View(model);
        }

        public async Task<IActionResult> All(FilteredTechProblemsViewModel modelGetForm)
        {

            try
            {
                var model = new FilteredTechProblemsViewModel
                {
                    TechnicalProblems = await _technicalProblemService.GetTechnicalProblemsAsync(modelGetForm)

                };
                model.ProblemsCount = model.TechnicalProblems.Count;
                model.CurrentPage = modelGetForm.CurrentPage;
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
        //delete
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _technicalProblemService.DeleteTechnicalProblemAsync(id);
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
