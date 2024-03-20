namespace Billing_System.Controllers.Invoice
{
    using Billing_System.Core.Contracts.Invoice;
    using Billing_System.Core.Contracts.Payments;
    using Billing_System.Core.ViewModels.Invoice;
    using Billing_System.Data.Entities;
    using Billing_System.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    [Authorize]
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
        //crete invoice
        public async Task<IActionResult> Create(CreateInvoiceViewModel model, Guid Id)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);

                var errorMessages = new List<string>();
                foreach (var error in errors)
                {
                    errorMessages.Add(error.ErrorMessage);
                }
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = String.Join(", ", errorMessages)
                });
            }
            await _invoiceService.CreateInvoiceAsync(model, Id);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> All(FilteredInvoiceViewModel model)
        {
            var invoices = await _invoiceService.GetAllInvoicesAsync(model);
            model.Invoices = invoices;
            return View(model);
        }
    }
}
