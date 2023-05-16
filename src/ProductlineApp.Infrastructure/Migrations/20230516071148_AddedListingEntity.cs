using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductlineApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedListingEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("2f264950-4682-42dd-9bcd-2e06fb5a40dd"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("8c73857d-9f23-4600-8241-8015e90ddbef"));

            migrationBuilder.AddColumn<int>(
                name: "Condition",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListingInstances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ListingId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlatformId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlatformListingId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ListingUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    ExpiresIn = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListingInstances_Listings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("6e4e2024-4a3a-4f26-9229-41228e3fb8f4"), new DateTime(2023, 5, 16, 7, 11, 48, 140, DateTimeKind.Utc).AddTicks(8320), "system", new DateTime(2023, 5, 16, 7, 11, 48, 206, DateTimeKind.Utc).AddTicks(1070), "system", "allegro" },
                    { new Guid("85a8c28c-5cd6-44af-8fef-f16a9293bcce"), new DateTime(2023, 5, 16, 7, 11, 48, 140, DateTimeKind.Utc).AddTicks(8300), "system", new DateTime(2023, 5, 16, 7, 11, 48, 206, DateTimeKind.Utc).AddTicks(90), "system", "ebay" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListingInstances_ListingId",
                table: "ListingInstances",
                column: "ListingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListingInstances");

            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("6e4e2024-4a3a-4f26-9229-41228e3fb8f4"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("85a8c28c-5cd6-44af-8fef-f16a9293bcce"));

            migrationBuilder.DropColumn(
                name: "Condition",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("2f264950-4682-42dd-9bcd-2e06fb5a40dd"), new DateTime(2023, 4, 24, 12, 56, 15, 770, DateTimeKind.Utc).AddTicks(4310), "system", new DateTime(2023, 4, 24, 12, 56, 15, 872, DateTimeKind.Utc).AddTicks(4600), "system", "ebay" },
                    { new Guid("8c73857d-9f23-4600-8241-8015e90ddbef"), new DateTime(2023, 4, 24, 12, 56, 15, 770, DateTimeKind.Utc).AddTicks(4330), "system", new DateTime(2023, 4, 24, 12, 56, 15, 872, DateTimeKind.Utc).AddTicks(4660), "system", "allegro" }
                });
        }
    }
}
