using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class DataCaptureInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Report",
                table: "EmergencyReport",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DataCapture",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Header = table.Column<string>(maxLength: 100, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    AuthorId = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: true),
                    Ready = table.Column<bool>(nullable: false),
                    Published = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataCapture", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataCapture");

            migrationBuilder.AlterColumn<string>(
                name: "Report",
                table: "EmergencyReport",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
