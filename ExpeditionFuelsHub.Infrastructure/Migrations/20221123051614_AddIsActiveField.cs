using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpeditionFuelsHub.Infrastructure.Migrations
{
    public partial class AddIsActiveField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "BillLadings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "115e174e-5g0e-i46f-86af-458mkifd7210",
                column: "ConcurrencyStamp",
                value: "e7b7a755-4acd-4883-a2cb-d2a5d1789630");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2787b74e-3c0v-466f-m8af-654d56fd9010",
                column: "ConcurrencyStamp",
                value: "ecf5be05-4db6-49ad-8680-f6ce3cee1d4c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "70548479-3ca5-428d-a3ff-baa2586b62ac");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dda35dbd-19d2-4628-9a3c-e129433549b1", "AQAAAAEAACcQAAAAEN88UlkByP2o2X9Pyt3eF0A7lELeBiqeNgQuXGu+sYWzIzhPePINR0FDire/hcbHew==", "c6fdf8d9-fb06-4867-a8d1-1bc61749b6b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "87612856-d498-4529-b453-bgrfd8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8f00c28-3363-4c1c-89b6-683bba053689", "AQAAAAEAACcQAAAAEHygQ5N7trqIpTlL98JpNGGTsd0d0Dt994Ka3cUMncOop7Ji+I3Y9iS0aosTh5QOSw==", "17ff9f86-a91e-42d2-baa4-fafe14c5f47f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b836da8c-4e75-48ef-a1fb-588d6ea83053", "AQAAAAEAACcQAAAAEG4qoQB2E1pCce3WndodvK+vY7DH1fcfVyOQwhXDBV7d+H2TXENQes4dpkJ2sMJtiA==", "c3e9aec7-aca2-47bc-bc5f-66fca576ac67" });

            migrationBuilder.UpdateData(
                table: "BillLadings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "IsActive" },
                values: new object[] { new DateTime(2022, 11, 23, 7, 16, 14, 81, DateTimeKind.Local).AddTicks(1362), true });

            migrationBuilder.UpdateData(
                table: "BillLadings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "IsActive" },
                values: new object[] { new DateTime(2022, 11, 23, 7, 16, 14, 81, DateTimeKind.Local).AddTicks(1410), true });

            migrationBuilder.UpdateData(
                table: "BillLadings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "IsActive" },
                values: new object[] { new DateTime(2022, 11, 23, 7, 16, 14, 81, DateTimeKind.Local).AddTicks(1414), true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "BillLadings");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "115e174e-5g0e-i46f-86af-458mkifd7210",
                column: "ConcurrencyStamp",
                value: "2d8b2d74-b098-4e34-ae7c-5edfa99ec322");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2787b74e-3c0v-466f-m8af-654d56fd9010",
                column: "ConcurrencyStamp",
                value: "fea9a4ec-1a90-493e-a01b-82adf6c32ee3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "1a35d8f3-1620-4970-8418-271b06f921cd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0a6896c-a189-4f3a-b15d-8962fb981040", "AQAAAAEAACcQAAAAEMLo8z7osRMVFtucDDZ2ABXYBzkOsqbHrDhjTHSEUWIKtxuCtv6JsFpmCq6TJoxLPg==", "9f19aa29-f3d5-4f47-9b1a-f218b2b2b2c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "87612856-d498-4529-b453-bgrfd8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8983d7f2-34af-4c75-843a-605584df06cc", "AQAAAAEAACcQAAAAEPnWxgBxwBvEuTVFM3td8MdQ4Ay5suTtp0S2A69NB/hJzpydk6WqUcNcbGH9vjz2NA==", "d23125cc-1a8a-4f92-a4ef-34526d4178dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5a71602-d4c9-4aad-8747-80648dffa10f", "AQAAAAEAACcQAAAAEDF2JEeGgBNvDOt9jLfVfrC+QsFiYo3t+wYLDAVoFRaAuIadXa9y+76D83kAv5kUhg==", "60ddfc86-16d3-4dd4-9037-7d983cbc38ff" });

            migrationBuilder.UpdateData(
                table: "BillLadings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 18, 10, 9, 31, 840, DateTimeKind.Local).AddTicks(9853));

            migrationBuilder.UpdateData(
                table: "BillLadings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 18, 10, 9, 31, 840, DateTimeKind.Local).AddTicks(9903));

            migrationBuilder.UpdateData(
                table: "BillLadings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 18, 10, 9, 31, 840, DateTimeKind.Local).AddTicks(9907));
        }
    }
}
