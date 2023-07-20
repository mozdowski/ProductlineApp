using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductlineApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VarLenChangesAndLogTableAdded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("4323cf89-a174-4cf7-9cbc-49db142d846d"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("8dd2c1ee-6748-4e51-b494-4888b149e448"));

            migrationBuilder.DropColumn(
                name: "LogLevel",
                table: "Logging");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Logging",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1500)",
                oldMaxLength: 1500);

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("245115f9-02c1-446d-a265-b27faec8fe7f"), new DateTime(2023, 7, 20, 10, 12, 46, 564, DateTimeKind.Utc).AddTicks(6150), "system", new DateTime(2023, 7, 20, 10, 12, 46, 634, DateTimeKind.Utc).AddTicks(6300), "system", "ebay" },
                    { new Guid("6caa1f53-524e-4f55-93a5-aa8bf04eb386"), new DateTime(2023, 7, 20, 10, 12, 46, 564, DateTimeKind.Utc).AddTicks(6170), "system", new DateTime(2023, 7, 20, 10, 12, 46, 634, DateTimeKind.Utc).AddTicks(7330), "system", "allegro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("245115f9-02c1-446d-a265-b27faec8fe7f"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("6caa1f53-524e-4f55-93a5-aa8bf04eb386"));

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Logging",
                type: "character varying(1500)",
                maxLength: 1500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<string>(
                name: "LogLevel",
                table: "Logging",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("4323cf89-a174-4cf7-9cbc-49db142d846d"), new DateTime(2023, 7, 20, 8, 38, 12, 414, DateTimeKind.Utc).AddTicks(7340), "system", new DateTime(2023, 7, 20, 8, 38, 12, 542, DateTimeKind.Utc).AddTicks(2600), "system", "allegro" },
                    { new Guid("8dd2c1ee-6748-4e51-b494-4888b149e448"), new DateTime(2023, 7, 20, 8, 38, 12, 414, DateTimeKind.Utc).AddTicks(7320), "system", new DateTime(2023, 7, 20, 8, 38, 12, 542, DateTimeKind.Utc).AddTicks(2540), "system", "ebay" }
                });
        }
    }
}
