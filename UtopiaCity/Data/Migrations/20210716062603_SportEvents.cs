﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class SportEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SportEvent",
                columns: table => new
                {
                    SportEventId = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    DateOfTheEvent = table.Column<DateTime>(nullable: false),
                    SportComplexId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportEvent", x => x.SportEventId);
                    table.ForeignKey(
                        name: "FK_SportEvent_SportComplex_SportComplexId",
                        column: x => x.SportComplexId,
                        principalTable: "SportComplex",
                        principalColumn: "SportComplexId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SportEvent_SportComplexId",
                table: "SportEvent",
                column: "SportComplexId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SportEvent");
        }
    }
}
