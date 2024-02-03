using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobilyaETicaret.Repository.Migrations
{
    /// <inheritdoc />
    public partial class VeritabaniIyilestirildi3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Musteriler_KullaniciId",
                table: "Musteriler");

            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_KullaniciId",
                table: "Musteriler",
                column: "KullaniciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Musteriler_KullaniciId",
                table: "Musteriler");

            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_KullaniciId",
                table: "Musteriler",
                column: "KullaniciId",
                unique: true,
                filter: "[KullaniciId] IS NOT NULL");
        }
    }
}
