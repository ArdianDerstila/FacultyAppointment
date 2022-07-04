using Microsoft.EntityFrameworkCore.Migrations;

namespace FacultyAppointmentSystem.Migrations
{
    public partial class addsetstonames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dega",
                table: "Appointments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lendet",
                table: "Appointments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dega",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Lendet",
                table: "Appointments");
        }
    }
}
