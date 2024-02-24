namespace ServiceTests
{
    using Billing_System.Data;
    using Billing_System.Data.Entities;

    public static class DatabaseSeeder
    {
        public static void SeedDatabase(BillingDbContext dbContext)
        {
            var user = new ApplicationUser()
            {
                UserName = "Pesho",
                NormalizedUserName = "PESHO",
                Email = "pesho@agents.com",
                NormalizedEmail = "PESHO@AGENTS.COM",
                EmailConfirmed = true,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "caf271d7-0ba7-4ab1-8d8d-6d0e3711c27d",
                SecurityStamp = "ca32c787-626e-4234-a4e4-8c94d85a2b1c",
                TwoFactorEnabled = false,
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }
    }
}
