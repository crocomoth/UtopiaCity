using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class Flight_Last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TravelDistance",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "TravelDuration",
                table: "Flights");

            migrationBuilder.AddColumn<string>(
                name: "TypeOfAircraft",
                table: "Flights",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOfAircraft",
                table: "Flights");

            migrationBuilder.AddColumn<double>(
                name: "TravelDistance",
                table: "Flights",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TravelDuration",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
