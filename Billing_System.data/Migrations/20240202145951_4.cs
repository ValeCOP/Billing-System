using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Billing_System.Data.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientFullName",
                table: "TechnicalProblems");

            migrationBuilder.AlterColumn<string>(
                name: "Solution",
                table: "TechnicalProblems",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "TechnicalProblems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisteredOn",
                table: "TechnicalProblems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ResolvedOn",
                table: "TechnicalProblems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalProblems_ClientId",
                table: "TechnicalProblems",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalProblems_Clients_ClientId",
                table: "TechnicalProblems",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalProblems_Clients_ClientId",
                table: "TechnicalProblems");

            migrationBuilder.DropIndex(
                name: "IX_TechnicalProblems_ClientId",
                table: "TechnicalProblems");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "TechnicalProblems");

            migrationBuilder.DropColumn(
                name: "RegisteredOn",
                table: "TechnicalProblems");

            migrationBuilder.DropColumn(
                name: "ResolvedOn",
                table: "TechnicalProblems");

            migrationBuilder.AlterColumn<string>(
                name: "Solution",
                table: "TechnicalProblems",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientFullName",
                table: "TechnicalProblems",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
