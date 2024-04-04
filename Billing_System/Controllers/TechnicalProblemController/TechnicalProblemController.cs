namespace Billing_System.Controllers.TechnicalProblemController
{
    using Billing_System.Core.Contracts.MailSender;
    using Billing_System.Core.Contracts.TechnicalProblemService;
    using Billing_System.Core.CustomExtensions;
    using Billing_System.Core.ViewModels.Clients;
    using Billing_System.Core.ViewModels.TechnicalProblem;
    using Billing_System.Data.Entities;
    using Billing_System.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using System.Diagnostics;
    using static Billing_System.Utilities.ValidationConstants.ValidationConstants;
    using static Billing_System.Utilities.ValidationConstants.ValidationConstants.RolesConstants;


    [Authorize(Roles = TechnicianRoleName)]
    public class TechnicalProblemController : Controller
    {
        private readonly ITechnicalProblemService _technicalProblemService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISendMail _sendMail;
        private readonly IMemoryCache _cache;

        public TechnicalProblemController(ITechnicalProblemService technicalProblemService,
            UserManager<ApplicationUser> userManager,
            ISendMail sendMail,
            IMemoryCache cache)
        {
            _userManager = userManager;
            _technicalProblemService = technicalProblemService;
            _sendMail = sendMail;
            _cache = cache;
        }

        public async Task<IActionResult> Add()
        {
            try
            {
                ICollection<ClientsInfoModel> clientsInfoModel;
                if (!_cache.TryGetValue("ClientsFromISPRouter", out clientsInfoModel))
                {
                    clientsInfoModel = await _technicalProblemService.GetClientsAsync();
                    _cache.Set("ClientsFromISPRouter", clientsInfoModel, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                    });
                }
                AddTechProblemView model = new()
                {
                    RegisterProblemUserId = Guid.Parse(_userManager.GetUserId(User)),
                    ClientsFromISPRouter = clientsInfoModel
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
            if (ModelState.IsValid)
            {
                try
                {
                    await _technicalProblemService.AddTechnicalProblemAsync(model);
                    if (model.SendMail)
                    {
                        try
                        {
                            _sendMail.SendEmail("Technical Problem", model.Description, model.ClientName, TechnicalTeemsEmails);
                            TempData["message"] = "Registered technical problem. Email sent!";
                            return RedirectToAction("All");
                        }
                        catch (Exception)
                        {
                            TempData["message"] = "Registered technical problem. Email not sent!";
                            RedirectToAction("All");
                        }
                    }
                    TempData["message"] = "Registered technical problem! Email not sent!";
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
            model.ClientsFromISPRouter = await _technicalProblemService.GetClientsAsync();

            return View(model);
        }

        public async Task<IActionResult> Resolve(Guid id)
        {
            try
            {
                ResolveTechProblem model = await _technicalProblemService.GetTechnicalProblemByIdAsync(id);
                return View(model);
            }
            catch (ArgumentNullException ex)
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
                try
                {
                    var userId = Guid.Parse(User.GetId());
                    await _technicalProblemService.ResolveTechnicalProblemAsync(model, userId);
                    if (model.SendMailToClient)
                    {
                        try
                        {
                            _sendMail.SendEmail("Resolved Problem", model.Solution,
                                model.ClientName, model.ClientEmail + "," + TechnicalTeemsEmails);
                            TempData["message"] = "Technical problem resolved. Email sent!";
                            return RedirectToAction("All");
                        }
                        catch (Exception)
                        {
                            TempData["message"] = "Technical problem resolved. Email not sent!";
                            RedirectToAction("All");
                        }
                    }
                    TempData["message"] = "Technical problem resolved! Email not sent!";
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
                model.Resolved = modelGetForm.Resolved;
                model.Filter = modelGetForm.Filter;
                model.OrderBy = modelGetForm.OrderBy;
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
        [Authorize(Roles = AdministratorRoleName)]
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
