using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class Timeline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimelineModel",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    DayAndYear = table.Column<DateTime>(nullable: false),
                    Schedule = table.Column<string>(nullable: true),
                    TranscriptionOfPermission = table.Column<string>(nullable: true),
                    UniqueRules = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimelineModel", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimelineModel");
        }
    }
}
