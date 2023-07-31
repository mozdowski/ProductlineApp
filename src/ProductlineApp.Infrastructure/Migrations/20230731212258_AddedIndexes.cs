using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductlineApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OwnerId",
                table: "Products",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Sku",
                table: "Products",
                column: "Sku");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OwnerId",
                table: "Orders",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PlacedAt",
                table: "Orders",
                column: "PlacedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PlatformId",
                table: "Orders",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PlatformOrderId",
                table: "Orders",
                column: "PlatformOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_Sku",
                table: "OrderLines",
                column: "Sku");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_OwnerId",
                table: "Listings",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_ProductId",
                table: "Listings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ListingInstances_PlatformId",
                table: "ListingInstances",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_ListingInstances_PlatformListingId",
                table: "ListingInstances",
                column: "PlatformListingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Products_OwnerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Sku",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OwnerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PlacedAt",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PlatformId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PlatformOrderId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_Sku",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "IX_Listings_OwnerId",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_ProductId",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_ListingInstances_PlatformId",
                table: "ListingInstances");

            migrationBuilder.DropIndex(
                name: "IX_ListingInstances_PlatformListingId",
                table: "ListingInstances");
        }
    }
}
