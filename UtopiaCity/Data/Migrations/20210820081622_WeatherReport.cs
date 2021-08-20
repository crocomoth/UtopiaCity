using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class WeatherReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "WeatherReports",
               columns: table => new
               {
                   Id = table.Column<string>(nullable: false),
                   WeatherCondition = table.Column<string>(nullable: true),
                   Temperature = table.Column<string>(nullable: true),
                   Wind = table.Column<string>(nullable: true),
                   Rainfall = table.Column<string>(nullable: true),
                   Moisture = table.Column<string>(nullable: true),
                   FlightWeather = table.Column<string>(nullable: true),
                   DirectionFrom = table.Column<string>(nullable: true),
                   DirectionTo = table.Column<string>(nullable: true),
                   PermitedModelId = table.Column<string>(nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_WeatherReports", x => x.Id);
                   table.ForeignKey(
                        name: "FK_WeatherReports_PermitedModel_PermitedModelId",
                        column: x => x.PermitedModelId,
                        principalTable: "PermitedModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
               });

            migrationBuilder.CreateIndex(
               name: "IX_WeatherReports_PermitedModelId",
               table: "WeatherReports",
               column: "PermitedModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "WeatherReports");

            migrationBuilder.DropTable(
               name: "PermitedModel");
        }
    }
}
