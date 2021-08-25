using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class ArrivingPassenger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArrivingPassengers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PassengerFirstName = table.Column<string>(nullable: true),
                    PassengerFamilyName = table.Column<string>(nullable: true),
                    PassengerBirthDate = table.Column<DateTime>(nullable: false),
                    PassengerGender = table.Column<string>(nullable: true),
                    PassengerStatus = table.Column<string>(nullable: true),
                    PassengerMarriageStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArrivingPassengers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArrivingPassengers");
        }
    }
}
