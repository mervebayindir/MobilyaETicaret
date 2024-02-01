using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobilyaETicaret.Repository.Migrations
{
    /// <inheritdoc />
    public partial class krediKartDuzen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "SepetId",
               table: "Siparisler");

            migrationBuilder.AlterColumn<string>(
                name: "KartSeriNo",
                table: "KrediKartBilgileri",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CVC",
                table: "KrediKartBilgileri",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "SiparisBilgileri",
                columns: table => new
                {
                    OdemeTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiparisId = table.Column<int>(type: "int", nullable: false),
                    ToplamFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    EklenmeTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    MusteriAdiSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefonu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiparisBilgileri");

            migrationBuilder.AlterColumn<string>(
                name: "KartSeriNo",
                table: "KrediKartBilgileri",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<int>(
                name: "CVC",
                table: "KrediKartBilgileri",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AddColumn<int>(
                name: "SepetId",
                table: "Siparisler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
