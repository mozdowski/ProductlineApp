using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductlineApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDateFormatToUTC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "Id",
                keyValue: new Guid("63f5d2f0-882e-40c6-bebc-f21f85ee3f63"));

            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "Id",
                keyValue: new Guid("7da9981e-14fe-44f1-bfc4-1ff877e6c7b2"));

            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "Id",
                keyValue: new Guid("83feca4c-5193-4557-8157-c209cf7d60e3"));

            migrationBuilder.InsertData(
                table: "Platform",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("24a9d2f1-28a7-4cb7-81ee-5da5571f3766"), null, null, null, null, "ebay" },
                    { new Guid("26bb305b-8acc-476e-82a5-137cdde6034e"), null, null, null, null, "allegro" },
                    { new Guid("aef459b3-7f40-4d3d-91ca-cc8a842bb1e0"), null, null, null, null, "amazon" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "Id",
                keyValue: new Guid("24a9d2f1-28a7-4cb7-81ee-5da5571f3766"));

            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "Id",
                keyValue: new Guid("26bb305b-8acc-476e-82a5-137cdde6034e"));

            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "Id",
                keyValue: new Guid("aef459b3-7f40-4d3d-91ca-cc8a842bb1e0"));

            migrationBuilder.InsertData(
                table: "Platform",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("63f5d2f0-882e-40c6-bebc-f21f85ee3f63"), null, null, null, null, "amazon" },
                    { new Guid("7da9981e-14fe-44f1-bfc4-1ff877e6c7b2"), null, null, null, null, "allegro" },
                    { new Guid("83feca4c-5193-4557-8157-c209cf7d60e3"), null, null, null, null, "ebay" }
                });
        }
    }
}
