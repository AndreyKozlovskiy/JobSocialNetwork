using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessLogic.Migrations
{
    public partial class FirstFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescriptin",
                table: "Vacancies");

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Vacancies",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Vacancies");

            migrationBuilder.AddColumn<string>(
                name: "ShortDescriptin",
                table: "Vacancies",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);
        }
    }
}
