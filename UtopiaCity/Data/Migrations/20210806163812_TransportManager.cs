using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class TransportManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransportManagers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TypeOfOrder = table.Column<string>(nullable: true),
                    ForPassengerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportManagers_ForPassengers_ForPassengerId",
                        column: x => x.ForPassengerId,
                        principalTable: "ForPassengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransportManagers_ForPassengerId",
                table: "TransportManagers",
                column: "ForPassengerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransportManagers");
        }
    }
}
