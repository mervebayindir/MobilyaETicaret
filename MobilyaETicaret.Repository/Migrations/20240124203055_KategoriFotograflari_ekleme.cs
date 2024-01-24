using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobilyaETicaret.Repository.Migrations
{
    /// <inheritdoc />
    public partial class KategoriFotograflariekleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kategoriler_Fotograflar_FotografId",
                table: "Kategoriler");

            migrationBuilder.DropIndex(
                name: "IX_Kategoriler_FotografId",
                table: "Kategoriler");

            migrationBuilder.DropColumn(
                name: "FotografId",
                table: "Kategoriler");

            migrationBuilder.AlterColumn<string>(
                name: "FotografAciklamasi",
                table: "Fotograflar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "AdresMusteri",
                columns: table => new
                {
                    AdresId = table.Column<int>(type: "int", nullable: false),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    AdresBasligi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostaKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    EklenmeTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MusteriAdiSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IlceAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IlAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "KategoriFotograflari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotografYolu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FotografAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FotografAciklamasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    EklenmeTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KullaniciId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategoriFotograflari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KategoriFotograflari_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KategoriFotograflari_KategoriId",
                table: "KategoriFotograflari",
                column: "KategoriId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdresMusteri");

            migrationBuilder.DropTable(
                name: "KategoriFotograflari");

            migrationBuilder.AddColumn<int>(
                name: "FotografId",
                table: "Kategoriler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "FotografAciklamasi",
                table: "Fotograflar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kategoriler_FotografId",
                table: "Kategoriler",
                column: "FotografId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kategoriler_Fotograflar_FotografId",
                table: "Kategoriler",
                column: "FotografId",
                principalTable: "Fotograflar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
