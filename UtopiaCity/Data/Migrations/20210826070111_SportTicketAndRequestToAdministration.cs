using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class SportTicketAndRequestToAdministration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "SportComplex",
                nullable: false,
                defaultValue: false);

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
                name: "IX_RequestsToAdministration_SportComplexId",
                table: "RequestsToAdministration",
                column: "SportComplexId");

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
                name: "RequestsToAdministration");

            migrationBuilder.DropTable(
                name: "SportTickets");

            migrationBuilder.DropColumn(
                name: "Available",
                table: "SportComplex");
        }
    }
}
