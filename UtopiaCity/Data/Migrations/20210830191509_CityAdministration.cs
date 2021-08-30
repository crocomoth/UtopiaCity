using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class CityAdministration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BirthPlace",
                table: "ResidentAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ResidentAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedicalRecords",
                table: "ResidentAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotorTransport",
                table: "ResidentAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "ResidentAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Property",
                table: "ResidentAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationAddress",
                table: "ResidentAccount",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthPlace",
                table: "ResidentAccount");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "ResidentAccount");

            migrationBuilder.DropColumn(
                name: "MedicalRecords",
                table: "ResidentAccount");

            migrationBuilder.DropColumn(
                name: "MotorTransport",
                table: "ResidentAccount");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "ResidentAccount");

            migrationBuilder.DropColumn(
                name: "Property",
                table: "ResidentAccount");

            migrationBuilder.DropColumn(
                name: "RegistrationAddress",
                table: "ResidentAccount");
        }
    }
}
