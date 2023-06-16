using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductlineApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserAvTARfIELDch1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("1a33114f-e717-46dd-89d9-61252e42ca26"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("f8ed7776-5ad7-4954-b2fe-3c31fbd0987c"));

            migrationBuilder.DropColumn(
                name: "Avatar_Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Avatar_Url",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("305c7267-63f1-4565-aa8a-bc9610a441d2"), new DateTime(2023, 6, 15, 20, 7, 36, 956, DateTimeKind.Utc).AddTicks(1860), "system", new DateTime(2023, 6, 15, 20, 7, 37, 12, DateTimeKind.Utc).AddTicks(4040), "system", "ebay" },
                    { new Guid("e1ce4b5b-a8b2-47c4-bb4d-f775d802e47d"), new DateTime(2023, 6, 15, 20, 7, 36, 956, DateTimeKind.Utc).AddTicks(1880), "system", new DateTime(2023, 6, 15, 20, 7, 37, 12, DateTimeKind.Utc).AddTicks(4970), "system", "allegro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("305c7267-63f1-4565-aa8a-bc9610a441d2"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("e1ce4b5b-a8b2-47c4-bb4d-f775d802e47d"));

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Avatar_Name",
                table: "Users",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Avatar_Url",
                table: "Users",
                type: "varchar(500)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("1a33114f-e717-46dd-89d9-61252e42ca26"), new DateTime(2023, 6, 15, 19, 53, 31, 289, DateTimeKind.Utc).AddTicks(4480), "system", new DateTime(2023, 6, 15, 19, 53, 31, 413, DateTimeKind.Utc).AddTicks(6570), "system", "ebay" },
                    { new Guid("f8ed7776-5ad7-4954-b2fe-3c31fbd0987c"), new DateTime(2023, 6, 15, 19, 53, 31, 289, DateTimeKind.Utc).AddTicks(4500), "system", new DateTime(2023, 6, 15, 19, 53, 31, 413, DateTimeKind.Utc).AddTicks(6630), "system", "allegro" }
                });
        }
    }
}
