using Microsoft.EntityFrameworkCore.Migrations;

namespace Webshop.Data.Migrations
{
    public partial class NoPassSent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Logins");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
