using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace UtopiaCity.Data.Migrations
{
    public partial class CityAdministration_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marriage",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstPersonId = table.Column<string>(nullable: true),
                    SecondPersonId = table.Column<string>(nullable: true),
                    FirstPersonData = table.Column<string>(nullable: true),
                    SecondPersonData = table.Column<string>(nullable: true),
                    MarriageDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marriage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResidentAccount",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    FamilyName = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    MarriageId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentAccount_Marriage_MarriageId",
                        column: x => x.MarriageId,
                        principalTable: "Marriage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResidentAccount_MarriageId",
                table: "ResidentAccount",
                column: "MarriageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResidentAccount");

            migrationBuilder.DropTable(
                name: "Marriage");
        }
    }
}
