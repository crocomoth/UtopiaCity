using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class CityAdministration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "ResidentAccount",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "ResidentAccount",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "MarriageDate",
                table: "Marriage",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
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

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "ResidentAccount",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "ResidentAccount",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MarriageDate",
                table: "Marriage",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
