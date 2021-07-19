using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Migrations
{
    public partial class PCsecondMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RestaurantTypeId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RestaurantTypeId",
                table: "Reservations",
                column: "RestaurantTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_RestaurantTypes_RestaurantTypeId",
                table: "Reservations",
                column: "RestaurantTypeId",
                principalTable: "RestaurantTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_RestaurantTypes_RestaurantTypeId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RestaurantTypeId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RestaurantTypeId",
                table: "Reservations");
        }
    }
}
