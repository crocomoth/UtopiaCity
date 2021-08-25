﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UtopiaCity.Data;

namespace UtopiaCity.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("UtopiaCity.Models.Airport.Airline", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Aircraft")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AirlineName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AvailableDirections")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Airlines");
                });

            modelBuilder.Entity("UtopiaCity.Models.Airport.ArrivingPassenger", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("PassengerBirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PassengerFamilyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerMarriageStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ArrivingPassengers");
                });

            modelBuilder.Entity("UtopiaCity.Models.Airport.Flight", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DestinationPoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FlightNumber")
                        .HasColumnType("int");

                    b.Property<string>("LocationPoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfAircraft")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Weather")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("UtopiaCity.Models.Airport.Passenger", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PassengerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgressStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResidentAccountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TicketId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ResidentAccountId");

                    b.HasIndex("TicketId");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("UtopiaCity.Models.Airport.Ticket", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Direction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlightId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PermitedModelId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ResidentAccountId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.HasIndex("PermitedModelId");

                    b.HasIndex("ResidentAccountId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("UtopiaCity.Models.Airport.TransportManagerSystem.ForCompany", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AviaProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contacts")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryOfDelivery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuantityOfGoods")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WaitingTime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ForCompanies");
                });

            modelBuilder.Entity("UtopiaCity.Models.Airport.TransportManagerSystem.ForPassenger", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransportType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ForPassengers");
                });

            modelBuilder.Entity("UtopiaCity.Models.Airport.TransportManagerSystem.TransportManager", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ForCompanyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ForPassengerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TypeOfOrder")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ForCompanyId");

                    b.HasIndex("ForPassengerId");

                    b.ToTable("TransportManagers");
                });

            modelBuilder.Entity("UtopiaCity.Models.Airport.WeatherReport", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DirectionFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirectionTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlightWeather")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Moisture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PermitedModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Rainfall")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Temperature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WeatherCondition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wind")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PermitedModelId");

                    b.ToTable("WeatherReports");
                });

            modelBuilder.Entity("UtopiaCity.Models.Business.Bank", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BIK")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("UtopiaCity.Models.Business.Company", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BIN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CEO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyStatusId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IIK")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("CompanyStatusId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("UtopiaCity.Models.Business.CompanyStatus", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CompanyStatuses");
                });

            modelBuilder.Entity("UtopiaCity.Models.Business.Employee", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CompanyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FIO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfessionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProfessionId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("UtopiaCity.Models.Business.Profession", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Professions");
                });

            modelBuilder.Entity("UtopiaCity.Models.Business.Vacancy", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CompanyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Discription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfessionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Requirement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProfessionId");

                    b.ToTable("Vacancies");
                });

            modelBuilder.Entity("UtopiaCity.Models.CitizenAccount.CitizensTask", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReminderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CitizensTasks");
                });

            modelBuilder.Entity("UtopiaCity.Models.CityAdministration.Marriage", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstPersonData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstPersonId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MarriageDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecondPersonData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondPersonId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Marriage");
                });

            modelBuilder.Entity("UtopiaCity.Models.CityAdministration.ResidentAccount", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MarriageId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MarriageId");

                    b.ToTable("ResidentAccount");
                });

            modelBuilder.Entity("UtopiaCity.Models.Emergency.EmergencyCertificate", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmergencyCertificate");
                });

            modelBuilder.Entity("UtopiaCity.Models.Emergency.EmergencyReport", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Report")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReportTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("EmergencyReport");
                });

            modelBuilder.Entity("UtopiaCity.Models.Life.Event", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventType")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("UtopiaCity.Models.Sport.SportComplex", b =>
                {
                    b.Property<string>("SportComplexId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BuildDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeOfSport")
                        .HasColumnType("int");

                    b.HasKey("SportComplexId");

                    b.ToTable("SportComplex");
                });

            modelBuilder.Entity("UtopiaCity.Models.Sport.SportEvent", b =>
                {
                    b.Property<string>("SportEventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfTheEvent")
                        .HasColumnType("datetime2");

                    b.Property<string>("SportComplexId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SportEventId");

                    b.HasIndex("SportComplexId");

                    b.ToTable("SportEvents");
                });

            modelBuilder.Entity("UtopiaCity.Models.TimelineModel.PermitedModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("GovernmentStatus")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PermissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PermissionStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rainfall")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Season")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpeedOfWind")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeOfDay")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PermitedModel");
                });

            modelBuilder.Entity("UtopiaCity.Models.TimelineModel.ScheduleModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EventName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeOfEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeOfStart")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ScheduleModel");
                });

            modelBuilder.Entity("UtopiaCity.Models.TimelineModel.TimelineModel", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DayAndYear")
                        .HasColumnType("datetime2");

                    b.Property<string>("Schedule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TranscriptionOfPermission")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniqueRules")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TimelineModel");
                });

            modelBuilder.Entity("UtopiaCity.Models.CitizenAccount.AppUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("AppUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UtopiaCity.Models.Airport.Passenger", b =>
                {
                    b.HasOne("UtopiaCity.Models.CityAdministration.ResidentAccount", "ResidentAccount")
                        .WithMany()
                        .HasForeignKey("ResidentAccountId");

                    b.HasOne("UtopiaCity.Models.Airport.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId");
                });

            modelBuilder.Entity("UtopiaCity.Models.Airport.Ticket", b =>
                {
                    b.HasOne("UtopiaCity.Models.Airport.Flight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId");

                    b.HasOne("UtopiaCity.Models.TimelineModel.PermitedModel", "PermitedModel")
                        .WithMany()
                        .HasForeignKey("PermitedModelId");

                    b.HasOne("UtopiaCity.Models.CityAdministration.ResidentAccount", "ResidentAccount")
                        .WithMany()
                        .HasForeignKey("ResidentAccountId");
                });

            modelBuilder.Entity("UtopiaCity.Models.Airport.TransportManagerSystem.TransportManager", b =>
                {
                    b.HasOne("UtopiaCity.Models.Airport.TransportManagerSystem.ForCompany", "ForCompany")
                        .WithMany()
                        .HasForeignKey("ForCompanyId");

                    b.HasOne("UtopiaCity.Models.Airport.TransportManagerSystem.ForPassenger", "ForPassenger")
                        .WithMany()
                        .HasForeignKey("ForPassengerId");
                });

            modelBuilder.Entity("UtopiaCity.Models.Airport.WeatherReport", b =>
                {
                    b.HasOne("UtopiaCity.Models.TimelineModel.PermitedModel", "PermitedModel")
                        .WithMany()
                        .HasForeignKey("PermitedModelId");
                });

            modelBuilder.Entity("UtopiaCity.Models.Business.Company", b =>
                {
                    b.HasOne("UtopiaCity.Models.Business.Bank", "Bank")
                        .WithMany("Companies")
                        .HasForeignKey("BankId");

                    b.HasOne("UtopiaCity.Models.Business.CompanyStatus", "CompanyStatus")
                        .WithMany("Companies")
                        .HasForeignKey("CompanyStatusId");
                });

            modelBuilder.Entity("UtopiaCity.Models.Business.Employee", b =>
                {
                    b.HasOne("UtopiaCity.Models.Business.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId");

                    b.HasOne("UtopiaCity.Models.Business.Profession", "Profession")
                        .WithMany("Employees")
                        .HasForeignKey("ProfessionId");
                });

            modelBuilder.Entity("UtopiaCity.Models.Business.Vacancy", b =>
                {
                    b.HasOne("UtopiaCity.Models.Business.Company", "Company")
                        .WithMany("Vacancies")
                        .HasForeignKey("CompanyId");

                    b.HasOne("UtopiaCity.Models.Business.Profession", "Profession")
                        .WithMany("Vacancies")
                        .HasForeignKey("ProfessionId");
                });

            modelBuilder.Entity("UtopiaCity.Models.CitizenAccount.CitizensTask", b =>
                {
                    b.HasOne("UtopiaCity.Models.CitizenAccount.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("UtopiaCity.Models.CityAdministration.ResidentAccount", b =>
                {
                    b.HasOne("UtopiaCity.Models.CityAdministration.Marriage", "Marriage")
                        .WithMany()
                        .HasForeignKey("MarriageId");
                });

            modelBuilder.Entity("UtopiaCity.Models.Sport.SportEvent", b =>
                {
                    b.HasOne("UtopiaCity.Models.Sport.SportComplex", "SportComplex")
                        .WithMany("SportEvents")
                        .HasForeignKey("SportComplexId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
