using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingSite.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 4, "Water-resistant with USB port", "/images/bag.jpg", "Laptop Bag", 1899m },
                    { 5, "RGB lights and high DPI", "/images/mouse.jpg", "Gaming Mouse", 1499m },
                    { 6, "Tracks steps and heart rate", "/images/band.jpg", "Fitness Band", 1299m },
                    { 7, "10000 mAh, fast charging", "/images/powerbank.jpg", "Power Bank", 999m },
                    { 8, "Compact and rechargeable", "/images/keyboard.jpg", "Wireless Keyboard", 1699m },
                    { 9, "1080p webcam with mic", "/images/webcam.jpg", "Webcam HD", 2099m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
