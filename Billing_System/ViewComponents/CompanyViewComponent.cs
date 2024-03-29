namespace Billing_System.ViewComponents
{
    using Billing_System.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class CompanyViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Company company = new Company();
            return View(company);
        }
    }
}
