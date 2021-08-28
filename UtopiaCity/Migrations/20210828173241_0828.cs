using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Migrations
{
    public partial class _0828 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airlines");

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "SportComplex",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.CreateTable(
                name: "RequestsToAdministration",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    DateOfRequest = table.Column<DateTime>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    IsReviewed = table.Column<bool>(nullable: false),
                    SportComplexId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestsToAdministration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestsToAdministration_SportComplex_SportComplexId",
                        column: x => x.SportComplexId,
                        principalTable: "SportComplex",
                        principalColumn: "SportComplexId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resumes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ResidentAccountId = table.Column<string>(nullable: true),
                    ProfessionId = table.Column<string>(nullable: true),
                    Salary = table.Column<int>(nullable: false),
                    WorkExperienceDateStart = table.Column<DateTime>(nullable: true),
                    WorkExperienceDateEnd = table.Column<DateTime>(nullable: true),
                    UntilNow = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resumes_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resumes_ResidentAccount_ResidentAccountId",
                        column: x => x.ResidentAccountId,
                        principalTable: "ResidentAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SportTickets",
                columns: table => new
                {
                    TicketId = table.Column<string>(nullable: false),
                    SportComplexId = table.Column<string>(nullable: false),
                    SportEventId = table.Column<string>(nullable: false),
                    AppUserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportTickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_SportTickets_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportTickets_SportComplex_SportComplexId",
                        column: x => x.SportComplexId,
                        principalTable: "SportComplex",
                        principalColumn: "SportComplexId");
                    table.ForeignKey(
                        name: "FK_SportTickets_SportEvents_SportEventId",
                        column: x => x.SportEventId,
                        principalTable: "SportEvents",
                        principalColumn: "SportEventId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_RequestsToAdministration_SportComplexId",
                table: "RequestsToAdministration",
                column: "SportComplexId");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_ProfessionId",
                table: "Resumes",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_ResidentAccountId",
                table: "Resumes",
                column: "ResidentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SportTickets_AppUserId",
                table: "SportTickets",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SportTickets_SportComplexId",
                table: "SportTickets",
                column: "SportComplexId");

            migrationBuilder.CreateIndex(
                name: "IX_SportTickets_SportEventId",
                table: "SportTickets",
                column: "SportEventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArrivingPassengers");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "RequestsToAdministration");

            migrationBuilder.DropTable(
                name: "Resumes");

            migrationBuilder.DropTable(
                name: "SportTickets");

            migrationBuilder.DropColumn(
                name: "Available",
                table: "SportComplex");

            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Aircraft = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirlineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailableDirections = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.Id);
                });
        }
    }
}
