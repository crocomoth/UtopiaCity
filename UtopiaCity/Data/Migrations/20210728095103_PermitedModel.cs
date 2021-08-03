using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class PermitedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "PermitedModel",
              columns: table => new
              {
                  Id = table.Column<string>(nullable: false),
                  PermissionStatus = table.Column<string>(nullable: true),
                  Season = table.Column<string>(nullable: true),
                  SpeedOfWind = table.Column<int>(nullable: true),
                  GovernmentStatus = table.Column<bool>(nullable: true),
                  Rainfall = table.Column<string>(nullable: true),
                  TimeOfDay = table.Column<string>(nullable: true)
              },
               constraints: table =>
               {
                   table.PrimaryKey("PK_PermitedModel", x => x.Id);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermitedModel");
        }
    }
}
