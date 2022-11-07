using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpeditionFuelsHub.Infrastructure.Migrations
{
    public partial class AllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DistributionChannels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributionChannels", x => x.Id);
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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Code = table.Column<byte>(type: "tinyint", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    VehicleRegistrationDocumentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillLadings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GrossStandardVolume = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    Mass = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PurposeId = table.Column<int>(type: "int", nullable: false),
                    DistributionChannelId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    FuelDispenserId = table.Column<int>(type: "int", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WriterUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillLadings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillLadings_AspNetUsers_WriterUserId",
                        column: x => x.WriterUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "d7a2cd56-c88f-405e-b8bf-44d06e4a43f0", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEBirgBQDHHKNOmHO6F9GGcMif+B6SHz0Q22IvWnagAOgILGwdsIrnAbcilOej+7Tsg==", null, false, "a577501f-fb3f-4e95-bdb2-e8261d9a0c99", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "583c7c12-4aab-4345-bf4d-5bc1cc59f442", "fdispenser@mail.com", false, false, null, "fdispenser@mail.com", "fdispenser@mail.com", "AQAAAAEAACcQAAAAEGPowsvd2NA41Kjwl7TE7TZfWIgCNZzDRfeMqC55HYeX7cd7fWHn5O/pUPbkBHn4Xg==", null, false, "7096191a-5c21-4b76-a401-b55a562a7a64", false, "fdispenser@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "DistributionChannels",
                columns: new[] { "Id", "IsValid", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3913), "DistributionChannel_1" },
                    { 2, true, new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3921), "DistributionChannel_2" },
                    { 3, true, new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3924), "DistributionChannel_3" },
                    { 4, true, new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3927), "DistributionChannel_4" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "FullName", "IsValid", "ModifiedOn", "ProductCode" },
                values: new object[,]
                {
                    { 1, "А-95Н", true, new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3143), "552" },
                    { 2, "А-95НВ", true, new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3188), "101" },
                    { 3, "А-98 ЕКТО", true, new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3191), "102" },
                    { 4, "А-98 Н1", true, new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3194), "105" }
                });

            migrationBuilder.InsertData(
                table: "Purposes",
                columns: new[] { "Id", "Code", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, (byte)65, new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3674), "ForCountry" },
                    { 2, (byte)66, new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3687), "ForCountry_1" },
                    { 3, (byte)64, new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3690), "ForCountry_3" },
                    { 4, (byte)67, new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3692), "ForCountry_4" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "IsValid", "ModifiedOn", "RegistrationNumber", "VehicleRegistrationDocumentNumber" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3811), "AV9876BH", "ACF4566ASSSS" },
                    { 2, false, new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3822), "BB9876aa", "ACF4566ASSSSFGR" }
                });

            migrationBuilder.InsertData(
                table: "FuelDispensers",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "+359888888888", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "BillLadings",
                columns: new[] { "Id", "CreatedOn", "DistributionChannelId", "FuelDispenserId", "GrossStandardVolume", "IsValid", "Mass", "ModifiedOn", "ProductId", "PurposeId", "VehicleId", "WriterUserId" },
                values: new object[] { 1, new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(4039), 1, 1, 9768.876m, true, 3423.879m, new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(4045), 2, 2, 2, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" });

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
                name: "IX_BillLadings_WriterUserId",
                table: "BillLadings",
                column: "WriterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelDispensers_UserId",
                table: "FuelDispensers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillLadings");

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

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");
        }
    }
}
