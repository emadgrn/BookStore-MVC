using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UI.Migrations
{
    /// <inheritdoc />
    public partial class hasDataForCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "BriefDescription", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "معاصر، کلاسیک", "/images/categories/books-icon.png", "رمان و داستان" },
                    { 2, "غرب و شرق", "/images/categories/brain-icon.png", "فلسفه و منطق" },
                    { 3, "فناوری و تاریخ", "/images/categories/microscope-icon.png", "علمی و تاریخی" },
                    { 4, "داستان‌های مصور", "/images/categories/child-icon.png", "کودک و نوجوان" },
                    { 5, "طراحی و نقاشی", "/images/categories/art-icon.png", "هنر و معماری" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
