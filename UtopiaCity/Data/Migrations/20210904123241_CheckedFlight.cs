using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class CheckedFlight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckedFlights",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CheckedFlightNumber = table.Column<int>(nullable: false),
                    CheckedArrivalTime = table.Column<DateTime>(nullable: false),
                    CheckedDepartureTime = table.Column<DateTime>(nullable: false),
                    CheckedDestinationPoint = table.Column<string>(nullable: true),
                    CheckedLocationPoint = table.Column<string>(nullable: true),
                    CheckedTypeOfAircraft = table.Column<string>(nullable: true),
                    CheckedWeather = table.Column<string>(nullable: true),
                    CheckedFlightWeather = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckedFlights", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckedFlights");
        }
    }
}
