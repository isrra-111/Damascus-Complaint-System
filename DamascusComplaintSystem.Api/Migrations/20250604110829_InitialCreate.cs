using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DamascusComplaintSystem.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CadastralZone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParcelNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyLocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplaintText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplaintType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplaintRepeatCount = table.Column<int>(type: "int", nullable: false),
                    PreviousComplaintNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousComplaintDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complaints");
        }
    }
}
