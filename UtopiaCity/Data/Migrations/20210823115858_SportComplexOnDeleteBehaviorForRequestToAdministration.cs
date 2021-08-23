using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class SportComplexOnDeleteBehaviorForRequestToAdministration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestsToAdministration_SportComplex_SportComplexId",
                table: "RequestsToAdministration");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestsToAdministration_SportComplex_SportComplexId",
                table: "RequestsToAdministration",
                column: "SportComplexId",
                principalTable: "SportComplex",
                principalColumn: "SportComplexId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestsToAdministration_SportComplex_SportComplexId",
                table: "RequestsToAdministration");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestsToAdministration_SportComplex_SportComplexId",
                table: "RequestsToAdministration",
                column: "SportComplexId",
                principalTable: "SportComplex",
                principalColumn: "SportComplexId");
        }
    }
}
