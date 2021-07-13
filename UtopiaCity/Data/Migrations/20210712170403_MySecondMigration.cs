using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Migrations
{
    public partial class MySecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RestaurantTypeId",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RestaurantTypes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_RestaurantTypeId",
                table: "Restaurants",
                column: "RestaurantTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_RestaurantTypes_RestaurantTypeId",
                table: "Restaurants",
                column: "RestaurantTypeId",
                principalTable: "RestaurantTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_RestaurantTypes_RestaurantTypeId",
                table: "Restaurants");

            migrationBuilder.DropTable(
                name: "RestaurantTypes");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_RestaurantTypeId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "RestaurantTypeId",
                table: "Restaurants");
        }
    }
}
