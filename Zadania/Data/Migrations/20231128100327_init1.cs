using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zadania.Data.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klasa",
                columns: table => new
                {
                    KlasaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaKlasy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klasa", x => x.KlasaId);
                });

            migrationBuilder.CreateTable(
                name: "Nauczyciel",
                columns: table => new
                {
                    NauczycielId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nauczyciel", x => x.NauczycielId);
                });

            migrationBuilder.CreateTable(
                name: "Uczen",
                columns: table => new
                {
                    UczenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uczen", x => x.UczenId);
                });

            migrationBuilder.CreateTable(
                name: "Zadanie",
                columns: table => new
                {
                    ZadanieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataWaznosci = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CzyWyslanePoTerminie = table.Column<bool>(type: "bit", nullable: false),
                    Punktacja = table.Column<int>(type: "int", nullable: true),
                    UczenId = table.Column<int>(type: "int", nullable: true),
                    KlasaId = table.Column<int>(type: "int", nullable: true),
                    NauczycielId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zadanie", x => x.ZadanieId);
                    table.ForeignKey(
                        name: "FK_Zadanie_Klasa_KlasaId",
                        column: x => x.KlasaId,
                        principalTable: "Klasa",
                        principalColumn: "KlasaId");
                    table.ForeignKey(
                        name: "FK_Zadanie_Nauczyciel_NauczycielId",
                        column: x => x.NauczycielId,
                        principalTable: "Nauczyciel",
                        principalColumn: "NauczycielId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zadanie_Uczen_UczenId",
                        column: x => x.UczenId,
                        principalTable: "Uczen",
                        principalColumn: "UczenId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zadanie_KlasaId",
                table: "Zadanie",
                column: "KlasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zadanie_NauczycielId",
                table: "Zadanie",
                column: "NauczycielId");

            migrationBuilder.CreateIndex(
                name: "IX_Zadanie_UczenId",
                table: "Zadanie",
                column: "UczenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zadanie");

            migrationBuilder.DropTable(
                name: "Klasa");

            migrationBuilder.DropTable(
                name: "Nauczyciel");

            migrationBuilder.DropTable(
                name: "Uczen");
        }
    }
}
