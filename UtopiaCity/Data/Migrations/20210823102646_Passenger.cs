using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class Passenger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "Passengers",
              columns: table => new
              {
                  Id = table.Column<string>(nullable: false),
                  PassengerName = table.Column<string>(nullable: true),
                  ProgressStatus = table.Column<string>(nullable: true),
                  PassengerStatus = table.Column<string>(nullable: true),
                  TicketId = table.Column<string>(nullable: true),
                  ResidentAccountId = table.Column<string>(nullable: true),
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Passengers", x => x.Id);
                  table.ForeignKey(
                       name: "FK_Passengers_Ticket_TicketId",
                       column: x => x.TicketId,
                       principalTable: "Tickets",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Restrict);
                  table.ForeignKey(
                      name: "FK_Passengers_ResidentAccount_ResidentAccountId",
                      column: x => x.ResidentAccountId,
                      principalTable: "ResidentAccount",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
              });

            migrationBuilder.CreateIndex(
               name: "IX_Passengers_TicketId",
               table: "Passengers",
               column: "TicketId");

            migrationBuilder.CreateIndex(
               name: "IX_Passengers_ResidentAccountId",
               table: "Passengers",
               column: "ResidentAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Passengers");

            migrationBuilder.DropTable(
               name: "Tickets");

            migrationBuilder.DropTable(
              name: "ResidentAccount");
        }
    }
}
