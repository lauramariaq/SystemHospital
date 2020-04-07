using Microsoft.EntityFrameworkCore.Migrations;

namespace SytemHospital.Model.Migrations
{
    public partial class _7abrilv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                table: "Rooms",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Rooms",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "Rooms",
                newName: "Number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Rooms",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Rooms",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Rooms",
                newName: "number");
        }
    }
}
