using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class HousingInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RealEstate",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resident",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    RealEstateId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resident", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resident_RealEstate_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resident_RealEstateId",
                table: "Resident",
                column: "RealEstateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resident");

            migrationBuilder.DropTable(
                name: "RealEstate");
        }
    }
}
