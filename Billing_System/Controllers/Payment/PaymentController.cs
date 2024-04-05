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
    using static Billing_System.Utilities.ValidationConstants.ValidationConstants.RolesConstants;
    using static Billing_System.Utilities.ValidationConstants.ValidationConstants;


    [Authorize(Roles = CashierRoleName)]
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
        public async Task<IActionResult> Add(AddPaymentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid Payment Details");
                return View(model);
            }
            if (model.Months < 1 || model.Months > 12)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = "Invalid Month"
                });
            }
            DateTime activationDate;
            if (!DateTime.TryParseExact(model.FromDate, AppActivationDateFormatForDb, CultureInfo.InvariantCulture, DateTimeStyles.None, out activationDate))
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = "Invalid Activation Date format"
                });
            }
            DateTime expiriedDate;
            if (!DateTime.TryParseExact(model.ToDate, AppExpiredDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out expiriedDate))
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
                    TempData["message"] = "Payment and Receipt created successfully";
                    RedirectToAction("Details", "Clients", new { id = payment.ClientId });
                }
                TempData["message"] = "Payment created successfully";
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
        public async Task<IActionResult> Edit(EditPaymentViewModel model, Guid Id)
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

                TempData["message"] = "Payment updated successfully";
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
