using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductlineApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedOrders2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("566b9c01-00f5-4c30-a300-9886507592a9"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("f70c0f6e-43d8-4784-8e0f-a32acc7c24c0"));

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("954dff22-70de-4cbc-b002-ee632c9c7e88"), new DateTime(2023, 6, 19, 19, 16, 17, 288, DateTimeKind.Utc).AddTicks(7930), "system", new DateTime(2023, 6, 19, 19, 16, 17, 351, DateTimeKind.Utc).AddTicks(2270), "system", "allegro" },
                    { new Guid("ae194948-df4f-4fed-9431-7fc701e65a69"), new DateTime(2023, 6, 19, 19, 16, 17, 288, DateTimeKind.Utc).AddTicks(7910), "system", new DateTime(2023, 6, 19, 19, 16, 17, 351, DateTimeKind.Utc).AddTicks(1380), "system", "ebay" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("954dff22-70de-4cbc-b002-ee632c9c7e88"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("ae194948-df4f-4fed-9431-7fc701e65a69"));

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("566b9c01-00f5-4c30-a300-9886507592a9"), new DateTime(2023, 6, 19, 18, 29, 10, 122, DateTimeKind.Utc).AddTicks(5070), "system", new DateTime(2023, 6, 19, 18, 29, 10, 253, DateTimeKind.Utc).AddTicks(8440), "system", "ebay" },
                    { new Guid("f70c0f6e-43d8-4784-8e0f-a32acc7c24c0"), new DateTime(2023, 6, 19, 18, 29, 10, 122, DateTimeKind.Utc).AddTicks(5090), "system", new DateTime(2023, 6, 19, 18, 29, 10, 253, DateTimeKind.Utc).AddTicks(8510), "system", "allegro" }
                });
        }
    }
}
