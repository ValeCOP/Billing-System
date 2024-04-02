namespace Billing_System.Core.Services.Users
{
    using Billing_System.Core.Contracts.Users;
    using Billing_System.Core.ViewModels.Users;
    using Billing_System.Data;
    using Billing_System.Data.Entities;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserServices : IUserServices
    {
        private readonly BillingDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        public UserServices(BillingDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync()
        {
            var allUsers = new List<AllUsersViewModel>();


            var users = await _userManager.Users.ToListAsync();
            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var userViewModel = new AllUsersViewModel()
                {
                    Id = user.Id.ToString(),
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = userRoles
                };
                allUsers.Add(userViewModel);
            }
            return allUsers;
        }

        public async Task RegisterUser(RegisterViewModel model)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                throw new System.Exception("Error creating user!");
            }

            if (model.UserRole == "Administrator")
            {
                var roleExist = await _roleManager.RoleExistsAsync("Administrator");
                if (!roleExist)
                {
                    await _roleManager.CreateAsync(new IdentityRole<Guid>("Administrator"));
                }
                await _userManager.AddToRoleAsync(user, "Administrator");
            }
            else if (model.UserRole == "User")
            {
                var roleExist = await _roleManager.RoleExistsAsync("User");
                if (!roleExist)
                {
                    await _roleManager.CreateAsync(new IdentityRole<Guid>("User"));
                }
                await _userManager.AddToRoleAsync(user, "User");
            }
            else
            {
                throw new System.Exception("Invalid user role!");
            }

        }

        public async Task DeleteUser(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id.ToString() == id);
            if (user == null)
            {
                throw new System.Exception("User not found!");
            }
            _context.UserRoles.RemoveRange(_context.UserRoles.Where(ur => ur.UserId == user.Id));
            _context.Expenses.RemoveRange(_context.Expenses.Where(e => e.UserId == user.Id));
            _context.Payments.RemoveRange(_context.Payments.Where(p => p.UserId == user.Id));
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task EditUser(RegisterViewModel model, string Id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id.ToString().ToUpper() == Id.ToUpper());
            if (user == null)
            {
                throw new System.Exception("User not found!");
            }
            user.UserName = model.UserName;
            user.Email = model.Email;

            _context.UserRoles.RemoveRange(_context.UserRoles.Where(ur => ur.UserId == user.Id));

            await _context.SaveChangesAsync();

            if (model.UserRole == "Administrator")
            {
                var roleExist = await _roleManager.RoleExistsAsync("Administrator");
                if (!roleExist)
                {
                    await _roleManager.CreateAsync(new IdentityRole<Guid>("Administrator"));
                    await _userManager.AddToRoleAsync(user, "Administrator");
                }
                await _userManager.AddToRoleAsync(user, "Administrator");
            }
            else if (model.UserRole == "User")
            {
                var roleExist = await _roleManager.RoleExistsAsync("User");
                if (!roleExist)
                {
                    await _roleManager.CreateAsync(new IdentityRole<Guid>("User"));
                    await _userManager.AddToRoleAsync(user, "User");
                }
                await _userManager.AddToRoleAsync(user, "User");
            }
            else
            {
                throw new System.Exception("Invalid user role!");
            }
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id.ToString() == id);
            if (user == null)
            {
                throw new System.Exception("User not found!");
            }
            return user;

        }

        public async Task<ICollection<UsersViewWithPayments>> GetAllUserWithPayments()
        {
            return await _context.Users
                .Include(u => u.Payments)
                .Include(u => u.Expenses)
                .Select(u => new UsersViewWithPayments
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Payments = u.Payments,
                    Expenses = u.Expenses,
                }).ToListAsync();
        }
    }
}
