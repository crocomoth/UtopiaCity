using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Migrations
{
    public partial class firesystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Сhief = table.Column<string>(nullable: true),
                    DepartmentStatusEnum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Сhief = table.Column<string>(nullable: true),
                    DepartmentStatusEnum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeManagementViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CanCheck = table.Column<bool>(nullable: false),
                    EmployeePosition = table.Column<string>(nullable: true),
                    Positionid = table.Column<string>(nullable: false),
                    DepartmentId = table.Column<string>(nullable: false),
                    DepartmentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeManagementViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireMessage",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Address = table.Column<string>(maxLength: 30, nullable: false),
                    FullName = table.Column<string>(maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireSafetyCheckRequests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Address = table.Column<string>(maxLength: 25, nullable: false),
                    ObjectName = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireSafetyCheckRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PositionViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportManagementViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TypeOfFireCar = table.Column<string>(maxLength: 30, nullable: true),
                    FirePump = table.Column<bool>(nullable: false),
                    ContainerForStoringFireExtinguishingAgents = table.Column<bool>(nullable: false),
                    FireFightingEquipment = table.Column<string>(maxLength: 30, nullable: true),
                    DepartmentId = table.Column<string>(nullable: true),
                    DepartmentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportManagementViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportsManagement",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TypeOfFireCar = table.Column<string>(maxLength: 30, nullable: true),
                    DepartmentName = table.Column<string>(nullable: true),
                    FirePump = table.Column<bool>(nullable: false),
                    ContainerForStoringFireExtinguishingAgents = table.Column<bool>(nullable: false),
                    FireFightingEquipment = table.Column<string>(maxLength: 30, nullable: true),
                    DepartmentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportsManagement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportsManagement_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeparturesToThePlaces",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Address = table.Column<string>(maxLength: 30, nullable: false),
                    FullName = table.Column<string>(maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    DepartmentName = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<string>(nullable: true),
                    FireMessageId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeparturesToThePlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeparturesToThePlaces_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeparturesToThePlaces_FireMessage_FireMessageId",
                        column: x => x.FireMessageId,
                        principalTable: "FireMessage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesManagement",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CanCheck = table.Column<bool>(nullable: false),
                    DepartmentName = table.Column<string>(nullable: true),
                    EmployeePosition = table.Column<string>(nullable: true),
                    PositionId = table.Column<string>(nullable: false),
                    DepartmentId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesManagement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeesManagement_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeesManagement_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FireSafetyCheck",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Address = table.Column<string>(maxLength: 25, nullable: false),
                    ObjectName = table.Column<string>(maxLength: 20, nullable: true),
                    FireSafetyDocuments = table.Column<bool>(nullable: false),
                    FireFightingEquipment = table.Column<bool>(nullable: false),
                    Journals = table.Column<bool>(nullable: false),
                    FireSafetySigns = table.Column<bool>(nullable: false),
                    EscapeRoutes = table.Column<bool>(nullable: false),
                    SmokingAreas = table.Column<bool>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireSafetyCheck", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FireSafetyCheck_EmployeesManagement_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeesManagement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeparturesToThePlaces_DepartmentId",
                table: "DeparturesToThePlaces",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DeparturesToThePlaces_FireMessageId",
                table: "DeparturesToThePlaces",
                column: "FireMessageId",
                unique: true,
                filter: "[FireMessageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesManagement_DepartmentId",
                table: "EmployeesManagement",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesManagement_PositionId",
                table: "EmployeesManagement",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_FireSafetyCheck_EmployeeId",
                table: "FireSafetyCheck",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportsManagement_DepartmentId",
                table: "TransportsManagement",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentViewModel");

            migrationBuilder.DropTable(
                name: "DeparturesToThePlaces");

            migrationBuilder.DropTable(
                name: "EmployeeManagementViewModel");

            migrationBuilder.DropTable(
                name: "FireSafetyCheck");

            migrationBuilder.DropTable(
                name: "FireSafetyCheckRequests");

            migrationBuilder.DropTable(
                name: "PositionViewModel");

            migrationBuilder.DropTable(
                name: "TransportManagementViewModel");

            migrationBuilder.DropTable(
                name: "TransportsManagement");

            migrationBuilder.DropTable(
                name: "FireMessage");

            migrationBuilder.DropTable(
                name: "EmployeesManagement");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
