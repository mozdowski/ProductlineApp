using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductlineApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedOrders3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("954dff22-70de-4cbc-b002-ee632c9c7e88"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("ae194948-df4f-4fed-9431-7fc701e65a69"));

            migrationBuilder.AlterColumn<string>(
                name: "ShippingAddress_Phone",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ShippingAddress_Firstname",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "BillingAddress_Username",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "BillingAddress_Phone",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "BillingAddress_Firstname",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "BillingAddress_Email",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("6c32e689-bf46-417a-8453-2fbb11c695d4"), new DateTime(2023, 6, 19, 19, 19, 29, 120, DateTimeKind.Utc).AddTicks(4820), "system", new DateTime(2023, 6, 19, 19, 19, 29, 184, DateTimeKind.Utc).AddTicks(4170), "system", "allegro" },
                    { new Guid("98044a71-0112-4fe4-b7df-fdc7d98c2005"), new DateTime(2023, 6, 19, 19, 19, 29, 120, DateTimeKind.Utc).AddTicks(4800), "system", new DateTime(2023, 6, 19, 19, 19, 29, 184, DateTimeKind.Utc).AddTicks(3170), "system", "ebay" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("6c32e689-bf46-417a-8453-2fbb11c695d4"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("98044a71-0112-4fe4-b7df-fdc7d98c2005"));

            migrationBuilder.AlterColumn<string>(
                name: "ShippingAddress_Phone",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShippingAddress_Firstname",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BillingAddress_Username",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BillingAddress_Phone",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BillingAddress_Firstname",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BillingAddress_Email",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("954dff22-70de-4cbc-b002-ee632c9c7e88"), new DateTime(2023, 6, 19, 19, 16, 17, 288, DateTimeKind.Utc).AddTicks(7930), "system", new DateTime(2023, 6, 19, 19, 16, 17, 409, DateTimeKind.Utc).AddTicks(9620), "system", "allegro" },
                    { new Guid("ae194948-df4f-4fed-9431-7fc701e65a69"), new DateTime(2023, 6, 19, 19, 16, 17, 288, DateTimeKind.Utc).AddTicks(7910), "system", new DateTime(2023, 6, 19, 19, 16, 17, 409, DateTimeKind.Utc).AddTicks(9560), "system", "ebay" }
                });
        }
    }
}
