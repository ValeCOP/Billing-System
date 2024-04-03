using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Billing_System.Data.Migrations
{
    public partial class seed_Invoices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "BankTransfer", "Cash", "Compiler", "CreatedOn", "InvoiceNumber", "MOL", "PaymentId", "Recipient", "UIN", "UserId", "VATIN" },
                values: new object[] { new Guid("274ec2c5-ec55-42d5-aae7-619004eb104a"), true, false, "Снежана Г. Никова", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "50", "Снежана Г. Никова", new Guid("274ec2c5-ec55-42d5-aae7-619004eb104a"), "---", "123456789", new Guid("274ec2c5-ec55-42d5-aae7-619004eb964a"), "---" });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "BankTransfer", "Cash", "Compiler", "CreatedOn", "InvoiceNumber", "MOL", "PaymentId", "Recipient", "UIN", "UserId", "VATIN" },
                values: new object[] { new Guid("274ec2c5-ec55-42d5-aae7-619004eb104d"), true, false, "Снежана Г. Никова", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "51", "Снежана Г. Никова", new Guid("274ec2c5-ec55-42d5-aae7-619004eb104d"), "---", "123456789", new Guid("274ec2c5-ec55-42d5-aae7-619004eb964b"), "---" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("274ec2c5-ec55-42d5-aae7-619004eb104a"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("274ec2c5-ec55-42d5-aae7-619004eb104d"));
        }
    }
}
