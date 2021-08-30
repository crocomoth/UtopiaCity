using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicReport");

            migrationBuilder.CreateTable(
                name: "ClinicVisit",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Visit = table.Column<string>(nullable: false),
                    VisitTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicVisit", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicVisit");

            migrationBuilder.CreateTable(
                name: "ClinicReport",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Report = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicReport", x => x.Id);
                });
        }
    }
}
