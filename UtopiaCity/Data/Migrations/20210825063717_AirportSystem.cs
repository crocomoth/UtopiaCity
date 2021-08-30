using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class AirportSystem : Migration
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

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FlightNumber = table.Column<int>(nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: false),
                    DepartureTime = table.Column<DateTime>(nullable: false),
                    DestinationPoint = table.Column<string>(nullable: true),
                    LocationPoint = table.Column<string>(nullable: true),
                    TypeOfAircraft = table.Column<string>(nullable: true),
                    Weather = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForCompanies",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    Contacts = table.Column<string>(nullable: true),
                    AviaProvider = table.Column<string>(nullable: true),
                    CountryOfDelivery = table.Column<string>(nullable: true),
                    QuantityOfGoods = table.Column<string>(nullable: true),
                    WaitingTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForPassengers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true),
                    TransportType = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PayType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForPassengers", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FlightId = table.Column<string>(nullable: true),
                    PermitedModelId = table.Column<string>(nullable: true),
                    ResidentAccountId = table.Column<string>(nullable: true),
                    Direction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_PermitedModel_PermitedModelId",
                        column: x => x.PermitedModelId,
                        principalTable: "PermitedModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_ResidentAccount_ResidentAccountId",
                        column: x => x.ResidentAccountId,
                        principalTable: "ResidentAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransportManagers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TypeOfOrder = table.Column<string>(nullable: true),
                    ForPassengerId = table.Column<string>(nullable: true),
                    ForCompanyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportManagers_ForCompanies_ForCompanyId",
                        column: x => x.ForCompanyId,
                        principalTable: "ForCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransportManagers_ForPassengers_ForPassengerId",
                        column: x => x.ForPassengerId,
                        principalTable: "ForPassengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PassengerName = table.Column<string>(nullable: true),
                    ProgressStatus = table.Column<string>(nullable: true),
                    PassengerStatus = table.Column<string>(nullable: true),
                    TicketId = table.Column<string>(nullable: true),
                    ResidentAccountId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passengers_ResidentAccount_ResidentAccountId",
                        column: x => x.ResidentAccountId,
                        principalTable: "ResidentAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Passengers_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_ResidentAccountId",
                table: "Passengers",
                column: "ResidentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_TicketId",
                table: "Passengers",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FlightId",
                table: "Tickets",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PermitedModelId",
                table: "Tickets",
                column: "PermitedModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ResidentAccountId",
                table: "Tickets",
                column: "ResidentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportManagers_ForCompanyId",
                table: "TransportManagers",
                column: "ForCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportManagers_ForPassengerId",
                table: "TransportManagers",
                column: "ForPassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherReports_PermitedModelId",
                table: "WeatherReports",
                column: "PermitedModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArrivingPassengers");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "TransportManagers");

            migrationBuilder.DropTable(
                name: "WeatherReports");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "ForCompanies");

            migrationBuilder.DropTable(
                name: "ForPassengers");

            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
