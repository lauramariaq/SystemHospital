using Microsoft.EntityFrameworkCore.Migrations;

namespace SytemHospital.Model.Migrations
{
    public partial class _7abrilv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Rooms",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Patients",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rooms",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Patients",
                newName: "id");
        }
    }
}
