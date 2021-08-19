using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class ScheduleModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduleModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ModelName = table.Column<string>(nullable: true),
                    EventName = table.Column<string>(nullable: true),
                    EventType = table.Column<string>(nullable: true),
                    TimeOfStart = table.Column<DateTime>(nullable: false),
                    TimeOfEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleModel");
        }
    }
}
