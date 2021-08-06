using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class SportComplexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SportComplexes",
                columns: table => new
                {
                    SportComplexId = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    NumberOfSeats = table.Column<int>(nullable: false),
                    BuildDate = table.Column<DateTime>(nullable: false),
                    TypeOfSport = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportComplexes", x => x.SportComplexId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SportComplexes");
        }
    }
}
