using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class Business_Added_Resume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resumes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ResidentAccountId = table.Column<string>(nullable: true),
                    ProfessionId = table.Column<string>(nullable: true),
                    Salary = table.Column<int>(nullable: false),
                    WorkExperienceDateStart = table.Column<DateTime>(nullable: true),
                    WorkExperienceDateEnd = table.Column<DateTime>(nullable: true),
                    UntilNow = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resumes_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resumes_ResidentAccount_ResidentAccountId",
                        column: x => x.ResidentAccountId,
                        principalTable: "ResidentAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_ProfessionId",
                table: "Resumes",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_ResidentAccountId",
                table: "Resumes",
                column: "ResidentAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resumes");
        }
    }
}
