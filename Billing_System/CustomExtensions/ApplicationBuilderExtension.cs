namespace Billing_System.Core.CustomExstensions
{
    using Billing_System.Core.CustomExtensions;
    using Billing_System.CustomExtensions;
    using Billing_System.Data.Entities;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    using static Billing_System.Utilities.ValidationConstants.ValidationConstants.ApplicationUsers;

    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder SeedAdmin(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            IServiceProvider services = serviceScope.ServiceProvider;
            UserManager<ApplicationUser> userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole<Guid>> roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                ApplicationUser admin = await userManager.FindByEmailAsync(AdminEmail);

                var roleExist = await roleManager.RoleExistsAsync(AdminRoleName);
                if (roleExist)
                {
                    IdentityRole<Guid> role = await roleManager.FindByNameAsync(AdminRoleName);
                    await userManager.AddToRoleAsync(admin, role.Name);
                    return;
                }
                IdentityRole<Guid> newRole = new IdentityRole<Guid>(AdminRoleName);
                await roleManager.CreateAsync(newRole);
                await userManager.AddToRoleAsync(admin, newRole.Name);


            }).GetAwaiter().GetResult();
            return app;
        }
        public static IApplicationBuilder EnableOnlineUsersCheck(this IApplicationBuilder app)
        {
            app.UseMiddleware<OnlineUsersMiddleware>();
            return app;
        }
    }
}
