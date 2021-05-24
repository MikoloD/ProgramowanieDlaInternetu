using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApplication.Migrations
{
    public partial class Games : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GamesId",
                table: "MistbornCharacters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GamesId",
                table: "MistbornCharacters");
        }
    }
}
