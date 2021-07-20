using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class PermitedConditonsForAirport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermitedModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Season = table.Column<string>(nullable: true),
                    SpeedOfWind = table.Column<decimal>(nullable: false),
                    GovernmentStatus = table.Column<bool>(nullable: false),
                    Rainfall = table.Column<string>(nullable: true),
                    TimeOfDay = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermitedModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermitedModel");
        }
    }
}
