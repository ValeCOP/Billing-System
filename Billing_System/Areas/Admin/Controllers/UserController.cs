namespace Billing_System.Areas.Admin.Controllers
{
    using Billing_System.Core.Contracts.Users;
    using Billing_System.Core.ViewModels.Users;
    using Microsoft.AspNetCore.Mvc;

    public class UserController : AdminControllerBase
    {
        private readonly IUserServices userServices;

        public UserController(IUserServices userServices)
        {
            this.userServices = userServices;
        }

        public async Task<IActionResult> All()
        {
           var model = await  userServices.GetAllUsersAsync();
            return View(model);
        }

        public IActionResult Register()
        {
            RegisterViewModel user = new RegisterViewModel();
            
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await userServices.RegisterUser(model);
            return RedirectToAction("All");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await userServices.GetUserById(id);
            if (user.Email == "admin@infocastsystems.eu")
            {
                return BadRequest("You can't delete the admin user!");
            }
            await userServices.DeleteUser(id);
            return RedirectToAction("All");
        }

        public async  Task<IActionResult> Edit(string id)
        {
            var user = await userServices.GetUserById(id);
           
            RegisterViewModel newUser = new RegisterViewModel()
            {
                Email = user.Email,
                UserName = user.UserName,
            };
            return View(newUser);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] RegisterViewModel model,[FromRoute] string Id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await userServices.EditUser(model, Id);
            return RedirectToAction("All");
        }
    }
}
