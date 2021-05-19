using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApplication.Migrations
{
    public partial class Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            {
                migrationBuilder.InsertData(
                 table: "AspNetRoles",
                 columns: new[] { "Id", "Name", "NormalizedName" },
                 values: new object[] { "1", "Administrator", "ADMINISTRATOR" });

                migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName" },
                values: new object[] { "2", "Mistrz_Gry", "MISTRZ_GRY" });

                migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName" },
                values: new object[] { "3", "Gracz", "GRACZ" });
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
