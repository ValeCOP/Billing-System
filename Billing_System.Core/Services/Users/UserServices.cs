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
    using static Billing_System.Utilities.ValidationConstants.ValidationConstants.RolesConstants;
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
                throw new Exception("Error creating user!");
            }

            await AddUserToRole(model, user);
        }

        public async Task DeleteUser(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id.ToString() == id);
            if (user == null)
            {
                throw new Exception("User not found!");
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
                throw new Exception("User not found!");
            }
            user.UserName = model.UserName;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            user.Email = model.Email;

            _context.UserRoles.RemoveRange(_context.UserRoles.Where(ur => ur.UserId == user.Id));

            await _context.SaveChangesAsync();

            await AddUserToRole(model, user);

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task<ApplicationUser> GetUserById(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id.ToString() == id);
            if (user == null)
            {
                throw new Exception("User not found!");
            }
            return user;

        }
        public async Task<ICollection<UsersViewWithPayments>> GetAllUserWithPayments()
        {
            var users = await _userManager.Users
                .OrderBy(u => u.UserName)
                .Include(u => u.Payments)
                .Include(u => u.Expenses)
                .ToListAsync();
            var allUsers = new List<UsersViewWithPayments>();
            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                if (userRoles.Contains(TechnicianRoleName) && userRoles.Count == 1)
                {
                    continue;
                }
                var userViewModel = new UsersViewWithPayments()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Payments = user.Payments,
                    Expenses = user.Expenses
                };
                allUsers.Add(userViewModel);
            }

            return allUsers;
        }
        private async Task AddUserToRole(RegisterViewModel model, ApplicationUser user)
        {
            if (model.UserRole == AdministratorRoleName)
            {
                var roleExist = await _roleManager.RoleExistsAsync(AdministratorRoleName);
                if (!roleExist)
                {
                    await _roleManager.CreateAsync(new IdentityRole<Guid>(AdministratorRoleName));
                }
                await _userManager.AddToRoleAsync(user, AdministratorRoleName);

                var roleCashierExist = await _roleManager.RoleExistsAsync(CashierRoleName);
                if (!roleCashierExist)
                {
                    await _roleManager.CreateAsync(new IdentityRole<Guid>(CashierRoleName));
                }
                await _userManager.AddToRoleAsync(user, CashierRoleName);

                var roleTechnicianExist = await _roleManager.RoleExistsAsync(TechnicianRoleName);
                if (!roleTechnicianExist)
                {
                    await _roleManager.CreateAsync(new IdentityRole<Guid>(TechnicianRoleName));
                }
                await _userManager.AddToRoleAsync(user, TechnicianRoleName);

            }
            else if (model.UserRole == CashierRoleName)
            {
                var roleExist = await _roleManager.RoleExistsAsync(CashierRoleName);
                if (!roleExist)
                {
                    await _roleManager.CreateAsync(new IdentityRole<Guid>(CashierRoleName));
                }
                await _userManager.AddToRoleAsync(user, CashierRoleName);
            }
            else if (model.UserRole == TechnicianRoleName)
            {
                var roleExist = await _roleManager.RoleExistsAsync(TechnicianRoleName);
                if (!roleExist)
                {
                    await _roleManager.CreateAsync(new IdentityRole<Guid>(TechnicianRoleName));
                }
                await _userManager.AddToRoleAsync(user, TechnicianRoleName);
            }
            else
            {
                throw new System.Exception("Invalid user role!");
            }
        }
    }
}
