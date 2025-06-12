using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DamascusComplaintSystem.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddComplaintTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComplaintType",
                table: "Complaints");

            migrationBuilder.AddColumn<int>(
                name: "ComplaintTypeId",
                table: "Complaints",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ComplaintTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_ComplaintTypeId",
                table: "Complaints",
                column: "ComplaintTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_ComplaintTypes_ComplaintTypeId",
                table: "Complaints",
                column: "ComplaintTypeId",
                principalTable: "ComplaintTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_ComplaintTypes_ComplaintTypeId",
                table: "Complaints");

            migrationBuilder.DropTable(
                name: "ComplaintTypes");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_ComplaintTypeId",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplaintTypeId",
                table: "Complaints");

            migrationBuilder.AddColumn<string>(
                name: "ComplaintType",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
