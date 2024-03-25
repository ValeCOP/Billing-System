namespace Billing_Systems_Tests.Seed
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

            var client1 = new Client()
            {
                Id = new Guid("1d315603-14bc-4f70-a832-ddcafdd4df21"),
                FullName = "Pesho Peshov",
                ActivationDate = new DateTime(2022, 1, 1),
                ExpiredDate = new DateTime(2023, 1, 1),
                ApplicationUser = user
            };
            var client2 = new Client()
            {
                FullName = "Gosho Goshev",
                ActivationDate = new DateTime(2022, 1, 1),
                ExpiredDate = new DateTime(2023, 1, 1),
                ApplicationUser = user
            };
            var client3 = new Client()
            {
                FullName = "Tosho Toshev",
                ActivationDate = new DateTime(2022, 1, 1),
                ExpiredDate = new DateTime(2023, 1, 1),
                ApplicationUser = user
            };
            var client4 = new Client()
            {
                FullName = "Ivan Ivanov",
                ActivationDate = new DateTime(2022, 1, 1),
                ExpiredDate = new DateTime(2023, 1, 1),
                ApplicationUser = user
            };
            var payment = new Payment
            {
                Name = "Initial",
                Fee = 100,
                Pending = false,
                Receipt = false,
                FromDate = new DateTime(2022, 1, 1),
                ToDate = new DateTime(2023, 1, 1),
                ClientId = new Guid("1d315603-14bc-4f70-a832-ddcafdd4df21"),
                Client = client1
            };
            dbContext.Payments.Add(payment);
            dbContext.Clients.Add(client1);
            dbContext.Clients.Add(client2);
            dbContext.Clients.Add(client3);
            dbContext.Clients.Add(client4);
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }
    }
}