using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Billing_System.Data.Migrations
{
    public partial class edited_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("274ec2c5-ec55-42d5-aae7-619004eb104d"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("274ec2c5-ec55-42d5-aae7-619004eb104d"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("274ec2c5-ec55-42d5-aae7-619004eb964d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("274ec2c5-ec55-42d5-aae7-619004eb964b"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("274ec2c5-ec55-42d5-aae7-619004eb964b"), 0, "6Q2Z6Z2Z6Z2Z6Z2Z6Z2Z6Z2Z8Z2Z6Z2Y", "user@infocastsystems.eu", true, false, null, "USER@INFOCASTSYSTEMS.EU", "USER", "AQAAAAEAACcQAAAAEFRsV24WfMr17Js+gGF4sz5rFta0QEcY+AdZV6sn2Kvg3A7k6MaEm7G6lt1rRGQffA==", null, true, "6Q2Z6Z2Z6Z2Z6Z2Z6Z2Z6Z2Z6Z2Z8Z2Z", false, "user" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "ActivationDate", "Address", "Comments", "Email", "ExpiredDate", "FullName", "Phone", "UserId" },
                values: new object[] { new Guid("274ec2c5-ec55-42d5-aae7-619004eb964d"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ул. Цар Симеон 2", null, "test2@gmail.com", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Авксентия Мариус Койнарска", "0888888889", new Guid("274ec2c5-ec55-42d5-aae7-619004eb964b") });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "ClientId", "Fee", "FromDate", "InstallationFee", "Name", "Pending", "Receipt", "ToDate", "UserId" },
                values: new object[] { new Guid("274ec2c5-ec55-42d5-aae7-619004eb104d"), new Guid("274ec2c5-ec55-42d5-aae7-619004eb964d"), 22m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, "Initial payment", false, true, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("274ec2c5-ec55-42d5-aae7-619004eb964b") });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "BankTransfer", "Cash", "Compiler", "CreatedOn", "InvoiceNumber", "MOL", "PaymentId", "Recipient", "UIN", "UserId", "VATIN" },
                values: new object[] { new Guid("274ec2c5-ec55-42d5-aae7-619004eb104d"), true, false, "Снежана Г. Никова", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "51", "Снежана Г. Никова", new Guid("274ec2c5-ec55-42d5-aae7-619004eb104d"), "---", "123456789", new Guid("274ec2c5-ec55-42d5-aae7-619004eb964b"), "---" });
        }
    }
}
