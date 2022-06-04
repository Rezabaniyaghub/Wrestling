using Microsoft.EntityFrameworkCore.Migrations;

namespace WrestlingSchool.WebApp.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirsName",
                table: "WrestlingSchools",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "WrestlingSchools",
                newName: "FirsName");
        }
    }
}
