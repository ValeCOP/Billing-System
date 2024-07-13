namespace ISP_Clients_Web_API.Data
{
    using ISP_Clients_Web_API.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class BillingApiDBContext : DbContext
    {
        public BillingApiDBContext(DbContextOptions<BillingApiDBContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
        public DbSet<Client> ClientsISP { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            var clients = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText("clients.json"));
            //seed clients
            modelBuilder.Entity<Client>().HasData(clients!);
            base.OnModelCreating(modelBuilder);
        }

    }
}
