using Microsoft.EntityFrameworkCore.Migrations;

namespace Webshop.Data.Migrations
{
    public partial class Revert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Logins",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Logins");
        }
    }
}
