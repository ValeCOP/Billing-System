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
            Database.EnsureCreated();
            //migration
            //Database.Migrate();
        }
        public DbSet<Client> Clients { get; set; } = null!;    
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<TechnicalProblem> TechnicalProblems { get; set; } = null!;

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

            builder.Entity<Client>()
                .HasOne(a => a.ApplicationUser)
                .WithMany(u => u.Clients)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Payment>()
                .HasOne(p => p.ApplicationUser)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Payment>()
                .HasOne(p => p.Client)
                .WithMany(a => a.Payments)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TechnicalProblem>()
                .HasOne(t => t.RegisterProblemUser)
                .WithMany(u => u.RegisteredTechnicalProblems)
                .HasForeignKey(t => t.RegisterProblemUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TechnicalProblem>()
                .HasOne(t => t.ResolvedProblemUser)
                .WithMany(u => u.ResolvedTechnicalProblems)
                .HasForeignKey(t => t.ResolvedProblemUserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }   
    }
}
