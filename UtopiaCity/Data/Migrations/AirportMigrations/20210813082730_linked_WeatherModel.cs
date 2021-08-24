using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class linked_WeatherModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PermitedModelId",
                table: "WeatherReports",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PermissionDate",
                table: "PermitedModel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_WeatherReports_PermitedModelId",
                table: "WeatherReports",
                column: "PermitedModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherReports_PermitedModel_PermitedModelId",
                table: "WeatherReports",
                column: "PermitedModelId",
                principalTable: "PermitedModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherReports_PermitedModel_PermitedModelId",
                table: "WeatherReports");

            migrationBuilder.DropIndex(
                name: "IX_WeatherReports_PermitedModelId",
                table: "WeatherReports");

            migrationBuilder.DropColumn(
                name: "PermitedModelId",
                table: "WeatherReports");

            migrationBuilder.DropColumn(
                name: "PermissionDate",
                table: "PermitedModel");
        }
    }
}
