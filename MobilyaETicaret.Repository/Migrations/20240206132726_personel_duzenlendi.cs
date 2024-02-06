using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobilyaETicaret.Repository.Migrations
{
    /// <inheritdoc />
    public partial class personelduzenlendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Personeller_KullaniciId",
                table: "Personeller");

            migrationBuilder.DropColumn(
                name: "AktifMi",
                table: "SiparisBilgileri");

            migrationBuilder.DropColumn(
                name: "EklenmeTarih",
                table: "SiparisBilgileri");

            migrationBuilder.DropColumn(
                name: "ToplamFiyat",
                table: "SiparisBilgileri");

            migrationBuilder.AlterColumn<decimal>(
                name: "UrunFiyat",
                table: "SiparisBilgileri",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "SiparisBilgileri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_KullaniciId",
                table: "Personeller",
                column: "KullaniciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Personeller_KullaniciId",
                table: "Personeller");

            migrationBuilder.DropColumn(
                name: "Adres",
                table: "SiparisBilgileri");

            migrationBuilder.AlterColumn<string>(
                name: "UrunFiyat",
                table: "SiparisBilgileri",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<bool>(
                name: "AktifMi",
                table: "SiparisBilgileri",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "EklenmeTarih",
                table: "SiparisBilgileri",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "ToplamFiyat",
                table: "SiparisBilgileri",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_KullaniciId",
                table: "Personeller",
                column: "KullaniciId",
                unique: true,
                filter: "[KullaniciId] IS NOT NULL");
        }
    }
}
