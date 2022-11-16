using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpeditionFuelsHub.Infrastructure.Migrations
{
    public partial class Initial_PlusRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                name: "DistributionChannels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributionChannels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ProductCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purposes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purposes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleRegistrationDocumentNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "FuelDispensers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelDispensers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuelDispensers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillLadings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrossStandardVolume = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    Mass = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PurposeId = table.Column<int>(type: "int", nullable: false),
                    DistributionChannelId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    FuelDispenserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillLadings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillLadings_DistributionChannels_DistributionChannelId",
                        column: x => x.DistributionChannelId,
                        principalTable: "DistributionChannels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillLadings_FuelDispensers_FuelDispenserId",
                        column: x => x.FuelDispenserId,
                        principalTable: "FuelDispensers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillLadings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillLadings_Purposes_PurposeId",
                        column: x => x.PurposeId,
                        principalTable: "Purposes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillLadings_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "115e174e-5g0e-i46f-86af-458mkifd7210", "97344bfb-48dc-4bc3-acbe-07f62a722cda", "Fdispenser", "FDISPENSER" },
                    { "2787b74e-3c0v-466f-m8af-654d56fd9010", "baedf729-5623-477b-bece-f48cf56a7a94", "User", "User" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "2c346c81-8146-41be-8959-b8c67a44da08", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "beea2d36-848d-4821-9bcc-a0f737c12890", "guest@mail.com", false, false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEBvw5vRQuM41wozy8UQmWTykeMv02KXo3xgqQ9Aa/zJsGy5Yp946BXSV8JcJBCszTQ==", null, false, "ec677a64-6cbb-496e-aeb3-9fd24fac1da4", false, "guest" },
                    { "87612856-d498-4529-b453-bgrfd8395082", 0, "108a8e0c-1c8c-41df-9d59-6472a318c862", "admin@mail.com", false, false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEANqBibmX6OuA8DmkHBNanTVmREf/IIoIVvfO8CilTE13khvGwvw6+fitQugkmYfDw==", null, false, "8c380dca-d024-4175-ad79-c0543fbf4d36", false, "admin" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "c76dc2e3-200a-4107-8fce-861ceaca330a", "fdispenser@mail.com", false, false, null, "FDISPENSER@MAIL.COM", "FDISPENSER", "AQAAAAEAACcQAAAAEKUclK5lTdp7MVhEuX30TSCYPJxjVZLwnR7yeoCm5QneZfsfuWAbDDEBIQjOv0HytA==", null, false, "d328f769-4b32-4241-b32a-11c0c38bfd31", false, "fdispenser" }
                });

            migrationBuilder.InsertData(
                table: "DistributionChannels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "For Country" },
                    { 2, "EU" },
                    { 3, "Export" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "FullName", "ProductCode" },
                values: new object[,]
                {
                    { 1, "Биодизел", 100 },
                    { 2, "Авт.бензин А-100Н-9%Биоетанол", 200 },
                    { 3, "А-98 ЕКТО", 300 },
                    { 4, "А-98 Н1", 400 }
                });

            migrationBuilder.InsertData(
                table: "Purposes",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, 11, "Отложен акциз - до данъчен склад в страната" },
                    { 2, 710, "Съдържащи биоетанол" },
                    { 3, 700, "Съдържащи биодизел" },
                    { 4, 400, "Крайни потребители" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "RegistrationNumber", "VehicleRegistrationDocumentNumber" },
                values: new object[,]
                {
                    { 1, "AV9876BH", "ACF4566AS" },
                    { 2, "BB9876АА", "GFR768987" },
                    { 3, "AB4576АC", "DFR400987" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2787b74e-3c0v-466f-m8af-654d56fd9010", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "87612856-d498-4529-b453-bgrfd8395082" },
                    { "115e174e-5g0e-i46f-86af-458mkifd7210", "dea12856-c198-4129-b3f3-b893d8395082" }
                });

            migrationBuilder.InsertData(
                table: "FuelDispensers",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "+359888888888", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "BillLadings",
                columns: new[] { "Id", "CreatedOn", "DistributionChannelId", "FuelDispenserId", "GrossStandardVolume", "ImageUrl", "Mass", "ProductId", "PurposeId", "VehicleId" },
                values: new object[] { 1, new DateTime(2022, 11, 16, 11, 8, 13, 897, DateTimeKind.Local).AddTicks(2945), 1, 1, 9768.876m, "https://i.trade-cloud.com.cn/upload/6653/image/20211230/2_182318.jpg", 3423.879m, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "BillLadings",
                columns: new[] { "Id", "CreatedOn", "DistributionChannelId", "FuelDispenserId", "GrossStandardVolume", "ImageUrl", "Mass", "ProductId", "PurposeId", "VehicleId" },
                values: new object[] { 2, new DateTime(2022, 11, 16, 11, 8, 13, 897, DateTimeKind.Local).AddTicks(2993), 2, 1, 9345768.876m, "https://autoline.bg/img/s/vlekach-MAN-TGS-18-400---1598979707951979529_big--20090119595756984600.jpg", 34453423.879m, 2, 2, 1 });

            migrationBuilder.InsertData(
                table: "BillLadings",
                columns: new[] { "Id", "CreatedOn", "DistributionChannelId", "FuelDispenserId", "GrossStandardVolume", "ImageUrl", "Mass", "ProductId", "PurposeId", "VehicleId" },
                values: new object[] { 3, new DateTime(2022, 11, 16, 11, 8, 13, 897, DateTimeKind.Local).AddTicks(2997), 3, 1, 93768.876m, "https://bg.csc-trucks.com/uploads/202221798/foton-10-000-liters-oil-tank-truck23496909900.jpg", 344423.879m, 3, 3, 3 });

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
                name: "IX_BillLadings_DistributionChannelId",
                table: "BillLadings",
                column: "DistributionChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_BillLadings_FuelDispenserId",
                table: "BillLadings",
                column: "FuelDispenserId");

            migrationBuilder.CreateIndex(
                name: "IX_BillLadings_ProductId",
                table: "BillLadings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BillLadings_PurposeId",
                table: "BillLadings",
                column: "PurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_BillLadings_VehicleId",
                table: "BillLadings",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelDispensers_UserId",
                table: "FuelDispensers",
                column: "UserId");
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
                name: "BillLadings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DistributionChannels");

            migrationBuilder.DropTable(
                name: "FuelDispensers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Purposes");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
