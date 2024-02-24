namespace Billing_System.Controllers.TechnicalProblemController
{
    using Billing_System.Core.Contracts.TechnicalProblemService;
    using Billing_System.Core.ViewModels.TechnicalProblem;
    using Billing_System.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using static Billing_System.Areas.Admin.Constants.AdminConstants;


    [Authorize(Roles = AdministratorRoleName)]
    public class TechnicalProblemController : Controller
    {
        private readonly ITechnicalProblemService _technicalProblemService;

        public TechnicalProblemController(ITechnicalProblemService technicalProblemService)
        {
            _technicalProblemService = technicalProblemService;
        }

        public IActionResult Add()
        {
            try
            {
                AddTechProblemView model = new()
                {
                    
                    Clients = _technicalProblemService.GetClients()
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
    }
}
