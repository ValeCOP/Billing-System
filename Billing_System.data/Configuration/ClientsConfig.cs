namespace Billing_System.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Billing_System.Data.Entities;



    public class ClientsConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Client> builder)
        {
            builder.
                HasData(new Client()
                {
                    Id = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb964a"),
                    FullName = "Валентин Иванов Василев",
                    ActivationDate = new DateTime(2024, 01, 01),
                    ExpiredDate = new DateTime(2024, 02, 01),
                    UserId = Guid.Parse("274EC2C5-EC55-42D5-AAE7-619004EB964A"),
                },
                new Client()
                {
                    Id = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb964d"),
                    FullName = "Авксентия Мариус Койнарска",
                    ActivationDate = new DateTime(2024, 01, 01),
                    ExpiredDate = new DateTime(2024, 02, 01),
                    UserId = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb964b"),
                });
        }
    }
}
