using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductlineApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserAvTARfIELD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("6e4e2024-4a3a-4f26-9229-41228e3fb8f4"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("85a8c28c-5cd6-44af-8fef-f16a9293bcce"));

            migrationBuilder.AddColumn<string>(
                name: "Avatar_Name",
                table: "Users",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Avatar_Url",
                table: "Users",
                type: "varchar(500)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("c45d96b1-67ad-44ae-8bae-54904e648531"), new DateTime(2023, 6, 15, 17, 42, 40, 380, DateTimeKind.Utc).AddTicks(1020), "system", new DateTime(2023, 6, 15, 17, 42, 40, 435, DateTimeKind.Utc).AddTicks(5530), "system", "ebay" },
                    { new Guid("ec0a8470-2748-4919-bc48-2d6348e02bd8"), new DateTime(2023, 6, 15, 17, 42, 40, 380, DateTimeKind.Utc).AddTicks(1040), "system", new DateTime(2023, 6, 15, 17, 42, 40, 435, DateTimeKind.Utc).AddTicks(6440), "system", "allegro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("c45d96b1-67ad-44ae-8bae-54904e648531"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("ec0a8470-2748-4919-bc48-2d6348e02bd8"));

            migrationBuilder.DropColumn(
                name: "Avatar_Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Avatar_Url",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("6e4e2024-4a3a-4f26-9229-41228e3fb8f4"), new DateTime(2023, 5, 16, 7, 11, 48, 140, DateTimeKind.Utc).AddTicks(8320), "system", new DateTime(2023, 5, 16, 7, 11, 48, 264, DateTimeKind.Utc).AddTicks(6510), "system", "allegro" },
                    { new Guid("85a8c28c-5cd6-44af-8fef-f16a9293bcce"), new DateTime(2023, 5, 16, 7, 11, 48, 140, DateTimeKind.Utc).AddTicks(8300), "system", new DateTime(2023, 5, 16, 7, 11, 48, 264, DateTimeKind.Utc).AddTicks(6450), "system", "ebay" }
                });
        }
    }
}
