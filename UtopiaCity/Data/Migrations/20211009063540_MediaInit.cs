using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class MediaInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles_",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees_",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 200, nullable: false),
                    LastName = table.Column<string>(maxLength: 200, nullable: false),
                    EmployementDate = table.Column<DateTime>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Salary = table.Column<decimal>(nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees_", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees__Roles__RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users_",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 200, nullable: false),
                    LastName = table.Column<string>(maxLength: 200, nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users__Roles__RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataCaptures",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Header = table.Column<string>(maxLength: 100, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    PublicationDate = table.Column<DateTime>(nullable: false),
                    EditorApprove = table.Column<bool>(nullable: false),
                    ApproversApprove = table.Column<bool>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataCaptures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataCaptures_Employees__EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Advertisments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertisments_Employees__EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Advertisments_Users__UserId",
                        column: x => x.UserId,
                        principalTable: "Users_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisments_EmployeeId",
                table: "Advertisments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisments_UserId",
                table: "Advertisments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DataCaptures_EmployeeId",
                table: "DataCaptures",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees__RoleId",
                table: "Employees_",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users__RoleId",
                table: "Users_",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisments");

            migrationBuilder.DropTable(
                name: "DataCaptures");

            migrationBuilder.DropTable(
                name: "Users_");

            migrationBuilder.DropTable(
                name: "Employees_");

            migrationBuilder.DropTable(
                name: "Roles_");
        }
    }
}
