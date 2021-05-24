using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApplication.Migrations
{
    public partial class AddedRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MistbornCharacters",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromUserId",
                table: "GameMessages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameUsers", x => new { x.GameId, x.UserId });
                    table.ForeignKey(
                        name: "FK_GameUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameUsers_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MistbornCharacters_UserId",
                table: "MistbornCharacters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameMessages_FromUserId",
                table: "GameMessages",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameUsers_UserId",
                table: "GameUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameMessages_AspNetUsers_FromUserId",
                table: "GameMessages",
                column: "FromUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MistbornCharacters_AspNetUsers_UserId",
                table: "MistbornCharacters",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameMessages_AspNetUsers_FromUserId",
                table: "GameMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_MistbornCharacters_AspNetUsers_UserId",
                table: "MistbornCharacters");

            migrationBuilder.DropTable(
                name: "GameUsers");

            migrationBuilder.DropIndex(
                name: "IX_MistbornCharacters_UserId",
                table: "MistbornCharacters");

            migrationBuilder.DropIndex(
                name: "IX_GameMessages_FromUserId",
                table: "GameMessages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MistbornCharacters");

            migrationBuilder.DropColumn(
                name: "FromUserId",
                table: "GameMessages");
        }
    }
}
