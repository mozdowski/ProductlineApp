using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductlineApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedImgVarchar2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "ImageUrl",
                table: "Products_Gallery",
                type: "varchar(800)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)");

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("2c036535-b02b-4652-9004-bd325f516f06"), new DateTime(2023, 7, 17, 10, 45, 6, 172, DateTimeKind.Utc).AddTicks(2230), "system", new DateTime(2023, 7, 17, 10, 45, 6, 242, DateTimeKind.Utc).AddTicks(6000), "system", "allegro" },
                    { new Guid("816066a8-0840-4a81-92ff-7dc91b7ccb09"), new DateTime(2023, 7, 17, 10, 45, 6, 172, DateTimeKind.Utc).AddTicks(2210), "system", new DateTime(2023, 7, 17, 10, 45, 6, 242, DateTimeKind.Utc).AddTicks(5080), "system", "ebay" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("2c036535-b02b-4652-9004-bd325f516f06"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("816066a8-0840-4a81-92ff-7dc91b7ccb09"));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products_Gallery",
                type: "varchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(800)");

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("111c6f32-4695-46a7-a366-cafd3a853214"), new DateTime(2023, 7, 17, 10, 38, 45, 428, DateTimeKind.Utc).AddTicks(2460), "system", new DateTime(2023, 7, 17, 10, 38, 45, 565, DateTimeKind.Utc).AddTicks(1710), "system", "allegro" },
                    { new Guid("e39a5a2f-0407-45ad-b6e6-86362d7c27fb"), new DateTime(2023, 7, 17, 10, 38, 45, 428, DateTimeKind.Utc).AddTicks(2440), "system", new DateTime(2023, 7, 17, 10, 38, 45, 565, DateTimeKind.Utc).AddTicks(1650), "system", "ebay" }
                });
        }
    }
}
