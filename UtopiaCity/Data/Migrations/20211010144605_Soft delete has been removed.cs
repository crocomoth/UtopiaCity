using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class Softdeletehasbeenremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Users_");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users_");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Roles_");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Roles_");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Employees_");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Employees_");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "DataCaptures");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "DataCaptures");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Advertisments");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Advertisments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Users_",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users_",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Roles_",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Roles_",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Employees_",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Employees_",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "DataCaptures",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "DataCaptures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Advertisments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Advertisments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
