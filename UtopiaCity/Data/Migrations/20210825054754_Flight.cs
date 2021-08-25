using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace UtopiaCity.Data.Migrations
{
    public partial class Flight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Flights",
               columns: table => new
               {
                   Id = table.Column<string>(nullable: false),
                   FlightNumber = table.Column<int>(nullable: false),
                   ArrivalTime = table.Column<DateTime>(nullable: false),
                   DepartureTime = table.Column<DateTime>(nullable: false),
                   Weather = table.Column<string>(nullable: true),
                   DestinationPoint = table.Column<string>(nullable: true),
                   LocationPoint = table.Column<string>(nullable: true),
                   TypeOfAircraft = table.Column<string>(nullable: true)                   
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Flights", x => x.Id);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Flights");
        }
    }
}
