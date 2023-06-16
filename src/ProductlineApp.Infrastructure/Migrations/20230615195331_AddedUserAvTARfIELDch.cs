using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductlineApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserAvTARfIELDch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("c45d96b1-67ad-44ae-8bae-54904e648531"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("ec0a8470-2748-4919-bc48-2d6348e02bd8"));

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("1a33114f-e717-46dd-89d9-61252e42ca26"), new DateTime(2023, 6, 15, 19, 53, 31, 289, DateTimeKind.Utc).AddTicks(4480), "system", new DateTime(2023, 6, 15, 19, 53, 31, 352, DateTimeKind.Utc).AddTicks(5290), "system", "ebay" },
                    { new Guid("f8ed7776-5ad7-4954-b2fe-3c31fbd0987c"), new DateTime(2023, 6, 15, 19, 53, 31, 289, DateTimeKind.Utc).AddTicks(4500), "system", new DateTime(2023, 6, 15, 19, 53, 31, 352, DateTimeKind.Utc).AddTicks(6400), "system", "allegro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("1a33114f-e717-46dd-89d9-61252e42ca26"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("f8ed7776-5ad7-4954-b2fe-3c31fbd0987c"));

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("c45d96b1-67ad-44ae-8bae-54904e648531"), new DateTime(2023, 6, 15, 17, 42, 40, 380, DateTimeKind.Utc).AddTicks(1020), "system", new DateTime(2023, 6, 15, 17, 42, 40, 492, DateTimeKind.Utc).AddTicks(6040), "system", "ebay" },
                    { new Guid("ec0a8470-2748-4919-bc48-2d6348e02bd8"), new DateTime(2023, 6, 15, 17, 42, 40, 380, DateTimeKind.Utc).AddTicks(1040), "system", new DateTime(2023, 6, 15, 17, 42, 40, 492, DateTimeKind.Utc).AddTicks(6100), "system", "allegro" }
                });
        }
    }
}
