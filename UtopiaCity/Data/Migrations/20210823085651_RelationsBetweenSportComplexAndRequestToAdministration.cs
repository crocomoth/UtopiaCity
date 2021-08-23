using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class RelationsBetweenSportComplexAndRequestToAdministration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SportComplexId",
                table: "RequestsToAdministration",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_RequestsToAdministration_SportComplexId",
                table: "RequestsToAdministration",
                column: "SportComplexId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestsToAdministration_SportComplex_SportComplexId",
                table: "RequestsToAdministration",
                column: "SportComplexId",
                principalTable: "SportComplex",
                principalColumn: "SportComplexId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestsToAdministration_SportComplex_SportComplexId",
                table: "RequestsToAdministration");

            migrationBuilder.DropIndex(
                name: "IX_RequestsToAdministration_SportComplexId",
                table: "RequestsToAdministration");

            migrationBuilder.AlterColumn<string>(
                name: "SportComplexId",
                table: "RequestsToAdministration",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
