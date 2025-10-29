using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UI.Migrations
{
    /// <inheritdoc />
    public partial class hasDataForBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorName", "CategoryId", "CreatedAt", "ImageUrl", "PagesCount", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "آلبر کامو", 1, new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/books/the-stranger.jpg", 120, 450000m, "غریبه" },
                    { 2, "لئو تولستوی", 1, new DateTime(2025, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/books/war-and-peace.jpg", 1225, 600000m, "جنگ و صلح" },
                    { 3, "جبران خلیل جبران", 2, new DateTime(2025, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/books/the-prophet.jpg", 100, 380000m, "پیامبر" },
                    { 4, "آنتوان دو سنت‌اگزوپری", 4, new DateTime(2025, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/books/The-Little-Prince.jpg", 90, 250000m, "شازده کوچولو" },
                    { 5, "استیون هاوکینگ", 3, new DateTime(2025, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/books/THE-THEORY-OF-EVERYTHING.jpg", 160, 500000m, "نظریه‌ی همه‌چیز" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
