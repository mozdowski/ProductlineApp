using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductlineApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MappedDomainModelWitoutDtos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "Id",
                keyValue: new Guid("6399be07-3338-41b2-8ef0-82c2ce75309b"));

            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "Id",
                keyValue: new Guid("9b96f52d-fba0-4cdf-a1dc-53ea3eede744"));

            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "Id",
                keyValue: new Guid("c73fc91f-4f1b-414d-b4d4-30850eed0022"));

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Platform");

            migrationBuilder.RenameColumn(
                name: "HashedPassword",
                table: "User",
                newName: "Password");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "User",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PlatformConnection",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PlatformConnection",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "PlatformConnection",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "PlatformConnection",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Platform",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Platform",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Platform",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Platform",
                type: "text",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PlatformConnection");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PlatformConnection");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "PlatformConnection");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "PlatformConnection");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Platform");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Platform");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Platform");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Platform");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "HashedPassword");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Platform",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Platform",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { new Guid("6399be07-3338-41b2-8ef0-82c2ce75309b"), "allegro", "https://allegro.pl/" },
                    { new Guid("9b96f52d-fba0-4cdf-a1dc-53ea3eede744"), "ebay", "https://www.ebay.com/" },
                    { new Guid("c73fc91f-4f1b-414d-b4d4-30850eed0022"), "amazon", "https://amazon.com/" }
                });
        }
    }
}
