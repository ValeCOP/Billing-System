namespace Billing_System.Data
{
    using Billing_System.Data.Configuration;
    using Billing_System.Data.Entities;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class BillingDbContext : IdentityDbContext<ApplicationUser,IdentityRole<Guid>,Guid>
    {
        public BillingDbContext(DbContextOptions<BillingDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
        public DbSet<Client> Clients { get; set; } = null!;    
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<TechnicalProblem> TechnicalProblems { get; set; } = null!;
        public DbSet<Expense> Expenses { get; set; } = null!;
        public DbSet<Promotion> Promotions { get; set; } = null!;
        public DbSet<Invoice> Invoices { get; set; } = null!;
        public DbSet<Chat> Chats { get; set; } = null!;

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        override protected void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApplicationUserConfig());
            builder.ApplyConfiguration(new ClientsConfig());
            builder.ApplyConfiguration(new PaymentsConfig());
            builder.ApplyConfiguration(new InvoiceConfig());

            builder.Entity<Payment>()
                .HasOne(p => p.Client)
                .WithMany(c => c!.Payments)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Payment>()
                .HasOne(p => p.ApplicationUser)
                .WithMany(u => u!.Payments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
           
            builder.Entity<Expense>()
                .Property(e => e.Value)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(builder);
        }   
    }
}
