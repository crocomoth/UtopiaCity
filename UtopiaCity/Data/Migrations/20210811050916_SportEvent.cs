using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class SportEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SportEvents",
                columns: table => new
                {
                    SportEventId = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    DateOfTheEvent = table.Column<DateTime>(nullable: false),
                    SportComplexId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportEvents", x => x.SportEventId);
                    table.ForeignKey(
                        name: "FK_SportEvents_SportComplex_SportComplexId",
                        column: x => x.SportComplexId,
                        principalTable: "SportComplex",
                        principalColumn: "SportComplexId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SportEvents_SportComplexId",
                table: "SportEvents",
                column: "SportComplexId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SportEvents");
        }
    }
}
