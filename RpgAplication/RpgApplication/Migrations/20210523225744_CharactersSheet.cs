using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApplication.Migrations
{
    public partial class CharactersSheet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MistbornCharacters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CharacterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CharacterRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trait = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percepcion = table.Column<int>(type: "int", nullable: false),
                    Motorics = table.Column<int>(type: "int", nullable: false),
                    Physique = table.Column<int>(type: "int", nullable: false),
                    Psyche = table.Column<int>(type: "int", nullable: false),
                    Intellect = table.Column<int>(type: "int", nullable: false),
                    Presence = table.Column<int>(type: "int", nullable: false),
                    Steel = table.Column<int>(type: "int", nullable: false),
                    Iron = table.Column<int>(type: "int", nullable: false),
                    Lead = table.Column<int>(type: "int", nullable: false),
                    Tin = table.Column<int>(type: "int", nullable: false),
                    Zinc = table.Column<int>(type: "int", nullable: false),
                    Brass = table.Column<int>(type: "int", nullable: false),
                    Copper = table.Column<int>(type: "int", nullable: false),
                    Bronze = table.Column<int>(type: "int", nullable: false),
                    MeleWeapon = table.Column<int>(type: "int", nullable: false),
                    RangeWeapon = table.Column<int>(type: "int", nullable: false),
                    ThrowingWeapon = table.Column<int>(type: "int", nullable: false),
                    Evede = table.Column<int>(type: "int", nullable: false),
                    Parry = table.Column<int>(type: "int", nullable: false),
                    Block = table.Column<int>(type: "int", nullable: false),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    Steath = table.Column<int>(type: "int", nullable: false),
                    HorseRiding = table.Column<int>(type: "int", nullable: false),
                    Thievery = table.Column<int>(type: "int", nullable: false),
                    Observatione = table.Column<int>(type: "int", nullable: false),
                    Forgery = table.Column<int>(type: "int", nullable: false),
                    Alchemy = table.Column<int>(type: "int", nullable: false),
                    Crafting = table.Column<int>(type: "int", nullable: false),
                    Medicine = table.Column<int>(type: "int", nullable: false),
                    Painting = table.Column<int>(type: "int", nullable: false),
                    Music = table.Column<int>(type: "int", nullable: false),
                    Sailing = table.Column<int>(type: "int", nullable: false),
                    Knowledge = table.Column<int>(type: "int", nullable: false),
                    Heraldry = table.Column<int>(type: "int", nullable: false),
                    Calm = table.Column<int>(type: "int", nullable: false),
                    Empathy = table.Column<int>(type: "int", nullable: false),
                    Tactics = table.Column<int>(type: "int", nullable: false),
                    Charisma = table.Column<int>(type: "int", nullable: false),
                    Credibility = table.Column<int>(type: "int", nullable: false),
                    Intimidate = table.Column<int>(type: "int", nullable: false),
                    Persuasion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MistbornCharacters", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MistbornCharacters");
        }
    }
}
