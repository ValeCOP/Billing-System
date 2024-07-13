namespace Billing_System.Data.Configuration
{
    using Billing_System.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {

            builder
                .HasData(new Invoice()
                {
                    Id = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb104a"),
                    InvoiceNumber = "50",
                    CreatedOn = new DateTime(2024, 01, 01),
                    MOL = "Снежана Г. Никова",
                    UIN = "123456789",
                    VATIN = "---",
                    Recipient = "---",
                    Compiler = "Снежана Г. Никова",
                    BankTransfer = true,
                    Cash = false,
                    PaymentId = Guid.Parse("274ec2c5-ec55-42d5-aae7-619004eb104a"),
                    UserId = Guid.Parse("274EC2C5-EC55-42D5-AAE7-619004EB964A"),
                });
        }
    }
}
