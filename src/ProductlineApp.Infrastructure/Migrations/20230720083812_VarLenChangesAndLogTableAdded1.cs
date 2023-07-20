using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductlineApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VarLenChangesAndLogTableAdded1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("4323cf89-a174-4cf7-9cbc-49db142d846d"), new DateTime(2023, 7, 20, 8, 38, 12, 414, DateTimeKind.Utc).AddTicks(7340), "system", new DateTime(2023, 7, 20, 8, 38, 12, 478, DateTimeKind.Utc).AddTicks(9980), "system", "allegro" },
                    { new Guid("8dd2c1ee-6748-4e51-b494-4888b149e448"), new DateTime(2023, 7, 20, 8, 38, 12, 414, DateTimeKind.Utc).AddTicks(7320), "system", new DateTime(2023, 7, 20, 8, 38, 12, 478, DateTimeKind.Utc).AddTicks(9060), "system", "ebay" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("4323cf89-a174-4cf7-9cbc-49db142d846d"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("8dd2c1ee-6748-4e51-b494-4888b149e448"));
        }
    }
}
