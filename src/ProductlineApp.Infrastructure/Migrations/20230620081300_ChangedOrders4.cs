using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductlineApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedOrders4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("6c32e689-bf46-417a-8453-2fbb11c695d4"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("98044a71-0112-4fe4-b7df-fdc7d98c2005"));

            migrationBuilder.AddColumn<decimal>(
                name: "DeliveryCost",
                table: "Orders",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PlacedAt",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "SubtotalPrice",
                table: "Orders",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrderLines",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("0847775c-ba55-4318-8065-042546b9ca43"), new DateTime(2023, 6, 20, 8, 13, 0, 707, DateTimeKind.Utc).AddTicks(5170), "system", new DateTime(2023, 6, 20, 8, 13, 0, 772, DateTimeKind.Utc).AddTicks(2080), "system", "allegro" },
                    { new Guid("242bae2b-9c50-4ac7-883a-90ed9606667e"), new DateTime(2023, 6, 20, 8, 13, 0, 707, DateTimeKind.Utc).AddTicks(5140), "system", new DateTime(2023, 6, 20, 8, 13, 0, 772, DateTimeKind.Utc).AddTicks(1200), "system", "ebay" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("0847775c-ba55-4318-8065-042546b9ca43"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("242bae2b-9c50-4ac7-883a-90ed9606667e"));

            migrationBuilder.DropColumn(
                name: "DeliveryCost",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PlacedAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SubtotalPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrderLines");

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("6c32e689-bf46-417a-8453-2fbb11c695d4"), new DateTime(2023, 6, 19, 19, 19, 29, 120, DateTimeKind.Utc).AddTicks(4820), "system", new DateTime(2023, 6, 19, 19, 19, 29, 253, DateTimeKind.Utc).AddTicks(9450), "system", "allegro" },
                    { new Guid("98044a71-0112-4fe4-b7df-fdc7d98c2005"), new DateTime(2023, 6, 19, 19, 19, 29, 120, DateTimeKind.Utc).AddTicks(4800), "system", new DateTime(2023, 6, 19, 19, 19, 29, 253, DateTimeKind.Utc).AddTicks(9390), "system", "ebay" }
                });
        }
    }
}
