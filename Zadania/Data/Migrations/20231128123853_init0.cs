using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zadania.Data.Migrations
{
    public partial class init0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zadanie_Uczen_UczenId",
                table: "Zadanie");

            migrationBuilder.DropIndex(
                name: "IX_Zadanie_UczenId",
                table: "Zadanie");

            migrationBuilder.DropColumn(
                name: "UczenId",
                table: "Zadanie");

            migrationBuilder.AddColumn<int>(
                name: "KlasaId",
                table: "Uczen",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Uczen_KlasaId",
                table: "Uczen",
                column: "KlasaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uczen_Klasa_KlasaId",
                table: "Uczen",
                column: "KlasaId",
                principalTable: "Klasa",
                principalColumn: "KlasaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uczen_Klasa_KlasaId",
                table: "Uczen");

            migrationBuilder.DropIndex(
                name: "IX_Uczen_KlasaId",
                table: "Uczen");

            migrationBuilder.DropColumn(
                name: "KlasaId",
                table: "Uczen");

            migrationBuilder.AddColumn<int>(
                name: "UczenId",
                table: "Zadanie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zadanie_UczenId",
                table: "Zadanie",
                column: "UczenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zadanie_Uczen_UczenId",
                table: "Zadanie",
                column: "UczenId",
                principalTable: "Uczen",
                principalColumn: "UczenId");
        }
    }
}
