using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DamascusComplaintSystem.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedComplaintTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ComplaintTypes",
                columns: new[] { "Id", "ArabicName", "Name" },
                values: new object[,]
                {
                    { 1, "مخالفة بناء", "BuildingViolation" },
                    { 2, "ممارسة مهنة بدون ترخيص", "UnlicensedProfession" },
                    { 3, "شخصية", "Personal" },
                    { 4, "عقارية", "RealEstate" },
                    { 5, "التعدي على أملاك العامة", "PublicPropertyViolation" },
                    { 6, "إشغال رصيف", "SidewalkOccupation" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ComplaintTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComplaintTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComplaintTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComplaintTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ComplaintTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ComplaintTypes",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
