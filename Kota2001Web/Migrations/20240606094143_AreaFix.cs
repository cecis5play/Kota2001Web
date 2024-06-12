using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kota2001Web.Migrations
{
    public partial class AreaFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Vehicles");
        }
    }
}
