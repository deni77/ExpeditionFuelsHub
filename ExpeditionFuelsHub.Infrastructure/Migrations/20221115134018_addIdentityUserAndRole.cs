using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpeditionFuelsHub.Infrastructure.Migrations
{
    public partial class addIdentityUserAndRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81b67ad9-2870-401b-9899-982355abd88c", "AQAAAAEAACcQAAAAEFPnehOSWCAgUHszuQwlz6fH9SfYwNfvsJY8MwK/IWSSP9DivYL2ctaTxUykdujy9A==", "b6d8140b-9454-416f-a97c-1cd79fd49095" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03b2d06c-a542-4cd8-98af-5d9708183ec3", "AQAAAAEAACcQAAAAEAi/yTmZ4f/aLB+v69A6JEF4h92i+7W2kKvd+t8VRH09KI+Vs9DvE2G4UyM+c587ZQ==", "2f7ac8c6-7845-4242-a148-7a32425f5aae" });

            migrationBuilder.UpdateData(
                table: "BillLadings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 15, 15, 40, 18, 291, DateTimeKind.Local).AddTicks(4809));

            migrationBuilder.UpdateData(
                table: "BillLadings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 15, 15, 40, 18, 291, DateTimeKind.Local).AddTicks(4858));

            migrationBuilder.UpdateData(
                table: "BillLadings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 15, 15, 40, 18, 291, DateTimeKind.Local).AddTicks(4861));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01fa30aa-e075-4266-822c-92e24749d51d", "AQAAAAEAACcQAAAAED53IfcR7m34qjcTJV7NbY4yVGmnPEwF5Ho9PXgg+EDZ++2SMdeXTTozQwfrdyXpQw==", "33f93673-21df-4fd3-a164-9e0dd764efa8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3f9facc-55e6-4ca0-8098-8163514163e9", "AQAAAAEAACcQAAAAEAMU3IJ2nS0z6LVUZIGIt6tMm5ZNpTGJ/2JaFt0uByxorRybbfNBMViB/21ylCJlLQ==", "5b7d3de6-e9c6-4d40-87ca-bdf66d201934" });

            migrationBuilder.UpdateData(
                table: "BillLadings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 15, 10, 3, 8, 390, DateTimeKind.Local).AddTicks(3542));

            migrationBuilder.UpdateData(
                table: "BillLadings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 15, 10, 3, 8, 390, DateTimeKind.Local).AddTicks(3593));

            migrationBuilder.UpdateData(
                table: "BillLadings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 15, 10, 3, 8, 390, DateTimeKind.Local).AddTicks(3599));
        }
    }
}
