using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class Flightv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Flights");

            migrationBuilder.AddColumn<string>(
                name: "DestinationPoint",
                table: "Flights",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationPoint",
                table: "Flights",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationPoint",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "LocationPoint",
                table: "Flights");

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
