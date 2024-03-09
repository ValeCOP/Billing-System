namespace Billing_System.Controllers.Payments
{
    using Billing_System.Core.Contracts.Home;
    using Billing_System.Core.Contracts.Payments;
    using Billing_System.Core.Contracts.Receipt;
    using Billing_System.Core.ViewModels.Payments;
    using Billing_System.Data.Entities;
    using Billing_System.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using System.Globalization;
    using System.Security.Claims;

    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class PaymentController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPaymentsService _paymentsService;
        private readonly IReceiptService _receiptService;
        private readonly IHomeService _homeService;

        public PaymentController(UserManager<ApplicationUser> userManager,
            IPaymentsService paymentsService,
            IReceiptService receiptService,
            IHomeService homeService)
        {
            _receiptService = receiptService;
            _userManager = userManager;
            _paymentsService = paymentsService;
            _homeService = homeService;
        }
        public async Task<IActionResult> Add(Guid Id)
        {
            var addPaymentView = await _paymentsService.Add(Id);
            return View(addPaymentView);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPaymentView model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid Payment Details");
                return View(model);
            }
            DateTime activationDate;
            if (!DateTime.TryParseExact(model.FromDate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out activationDate))
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = "Invalid Activation Date format"
                });
            }
            DateTime expiriedDate;
            if (!DateTime.TryParseExact(model.ToDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out expiriedDate))
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = "Invalid Expired Date format"
                });
            }
            if (expiriedDate < activationDate)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = "Expired Date must be after Activation Date"
                });
            }
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var payment = await _paymentsService.AddPaymentAsync(model, Guid.Parse(userId));
                await _homeService.UpdateISPRouterDataAsync(payment.ClientId);

                if (payment.Receipt)
                {
                    await _receiptService.CreateReceiptAsync(payment!.Id);
                }

                return RedirectToAction("Details", "Clients", new { id = model.ClId });
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

        public async Task<IActionResult> Edit(Guid Id)
        {
            try
            {
                var model = await _paymentsService.GetPaymentForEditAsync(Id);
                var userId = _userManager.GetUserId(User);

                if (model.UserId.ToString() != userId)
                {
                    TempData["Error"] = "You are not allowed to edit this payment";
                    return RedirectToAction("Details", "Clients", new { id = model.ClId });
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
        public async Task<IActionResult> Edit(EditPaymentView model, Guid Id)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid Information");
                return View(model);
            }
            if (model.FromDate > model.ToDate)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = "Expired Date must be after Activation Date"
                });
            }
            try
            {
                await _paymentsService.EditPaymentAsync(model, Id);

                await _homeService.UpdateISPRouterDataAsync(model.ClId);

                return RedirectToAction("Details", "Clients", new { id = model.ClId });
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

        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                var model = await _paymentsService.GetPaymentForEditAsync(Id);
                var userId = _userManager.GetUserId(User);

                if (model.UserId.ToString() != userId)
                {
                    TempData["Error"] = "You are not allowed to delete this payment";
                    return RedirectToAction("Details", "Clients", new { id = model.ClId });
                }
                await _paymentsService.DeletePaymentAsync(Id);
                return RedirectToAction("Details", "Clients", new { id = model.ClId });
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
