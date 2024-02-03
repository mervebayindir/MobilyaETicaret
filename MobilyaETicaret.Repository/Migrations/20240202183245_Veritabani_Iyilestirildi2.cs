using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobilyaETicaret.Repository.Migrations
{
    /// <inheritdoc />
    public partial class VeritabaniIyilestirildi2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_KullaniciId",
                table: "Musteriler",
                column: "KullaniciId",
                unique: true,
                filter: "[KullaniciId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Musteriler_Kullanicilar_KullaniciId",
                table: "Musteriler",
                column: "KullaniciId",
                principalTable: "Kullanicilar",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musteriler_Kullanicilar_KullaniciId",
                table: "Musteriler");

            migrationBuilder.DropIndex(
                name: "IX_Musteriler_KullaniciId",
                table: "Musteriler");
        }
    }
}
