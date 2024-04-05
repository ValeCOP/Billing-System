namespace Billing_System.Controllers.Home
{
    using Billing_System.ActionFilters;
    using Billing_System.Core.Contracts.Home;
    using Billing_System.Core.Contracts.Payments;
    using Billing_System.Core.Contracts.Receipt;
    using Billing_System.Core.CustomExtensions;
    using Billing_System.Core.ViewModels.Clients;
    using Billing_System.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using System.Diagnostics;
    using System.Globalization;
    using static Utilities.ValidationConstants.ValidationConstants;
    using static Utilities.ValidationConstants.ValidationConstants.ActiveISPClientsForm;
    using static Utilities.ValidationConstants.ValidationConstants.RolesConstants;


    [Authorize(Roles = CashierRoleName)]
    [ServiceFilter(typeof(LogActionFilter))]
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly IReceiptService _receiptInterface;
        private readonly IPaymentsService _paymentsService;
        private readonly IMemoryCache _cache;


        public HomeController(IHomeService homeInterface,
                   IReceiptService receiptInterface,
                   IPaymentsService paymentsService,
                   IMemoryCache cache)
        {
            _paymentsService = paymentsService;
            _homeService = homeInterface;
            _receiptInterface = receiptInterface;
            _cache = cache;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                if (!_cache.TryGetValue("ActiveISPClientsFormModel", out ActiveISPClientsFormModel model))
                {
                    model = await _homeService.ImportISPRouterDataAsync();
                    _cache.Set("ActiveISPClientsFormModel", model, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                    });
                }
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
        public async Task<IActionResult> Index(ActiveISPClientsFormModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, ActivationInputDataErrorMessage);

                model = await _homeService.ImportISPRouterDataAsync();

                return View(model);
            }
            if (model.Months < 1 || model.Months > 12)
            {
                ModelState.AddModelError(string.Empty, "Invalid Months; Must be between 1 and 12");
                model = await _homeService.ImportISPRouterDataAsync();
                return View(model);
            }
            try
            {
                string activationDate = model.ActivationDate.ToString(AppActivationDateFormat, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = ex.Message
                });
            }

            try
            {
                string expiredDate = model.ExpiredDate.ToString(AppActivationDateFormat, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = ex.Message
                });
            }

            if (model.ActivationDate > model.ExpiredDate)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = "Expired Date must be after Activation Date"
                });
            }

            var userId  = User.GetId();

            try
            {
                await _homeService.ActivateClientAsync(model, userId);
                await _homeService.UpdateISPRouterDataAsync(model.ClientId);

                TempData["message"]
                    = $"Client {model.ClientFullName} has activated successfully to {model.ExpiredDate.ToString("D",CultureInfo.InvariantCulture)}!";

                if (model.Receipt)
                {
                    var paymentId = _paymentsService.GetPaymentIdByClientId(model.ClientId);
                    await _receiptInterface.CreateReceiptAsync(paymentId);
                    TempData["message"] =
                        $"Client {model.ClientFullName} has activated successfully to {model.ExpiredDate.ToString("D",CultureInfo.InvariantCulture)}.{Environment.NewLine}Receipt created!";
                }

                return RedirectToAction("Index", "Home");
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
        public IActionResult SetTempData(string data)
        {
            TempData["message"] = data;

            return new EmptyResult();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404)
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = "Page not found" });
            }
            else if (statusCode == 403)
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = "You are not allowed to access this page" });
            }
            else if (statusCode == 500)
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = "Internal server error" });
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = "Error" });
            }
        }
    }
}
