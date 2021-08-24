using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class SportTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CitizensTasks",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                name: "SportTickets");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CitizensTasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
