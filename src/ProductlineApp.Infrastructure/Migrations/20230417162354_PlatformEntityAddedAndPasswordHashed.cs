using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductlineApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PlatformEntityAddedAndPasswordHashed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlatformConnection_User_UserId1",
                table: "PlatformConnection");

            migrationBuilder.DropIndex(
                name: "IX_PlatformConnection_UserId1",
                table: "PlatformConnection");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9e3062d2-964a-4f8d-91a4-0a0aa7074d3b"));

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "PlatformConnection");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "Salt");

            migrationBuilder.AddColumn<string>(
                name: "HashedPassword",
                table: "User",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Platform",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platform", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Platform");

            migrationBuilder.DropColumn(
                name: "HashedPassword",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Salt",
                table: "User",
                newName: "Password");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "PlatformConnection",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[] { new Guid("9e3062d2-964a-4f8d-91a4-0a0aa7074d3b"), "john@example.com", "password123", "john" });

            migrationBuilder.CreateIndex(
                name: "IX_PlatformConnection_UserId1",
                table: "PlatformConnection",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformConnection_User_UserId1",
                table: "PlatformConnection",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
