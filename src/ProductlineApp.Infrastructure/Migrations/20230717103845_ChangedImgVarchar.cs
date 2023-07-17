using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductlineApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedImgVarchar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("0847775c-ba55-4318-8065-042546b9ca43"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("242bae2b-9c50-4ac7-883a-90ed9606667e"));

            migrationBuilder.AlterColumn<string>(
                name: "Image_Url",
                table: "Products",
                type: "varchar(800)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("111c6f32-4695-46a7-a366-cafd3a853214"), new DateTime(2023, 7, 17, 10, 38, 45, 428, DateTimeKind.Utc).AddTicks(2460), "system", new DateTime(2023, 7, 17, 10, 38, 45, 495, DateTimeKind.Utc).AddTicks(6920), "system", "allegro" },
                    { new Guid("e39a5a2f-0407-45ad-b6e6-86362d7c27fb"), new DateTime(2023, 7, 17, 10, 38, 45, 428, DateTimeKind.Utc).AddTicks(2440), "system", new DateTime(2023, 7, 17, 10, 38, 45, 495, DateTimeKind.Utc).AddTicks(6020), "system", "ebay" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("111c6f32-4695-46a7-a366-cafd3a853214"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("e39a5a2f-0407-45ad-b6e6-86362d7c27fb"));

            migrationBuilder.AlterColumn<string>(
                name: "Image_Url",
                table: "Products",
                type: "varchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(800)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("0847775c-ba55-4318-8065-042546b9ca43"), new DateTime(2023, 6, 20, 8, 13, 0, 707, DateTimeKind.Utc).AddTicks(5170), "system", new DateTime(2023, 6, 20, 8, 13, 0, 839, DateTimeKind.Utc).AddTicks(7690), "system", "allegro" },
                    { new Guid("242bae2b-9c50-4ac7-883a-90ed9606667e"), new DateTime(2023, 6, 20, 8, 13, 0, 707, DateTimeKind.Utc).AddTicks(5140), "system", new DateTime(2023, 6, 20, 8, 13, 0, 839, DateTimeKind.Utc).AddTicks(7620), "system", "ebay" }
                });
        }
    }
}
