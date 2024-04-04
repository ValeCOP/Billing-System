namespace Billing_System
{
    using Billing_System.Core.CustomBinders;
    using Billing_System.Core.CustomExstensions;
    using Billing_System.CustomExtensions;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApplicationServices();
            builder.Services.AddApplicationIdentity();
            builder.Services.AddApplicationDbContext(builder.Configuration);
            builder.Services.AddMemoryCache();
           
            builder.Services.AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                });

            builder.Services.AddAntiforgery(BindPropertiesAttribute =>
            {
                BindPropertiesAttribute.FormFieldName = "X-CSRF-TOKEN";
                BindPropertiesAttribute.HeaderName = "X-CSRF-TOKEN";
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.EnableOnlineUsersCheck();

            app.EnableUsersTracker();

            await app.SeedAdmin();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                                       name: "Areas",
                                       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                                       name: "default",
                                       pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });

            await app.RunAsync();
        }
    }
}