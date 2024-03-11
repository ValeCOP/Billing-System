using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Billing_System.Data.Migrations
{
    public partial class edited_Promotion_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Clients_ClientId",
                table: "Promotions");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_ClientId",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Promotions");

            migrationBuilder.RenameColumn(
                name: "Mounth",
                table: "Promotions",
                newName: "Month");

            migrationBuilder.AddColumn<string>(
                name: "ClientFullName",
                table: "Promotions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientFullName",
                table: "Promotions");

            migrationBuilder.RenameColumn(
                name: "Month",
                table: "Promotions",
                newName: "Mounth");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Promotions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_ClientId",
                table: "Promotions",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Clients_ClientId",
                table: "Promotions",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
