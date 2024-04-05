namespace Billing_System.Data.Configuration
{
    using Billing_System.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
       
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .HasData(new ApplicationUser()
                {
                    Id = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb964a"),
                    UserName = "admin",
                    Email = "admin@infocastsystems.eu",
                    NormalizedEmail = "ADMIN@INFOCASTSYSTEMS.EU",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = "AQAAAAEAACcQAAAAEFRsV24WfMr17Js+gGF4sz5rFta0QEcY+AdZV6sn2Kvg3A7k6MaEm7G6lt1rRGQffA==",
                    EmailConfirmed = true,
                    SecurityStamp = "6Q2Z6Z2Z6Z2Z6Z2Z6Z2Z6Z2Z6Z2Z6Z2Z",
                    ConcurrencyStamp = "6Q2Z6Z2Z6Z2Z6Z2Z6Z2Z6Z2Z6Z2Z6Z2Y",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                });
        }
    }
}
