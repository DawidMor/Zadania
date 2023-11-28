using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zadania.Data.Migrations
{
    public partial class init01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CzyWyslanePoTerminie",
                table: "Zadanie",
                newName: "CzyMoznaWyslacPoTerminie");

            migrationBuilder.AddColumn<string>(
                name: "UczenUserId",
                table: "Uczen",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UczenZadanie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UczenId = table.Column<int>(type: "int", nullable: true),
                    ZadanieId = table.Column<int>(type: "int", nullable: true),
                    Tytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UczenZadanie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UczenZadanie_Uczen_UczenId",
                        column: x => x.UczenId,
                        principalTable: "Uczen",
                        principalColumn: "UczenId");
                    table.ForeignKey(
                        name: "FK_UczenZadanie_Zadanie_ZadanieId",
                        column: x => x.ZadanieId,
                        principalTable: "Zadanie",
                        principalColumn: "ZadanieId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Uczen_UczenUserId",
                table: "Uczen",
                column: "UczenUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UczenZadanie_UczenId",
                table: "UczenZadanie",
                column: "UczenId");

            migrationBuilder.CreateIndex(
                name: "IX_UczenZadanie_ZadanieId",
                table: "UczenZadanie",
                column: "ZadanieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uczen_AspNetUsers_UczenUserId",
                table: "Uczen",
                column: "UczenUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uczen_AspNetUsers_UczenUserId",
                table: "Uczen");

            migrationBuilder.DropTable(
                name: "UczenZadanie");

            migrationBuilder.DropIndex(
                name: "IX_Uczen_UczenUserId",
                table: "Uczen");

            migrationBuilder.DropColumn(
                name: "UczenUserId",
                table: "Uczen");

            migrationBuilder.RenameColumn(
                name: "CzyMoznaWyslacPoTerminie",
                table: "Zadanie",
                newName: "CzyWyslanePoTerminie");
        }
    }
}
