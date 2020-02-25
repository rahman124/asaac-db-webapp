using Microsoft.EntityFrameworkCore.Migrations;

namespace AST.WebApplication.Migrations
{
    public partial class AddedNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "LogAppeal");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "LogAppeal",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "LogAppeal",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "LogAppeal");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "LogAppeal");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LogAppeal",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
