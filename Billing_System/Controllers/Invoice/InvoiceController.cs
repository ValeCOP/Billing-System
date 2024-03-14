namespace Billing_System.Controllers.Invoice
{
    using Billing_System.Core.Contracts.Invoice;
    using Billing_System.Core.Contracts.Payments;
    using Billing_System.Core.ViewModels.Invoice;
    using Billing_System.Data.Entities;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

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
    }
}
