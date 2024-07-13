namespace Billing_System.Controllers.Invoice
{
    using Billing_System.Core.Contracts.Invoice;
    using Billing_System.Core.Contracts.Payments;
    using Billing_System.Core.CustomExtensions;
    using Billing_System.Core.ViewModels.Invoice;
    using Billing_System.Data.Entities;
    using Billing_System.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using static Billing_System.Utilities.ValidationConstants.ValidationConstants.RolesConstants;


    [Authorize(Roles = CashierRoleName)]
    public class InvoiceController : Controller
    {
        private readonly IPaymentsService _paymentService;
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IPaymentsService paymentService, IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
            _paymentService = paymentService;
        }
        public async Task<IActionResult> Index(Guid Id)
        {
            Payment payment = await _paymentService.GetPaymentByIdAsync(Id);
            Client client = payment.Client;

            PaymentForInvoiceViewModel paymentForInvoiceViewModel = new PaymentForInvoiceViewModel
            {
                InvoiceNumber = _invoiceService.GetNextInvoiceNumber(),
                CreatedOn = DateTime.Now,
                Payment = payment,
                Client = client
            };
            return View(paymentForInvoiceViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInvoiceViewModel model, Guid Id)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid input data!");
                return View("Index", model);
            }
            var userId = User.GetId();
            await _invoiceService.CreateInvoiceAsync(model, Id, userId);
            TempData["message"] = $"Invoice created successfully!";
            return RedirectToAction("All", "Invoice");
        }
        public async Task<IActionResult> All(FilteredInvoiceViewModel model)
        {
            var invoices = await _invoiceService.GetAllInvoicesAsync(model);
            model.Invoices = invoices;
            return View(model);
        }
        public async Task<IActionResult> Print(Guid Id)
        {
            AllInvoiceViewModel invoice = await _invoiceService.GetInvoiceForPrintAsync(Id);
            return View(invoice);
        }
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                await _invoiceService.DeleteInvoiceAsync(Id);
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
