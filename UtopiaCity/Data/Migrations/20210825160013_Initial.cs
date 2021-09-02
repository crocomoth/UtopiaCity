using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    BIK = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CitizensTasks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    ReminderDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitizensTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CitizensTasks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyStatuses",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyCertificate",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyCertificate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyReport",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Report = table.Column<string>(nullable: false),
                    ReportTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyReport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    EventType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FlightNumber = table.Column<int>(nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: false),
                    DepartureTime = table.Column<DateTime>(nullable: false),
                    DestinationPoint = table.Column<string>(nullable: true),
                    LocationPoint = table.Column<string>(nullable: true),
                    TypeOfAircraft = table.Column<string>(nullable: true),
                    Weather = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForCompanies",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    Contacts = table.Column<string>(nullable: true),
                    AviaProvider = table.Column<string>(nullable: true),
                    CountryOfDelivery = table.Column<string>(nullable: true),
                    QuantityOfGoods = table.Column<string>(nullable: true),
                    WaitingTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForPassengers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true),
                    TransportType = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PayType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForPassengers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marriage",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstPersonId = table.Column<string>(nullable: false),
                    SecondPersonId = table.Column<string>(nullable: false),
                    FirstPersonData = table.Column<string>(nullable: true),
                    SecondPersonData = table.Column<string>(nullable: true),
                    MarriageDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marriage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermitedModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PermissionDate = table.Column<DateTime>(nullable: false),
                    PermissionStatus = table.Column<string>(nullable: true),
                    Season = table.Column<string>(nullable: true),
                    SpeedOfWind = table.Column<string>(nullable: true),
                    GovernmentStatus = table.Column<bool>(nullable: false),
                    Rainfall = table.Column<string>(nullable: true),
                    TimeOfDay = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermitedModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "SportComplex",
                columns: table => new
                {
                    SportComplexId = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    NumberOfSeats = table.Column<int>(nullable: false),
                    BuildDate = table.Column<DateTime>(nullable: false),
                    TypeOfSport = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportComplex", x => x.SportComplexId);
                });

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

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CEO = table.Column<string>(nullable: true),
                    IIK = table.Column<string>(nullable: true),
                    BIN = table.Column<string>(nullable: true),
                    BankId = table.Column<string>(nullable: true),
                    CompanyStatusId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_CompanyStatuses_CompanyStatusId",
                        column: x => x.CompanyStatusId,
                        principalTable: "CompanyStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransportManagers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TypeOfOrder = table.Column<string>(nullable: true),
                    ForPassengerId = table.Column<string>(nullable: true),
                    ForCompanyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportManagers_ForCompanies_ForCompanyId",
                        column: x => x.ForCompanyId,
                        principalTable: "ForCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransportManagers_ForPassengers_ForPassengerId",
                        column: x => x.ForPassengerId,
                        principalTable: "ForPassengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "WeatherReports",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    WeatherCondition = table.Column<string>(nullable: true),
                    Temperature = table.Column<string>(nullable: true),
                    Wind = table.Column<string>(nullable: true),
                    Rainfall = table.Column<string>(nullable: true),
                    Moisture = table.Column<string>(nullable: true),
                    FlightWeather = table.Column<string>(nullable: true),
                    DirectionFrom = table.Column<string>(nullable: true),
                    DirectionTo = table.Column<string>(nullable: true),
                    PermitedModelId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherReports_PermitedModel_PermitedModelId",
                        column: x => x.PermitedModelId,
                        principalTable: "PermitedModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SportEvents",
                columns: table => new
                {
                    SportEventId = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    DateOfTheEvent = table.Column<DateTime>(nullable: false),
                    SportComplexId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportEvents", x => x.SportEventId);
                    table.ForeignKey(
                        name: "FK_SportEvents_SportComplex_SportComplexId",
                        column: x => x.SportComplexId,
                        principalTable: "SportComplex",
                        principalColumn: "SportComplexId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FIO = table.Column<string>(nullable: true),
                    ProfessionId = table.Column<string>(nullable: true),
                    Salary = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ProfessionId = table.Column<string>(nullable: true),
                    Salary = table.Column<int>(nullable: false),
                    Requirement = table.Column<string>(nullable: true),
                    Discription = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacancies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vacancies_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FlightId = table.Column<string>(nullable: true),
                    PermitedModelId = table.Column<string>(nullable: true),
                    ResidentAccountId = table.Column<string>(nullable: true),
                    Direction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_PermitedModel_PermitedModelId",
                        column: x => x.PermitedModelId,
                        principalTable: "PermitedModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_ResidentAccount_ResidentAccountId",
                        column: x => x.ResidentAccountId,
                        principalTable: "ResidentAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CitizensTasks_UserId",
                table: "CitizensTasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_BankId",
                table: "Companies",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyStatusId",
                table: "Companies",
                column: "CompanyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProfessionId",
                table: "Employees",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentAccount_MarriageId",
                table: "ResidentAccount",
                column: "MarriageId");

            migrationBuilder.CreateIndex(
                name: "IX_SportEvents_SportComplexId",
                table: "SportEvents",
                column: "SportComplexId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FlightId",
                table: "Tickets",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PermitedModelId",
                table: "Tickets",
                column: "PermitedModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ResidentAccountId",
                table: "Tickets",
                column: "ResidentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportManagers_ForCompanyId",
                table: "TransportManagers",
                column: "ForCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportManagers_ForPassengerId",
                table: "TransportManagers",
                column: "ForPassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_CompanyId",
                table: "Vacancies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_ProfessionId",
                table: "Vacancies",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherReports_PermitedModelId",
                table: "WeatherReports",
                column: "PermitedModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airlines");

            migrationBuilder.DropTable(
                name: "CitizensTasks");

            migrationBuilder.DropTable(
                name: "EmergencyCertificate");

            migrationBuilder.DropTable(
                name: "EmergencyReport");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "ScheduleModel");

            migrationBuilder.DropTable(
                name: "SportEvents");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "TimelineModel");

            migrationBuilder.DropTable(
                name: "TransportManagers");

            migrationBuilder.DropTable(
                name: "Vacancies");

            migrationBuilder.DropTable(
                name: "WeatherReports");

            migrationBuilder.DropTable(
                name: "SportComplex");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "ResidentAccount");

            migrationBuilder.DropTable(
                name: "ForCompanies");

            migrationBuilder.DropTable(
                name: "ForPassengers");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropTable(
                name: "PermitedModel");

            migrationBuilder.DropTable(
                name: "Marriage");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "CompanyStatuses");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");
        }
    }
}
