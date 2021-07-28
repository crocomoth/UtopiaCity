using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class AirporttransportSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportManagers_ForPassengers_ForPassengerId",
                table: "TransportManagers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ForPassengers",
                table: "ForPassengers");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "ForPassengers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "ForPassengers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForPassengers",
                table: "ForPassengers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportManagers_ForPassengers_ForPassengerId",
                table: "TransportManagers",
                column: "ForPassengerId",
                principalTable: "ForPassengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportManagers_ForPassengers_ForPassengerId",
                table: "TransportManagers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ForPassengers",
                table: "ForPassengers");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "ForPassengers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "ForPassengers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForPassengers",
                table: "ForPassengers",
                column: "FullName");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportManagers_ForPassengers_ForPassengerId",
                table: "TransportManagers",
                column: "ForPassengerId",
                principalTable: "ForPassengers",
                principalColumn: "FullName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
