using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArrivingPassengers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PassengerFirstName = table.Column<string>(nullable: true),
                    PassengerFamilyName = table.Column<string>(nullable: true),
                    PassengerBirthDate = table.Column<DateTime>(nullable: false),
                    PassengerGender = table.Column<string>(nullable: true),
                    PassengerStatus = table.Column<string>(nullable: true),
                    PassengerMarriageStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArrivingPassengers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    Balance = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "ClinicVisit",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Visit = table.Column<string>(nullable: false),
                    VisitTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicVisit", x => x.Id);
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
                    Address = table.Column<string>(nullable: false),
                    Available = table.Column<bool>(nullable: false)
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Friend",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstUserId = table.Column<string>(nullable: true),
                    SecondUserId = table.Column<string>(nullable: true),
                    FriendsStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friend_AspNetUsers_FirstUserId",
                        column: x => x.FirstUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friend_AspNetUsers_SecondUserId",
                        column: x => x.SecondUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Talks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserOneId = table.Column<string>(nullable: true),
                    UserTwoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Talks_AspNetUsers_UserOneId",
                        column: x => x.UserOneId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Talks_AspNetUsers_UserTwoId",
                        column: x => x.UserTwoId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "RequestsToAdministration",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    DateOfRequest = table.Column<DateTime>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    IsReviewed = table.Column<bool>(nullable: false),
                    SportComplexId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestsToAdministration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestsToAdministration_SportComplex_SportComplexId",
                        column: x => x.SportComplexId,
                        principalTable: "SportComplex",
                        principalColumn: "SportComplexId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    When = table.Column<DateTime>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    SenderId = table.Column<string>(nullable: true),
                    TalkId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Talks_TalkId",
                        column: x => x.TalkId,
                        principalTable: "Talks",
                        principalColumn: "Id",
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
                name: "RealEstate",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    ResidentAccountId = table.Column<string>(nullable: true),
                    CompletionYear = table.Column<int>(nullable: false),
                    EstateType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstate_ResidentAccount_ResidentAccountId",
                        column: x => x.ResidentAccountId,
                        principalTable: "ResidentAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "SportTickets",
                columns: table => new
                {
                    TicketId = table.Column<string>(nullable: false),
                    SportComplexId = table.Column<string>(nullable: false),
                    SportEventId = table.Column<string>(nullable: false),
                    AppUserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportTickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_SportTickets_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportTickets_SportComplex_SportComplexId",
                        column: x => x.SportComplexId,
                        principalTable: "SportComplex",
                        principalColumn: "SportComplexId");
                    table.ForeignKey(
                        name: "FK_SportTickets_SportEvents_SportEventId",
                        column: x => x.SportEventId,
                        principalTable: "SportEvents",
                        principalColumn: "SportEventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PassengerName = table.Column<string>(nullable: true),
                    ProgressStatus = table.Column<string>(nullable: true),
                    PassengerStatus = table.Column<string>(nullable: true),
                    TicketId = table.Column<string>(nullable: true),
                    ResidentAccountId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passengers_ResidentAccount_ResidentAccountId",
                        column: x => x.ResidentAccountId,
                        principalTable: "ResidentAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Passengers_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_Friend_FirstUserId",
                table: "Friend",
                column: "FirstUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friend_SecondUserId",
                table: "Friend",
                column: "SecondUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TalkId",
                table: "Messages",
                column: "TalkId");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_ResidentAccountId",
                table: "Passengers",
                column: "ResidentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_TicketId",
                table: "Passengers",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_ResidentAccountId",
                table: "RealEstate",
                column: "ResidentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestsToAdministration_SportComplexId",
                table: "RequestsToAdministration",
                column: "SportComplexId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentAccount_MarriageId",
                table: "ResidentAccount",
                column: "MarriageId");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_ProfessionId",
                table: "Resumes",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_ResidentAccountId",
                table: "Resumes",
                column: "ResidentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SportEvents_SportComplexId",
                table: "SportEvents",
                column: "SportComplexId");

            migrationBuilder.CreateIndex(
                name: "IX_SportTickets_AppUserId",
                table: "SportTickets",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SportTickets_SportComplexId",
                table: "SportTickets",
                column: "SportComplexId");

            migrationBuilder.CreateIndex(
                name: "IX_SportTickets_SportEventId",
                table: "SportTickets",
                column: "SportEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Talks_UserOneId",
                table: "Talks",
                column: "UserOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Talks_UserTwoId",
                table: "Talks",
                column: "UserTwoId");

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
                name: "ArrivingPassengers");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CitizensTasks");

            migrationBuilder.DropTable(
                name: "ClinicVisit");

            migrationBuilder.DropTable(
                name: "EmergencyCertificate");

            migrationBuilder.DropTable(
                name: "EmergencyReport");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Friend");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "RealEstate");

            migrationBuilder.DropTable(
                name: "RequestsToAdministration");

            migrationBuilder.DropTable(
                name: "Resumes");

            migrationBuilder.DropTable(
                name: "ScheduleModel");

            migrationBuilder.DropTable(
                name: "SportTickets");

            migrationBuilder.DropTable(
                name: "TimelineModel");

            migrationBuilder.DropTable(
                name: "TransportManagers");

            migrationBuilder.DropTable(
                name: "Vacancies");

            migrationBuilder.DropTable(
                name: "WeatherReports");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Talks");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "SportEvents");

            migrationBuilder.DropTable(
                name: "ForCompanies");

            migrationBuilder.DropTable(
                name: "ForPassengers");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "PermitedModel");

            migrationBuilder.DropTable(
                name: "ResidentAccount");

            migrationBuilder.DropTable(
                name: "SportComplex");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "CompanyStatuses");

            migrationBuilder.DropTable(
                name: "Marriage");
        }
    }
}
