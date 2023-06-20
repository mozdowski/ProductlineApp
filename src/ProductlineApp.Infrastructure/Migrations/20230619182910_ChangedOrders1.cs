using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductlineApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedOrders1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("23b037cd-159a-4bde-b1d5-0661660b9793"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("7c739d39-e75e-47df-8297-276245d46178"));

            migrationBuilder.DropColumn(
                name: "ListingInstanceId",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderLines");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress",
                table: "Orders",
                newName: "ShippingAddress_Address");

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress_Address",
                table: "Orders",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress_Email",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress_Firstname",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress_Lastname",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress_Phone",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress_Username",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "PlatformId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "PlatformOrderId",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress_CompanyName",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress_Firstname",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress_Lastname",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress_Phone",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sku",
                table: "OrderLines",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("566b9c01-00f5-4c30-a300-9886507592a9"), new DateTime(2023, 6, 19, 18, 29, 10, 122, DateTimeKind.Utc).AddTicks(5070), "system", new DateTime(2023, 6, 19, 18, 29, 10, 190, DateTimeKind.Utc).AddTicks(8210), "system", "ebay" },
                    { new Guid("f70c0f6e-43d8-4784-8e0f-a32acc7c24c0"), new DateTime(2023, 6, 19, 18, 29, 10, 122, DateTimeKind.Utc).AddTicks(5090), "system", new DateTime(2023, 6, 19, 18, 29, 10, 190, DateTimeKind.Utc).AddTicks(9240), "system", "allegro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("566b9c01-00f5-4c30-a300-9886507592a9"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("f70c0f6e-43d8-4784-8e0f-a32acc7c24c0"));

            migrationBuilder.DropColumn(
                name: "BillingAddress_Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingAddress_Email",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingAddress_Firstname",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingAddress_Lastname",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingAddress_Phone",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingAddress_Username",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PlatformId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PlatformOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingAddress_CompanyName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingAddress_Firstname",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingAddress_Lastname",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingAddress_Phone",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Sku",
                table: "OrderLines");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress_Address",
                table: "Orders",
                newName: "ShippingAddress");

            migrationBuilder.AddColumn<Guid>(
                name: "ListingInstanceId",
                table: "OrderLines",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "OrderLines",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("23b037cd-159a-4bde-b1d5-0661660b9793"), new DateTime(2023, 6, 19, 14, 42, 39, 307, DateTimeKind.Utc).AddTicks(1660), "system", new DateTime(2023, 6, 19, 14, 42, 39, 437, DateTimeKind.Utc).AddTicks(780), "system", "ebay" },
                    { new Guid("7c739d39-e75e-47df-8297-276245d46178"), new DateTime(2023, 6, 19, 14, 42, 39, 307, DateTimeKind.Utc).AddTicks(1680), "system", new DateTime(2023, 6, 19, 14, 42, 39, 437, DateTimeKind.Utc).AddTicks(860), "system", "allegro" }
                });
        }
    }
}
