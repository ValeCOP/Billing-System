using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Billing_System.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivatedClients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ActivationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivatedClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivatedClients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalProblems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterProblemUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResolvedProblemUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientFullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Solved = table.Column<bool>(type: "bit", nullable: false),
                    Solution = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalProblems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalProblems_AspNetUsers_RegisterProblemUserId",
                        column: x => x.RegisterProblemUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TechnicalProblems_AspNetUsers_ResolvedProblemUserId",
                        column: x => x.ResolvedProblemUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InstallationFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pending = table.Column<bool>(type: "bit", nullable: false),
                    Receipt = table.Column<bool>(type: "bit", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_ActivatedClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ActivatedClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("274ec2c5-ec55-42d5-aae7-619004eb964a"), 0, "6Q2Z6Z2Z6Z2Z6Z2Z6Z2Z6Z2Z6Z2Z6Z2Y", "admin@infocastsystems.eu", true, false, null, "ADMIN@INFOCASTSYSTEMS.EU", "ADMIN", "AQAAAAEAACcQAAAAEFRsV24WfMr17Js+gGF4sz5rFta0QEcY+AdZV6sn2Kvg3A7k6MaEm7G6lt1rRGQffA==", null, true, "6Q2Z6Z2Z6Z2Z6Z2Z6Z2Z6Z2Z6Z2Z6Z2Z", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("274ec2c5-ec55-42d5-aae7-619004eb964b"), 0, "6Q2Z6Z2Z6Z2Z6Z2Z6Z2Z6Z2Z8Z2Z6Z2Y", "user@infocastsystems.eu", true, false, null, "USER@INFOCASTSYSTEMS.EU", "USER", "AQAAAAEAACcQAAAAEFRsV24WfMr17Js+gGF4sz5rFta0QEcY+AdZV6sn2Kvg3A7k6MaEm7G6lt1rRGQffA==", null, true, "6Q2Z6Z2Z6Z2Z6Z2Z6Z2Z6Z2Z6Z2Z8Z2Z", false, "user" });

            migrationBuilder.InsertData(
                table: "ActivatedClients",
                columns: new[] { "Id", "ActivationDate", "Address", "Comments", "ExpiredDate", "FullName", "UserId" },
                values: new object[] { new Guid("274ec2c5-ec55-42d5-aae7-619004eb964a"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Валентин Иванов Василев", new Guid("274ec2c5-ec55-42d5-aae7-619004eb964a") });

            migrationBuilder.InsertData(
                table: "ActivatedClients",
                columns: new[] { "Id", "ActivationDate", "Address", "Comments", "ExpiredDate", "FullName", "UserId" },
                values: new object[] { new Guid("274ec2c5-ec55-42d5-aae7-619004eb964d"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Авксентия Мариус Койнарска", new Guid("274ec2c5-ec55-42d5-aae7-619004eb964b") });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "ClientId", "Fee", "FromDate", "InstallationFee", "Name", "Pending", "Receipt", "ToDate", "UserId" },
                values: new object[] { new Guid("274ec2c5-ec55-42d5-aae7-619004eb104a"), new Guid("274ec2c5-ec55-42d5-aae7-619004eb964a"), 22m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, "Initial payment", false, true, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("274ec2c5-ec55-42d5-aae7-619004eb964a") });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "ClientId", "Fee", "FromDate", "InstallationFee", "Name", "Pending", "Receipt", "ToDate", "UserId" },
                values: new object[] { new Guid("274ec2c5-ec55-42d5-aae7-619004eb104d"), new Guid("274ec2c5-ec55-42d5-aae7-619004eb964d"), 22m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, "Initial payment", false, true, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("274ec2c5-ec55-42d5-aae7-619004eb964b") });

            migrationBuilder.CreateIndex(
                name: "IX_ActivatedClients_UserId",
                table: "ActivatedClients",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ClientId",
                table: "Payments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalProblems_RegisterProblemUserId",
                table: "TechnicalProblems",
                column: "RegisterProblemUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalProblems_ResolvedProblemUserId",
                table: "TechnicalProblems",
                column: "ResolvedProblemUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "TechnicalProblems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ActivatedClients");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
