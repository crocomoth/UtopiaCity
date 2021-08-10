using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class TransportSystemAir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ForCompanyId",
                table: "TransportManagers",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_TransportManagers_ForCompanyId",
                table: "TransportManagers",
                column: "ForCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportManagers_ForCompanies_ForCompanyId",
                table: "TransportManagers",
                column: "ForCompanyId",
                principalTable: "ForCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportManagers_ForCompanies_ForCompanyId",
                table: "TransportManagers");

            migrationBuilder.DropTable(
                name: "ForCompanies");

            migrationBuilder.DropIndex(
                name: "IX_TransportManagers_ForCompanyId",
                table: "TransportManagers");

            migrationBuilder.DropColumn(
                name: "ForCompanyId",
                table: "TransportManagers");
        }
    }
}
