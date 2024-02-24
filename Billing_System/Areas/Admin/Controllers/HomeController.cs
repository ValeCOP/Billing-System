namespace Billing_System.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : AdminControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
