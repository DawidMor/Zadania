using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zadania.Data.Migrations
{
    public partial class _00001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NauczycielUserId",
                table: "Nauczyciel",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Nauczyciel_NauczycielUserId",
                table: "Nauczyciel",
                column: "NauczycielUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nauczyciel_AspNetUsers_NauczycielUserId",
                table: "Nauczyciel",
                column: "NauczycielUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nauczyciel_AspNetUsers_NauczycielUserId",
                table: "Nauczyciel");

            migrationBuilder.DropIndex(
                name: "IX_Nauczyciel_NauczycielUserId",
                table: "Nauczyciel");

            migrationBuilder.DropColumn(
                name: "NauczycielUserId",
                table: "Nauczyciel");
        }
    }
}
