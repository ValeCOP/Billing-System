namespace Billing_System.CustomExtensions
{
    using Billing_System.ActionFilters;
    using Billing_System.Core.Contracts.Archive;
    using Billing_System.Core.Contracts.Chat;
    using Billing_System.Core.Contracts.Clients;
    using Billing_System.Core.Contracts.Expense;
    using Billing_System.Core.Contracts.Home;
    using Billing_System.Core.Contracts.Invoice;
    using Billing_System.Core.Contracts.MailSender;
    using Billing_System.Core.Contracts.Payments;
    using Billing_System.Core.Contracts.Promotion;
    using Billing_System.Core.Contracts.Receipt;
    using Billing_System.Core.Contracts.TechnicalProblemService;
    using Billing_System.Core.Contracts.Users;
    using Billing_System.Core.MailSender;
    using Billing_System.Core.Services.Archive;
    using Billing_System.Core.Services.Chat;
    using Billing_System.Core.Services.Clients;
    using Billing_System.Core.Services.Expense;
    using Billing_System.Core.Services.Home;
    using Billing_System.Core.Services.Invoice;
    using Billing_System.Core.Services.Payments;
    using Billing_System.Core.Services.Promotion;
    using Billing_System.Core.Services.Receipt;
    using Billing_System.Core.Services.TechnicalProblem;
    using Billing_System.Core.Services.Users;
    using Billing_System.Data;

    using Billing_System.Data.Entities;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddHttpClient("BillingServer").ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IClientsService, ClientService>();
            services.AddScoped<IPaymentsService, PaymentService>();
            services.AddScoped<IReceiptService, ReceiptService>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IArchiveService, ArchiveService>();
            services.AddScoped<ITechnicalProblemService, TechnicalProblemService>();
            services.AddScoped<ISendMail, SendMail>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IPromotionService, PromotionService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<LogActionFilter>();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<BillingDbContext>();

            services.ConfigureApplicationCookie(option =>
            {
                option.Cookie.HttpOnly = true;
                option.ExpireTimeSpan = TimeSpan.FromMinutes(50);
                option.SlidingExpiration = true;
                option.Cookie.SameSite = SameSiteMode.Strict;
                option.LoginPath = "/Identity/Account/Login";
            });

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection")
               ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<BillingDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
    }
}
