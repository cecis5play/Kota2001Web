using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kota2001Web.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Vehicles",
                newName: "VModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VModel",
                table: "Vehicles",
                newName: "Model");
        }
    }
}
