namespace Billing_System.Controllers.Promotions
{
    using Billing_System.Core.Contracts.Home;
    using Billing_System.Core.Contracts.Payments;
    using Billing_System.Core.Contracts.Promotion;
    using Billing_System.Core.CustomExtensions;
    using Billing_System.Core.ViewModels.Payments;
    using Billing_System.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using static Billing_System.Utilities.ValidationConstants.ValidationConstants.RolesConstants;

    [Authorize(Roles = AdministratorRoleName)]
    public class PromotionController : Controller
    {
        private readonly IPromotionService _promotionService;
        private readonly IPaymentsService _paymentsService;
        private readonly IHomeService _homeService;

        public PromotionController(
            IPromotionService promotionService,
            IPaymentsService paymentsService,
            IHomeService homeService)
        {
            _homeService = homeService;
            _paymentsService = paymentsService;
            _promotionService = promotionService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Guid clientId)
        {
            try
            {
                await _promotionService.Add(clientId);

                AddPaymentViewModel payment = new AddPaymentViewModel
                {
                    Name = "Promotion",
                    Fee = 0,
                    Pending = false,
                    Receipt = false,
                    FromDate = DateTime.Now.ToString(),
                    ToDate = DateTime.Now.AddMonths(2).ToString(),
                    ClId = clientId,
                    UserId = Guid.Parse(User.GetId())
                };

                await _paymentsService.AddPaymentAsync(payment, payment.UserId);

                await _homeService.UpdateISPRouterDataAsync(clientId);

                return Ok(200);
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
        
        [HttpGet]
        public async Task<IActionResult> GetProfitableClient()
        {
            try
            {
                var promotions = await _promotionService.GetProfitableClientAsync();
                return Ok(promotions);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
