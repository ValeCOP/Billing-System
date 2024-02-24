using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Billing_System.Data.Migrations
{
    public partial class changename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivatedClients_AspNetUsers_UserId",
                table: "ActivatedClients");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_ActivatedClients_ClientId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivatedClients",
                table: "ActivatedClients");

            migrationBuilder.RenameTable(
                name: "ActivatedClients",
                newName: "Clients");

            migrationBuilder.RenameIndex(
                name: "IX_ActivatedClients_UserId",
                table: "Clients",
                newName: "IX_Clients_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_UserId",
                table: "Clients",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Clients_ClientId",
                table: "Payments",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_UserId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Clients_ClientId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "ActivatedClients");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_UserId",
                table: "ActivatedClients",
                newName: "IX_ActivatedClients_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivatedClients",
                table: "ActivatedClients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivatedClients_AspNetUsers_UserId",
                table: "ActivatedClients",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_ActivatedClients_ClientId",
                table: "Payments",
                column: "ClientId",
                principalTable: "ActivatedClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
