namespace Billing_System.Core.CustomExtensions
{
    using Billing_System.CustomMiddleware;
    using Billing_System.CustomMiddlewares;
    using Billing_System.Data.Entities;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    using static Billing_System.Utilities.ValidationConstants.ValidationConstants.RolesConstants;


    public static class ApplicationBuilderExtension
    {
        public static async Task SeedAdmin(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            IServiceProvider services = serviceScope.ServiceProvider;
            UserManager<ApplicationUser> userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole<Guid>> roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            ApplicationUser admin = await userManager.FindByEmailAsync(AdminEmail);

            var roleAdminExist = await roleManager.RoleExistsAsync(AdministratorRoleName);
            var roleCashierExist = await roleManager.RoleExistsAsync(CashierRoleName);
            var roleUserExist = await roleManager.RoleExistsAsync(TechnicianRoleName);

            if (roleAdminExist )
            {
                IdentityRole<Guid> role = await roleManager.FindByNameAsync(AdministratorRoleName);
                await userManager.AddToRoleAsync(admin, role.Name);
            }
            else
            {
                IdentityRole<Guid> newRole = new IdentityRole<Guid>(AdministratorRoleName);
                await roleManager.CreateAsync(newRole);
                await userManager.AddToRoleAsync(admin, newRole.Name);
            }
            if (roleCashierExist)
            {
                IdentityRole<Guid> role = await roleManager.FindByNameAsync(CashierRoleName);
                await userManager.AddToRoleAsync(admin, role.Name);
            }
            else
            {
                IdentityRole<Guid> newRole = new IdentityRole<Guid>(CashierRoleName);
                await roleManager.CreateAsync(newRole);
                await userManager.AddToRoleAsync(admin, newRole.Name);
            }
            if (roleUserExist)
            {
                IdentityRole<Guid> role = await roleManager.FindByNameAsync(TechnicianRoleName);
                await userManager.AddToRoleAsync(admin, role.Name);
            }
            else
            {
                IdentityRole<Guid> newRole = new IdentityRole<Guid>(TechnicianRoleName);
                await roleManager.CreateAsync(newRole);
                await userManager.AddToRoleAsync(admin, newRole.Name);
            }

        }
        public static IApplicationBuilder EnableOnlineUsersCheck(this IApplicationBuilder app)
        {
            app.UseMiddleware<OnlineUsersMiddleware>();
            return app;
        }
        public static IApplicationBuilder EnableUsersTracker(this IApplicationBuilder app)
        {
            app.UseMiddleware<UsersTrackerMiddleware>();
            return app;
        }
    }
}
