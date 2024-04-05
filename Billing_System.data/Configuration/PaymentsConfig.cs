namespace Billing_System.Data.Configuration
{
    using Billing_System.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PaymentsConfig : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder
                .HasData(new Payment()
                {
                    Id = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb104a"),
                    Name = "Initial payment",
                    Fee = 22,
                    InstallationFee = 0,
                    Pending = false,
                    Receipt = true,
                    FromDate = new DateTime(2024, 01, 01),
                    ToDate = new DateTime(2024, 02, 01),
                    ClientId = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb964a"),
                    UserId = Guid.Parse("274EC2C5-EC55-42D5-AAE7-619004EB964A"),

                });
        }
    }
}
