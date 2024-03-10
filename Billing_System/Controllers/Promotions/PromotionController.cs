namespace Billing_System.Controllers.Promotions
{
    using Billing_System.Core.Contracts.Promotion;
    using Billing_System.Data.Entities;
    using Billing_System.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using System.Globalization;

    public class PromotionController : Controller
    {
        private readonly IPromotionServise _promotionService;

        public PromotionController(IPromotionServise promotionService)
        {
            _promotionService = promotionService;
        }

        [HttpPost]
        public IActionResult Add(Guid clientId)
        {
            try
            {
                _promotionService.Add(clientId);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = ex.Message
                });
            }   
            return Ok();
        }   
    }
}
