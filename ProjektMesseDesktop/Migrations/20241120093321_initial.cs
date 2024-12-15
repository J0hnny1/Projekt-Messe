using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektMesseDesktop.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firma",
                columns: table => new
                {
                    FirmaID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PLZ = table.Column<string>(type: "TEXT", nullable: false),
                    Stadt = table.Column<string>(type: "TEXT", nullable: false),
                    Straße = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firma", x => x.FirmaID);
                });

            migrationBuilder.CreateTable(
                name: "Produktgruppe",
                columns: table => new
                {
                    ProduktgruppenID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produktgruppe", x => x.ProduktgruppenID);
                });

            migrationBuilder.CreateTable(
                name: "Kunden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Vorname = table.Column<string>(type: "TEXT", nullable: true),
                    Geburtstag = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PLZ = table.Column<string>(type: "TEXT", nullable: true),
                    Stadt = table.Column<string>(type: "TEXT", nullable: true),
                    Straße = table.Column<string>(type: "TEXT", nullable: true),
                    Firmenberater = table.Column<bool>(type: "INTEGER", nullable: true),
                    FirmaID = table.Column<int>(type: "INTEGER", nullable: true),
                    Bild = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunden", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kunden_Firma_FirmaID",
                        column: x => x.FirmaID,
                        principalTable: "Firma",
                        principalColumn: "FirmaID");
                });

            migrationBuilder.CreateTable(
                name: "MatchKundeProduktgruppe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KundeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProduktgruppenID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchKundeProduktgruppe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchKundeProduktgruppe_Kunden_KundeId",
                        column: x => x.KundeId,
                        principalTable: "Kunden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchKundeProduktgruppe_Produktgruppe_ProduktgruppenID",
                        column: x => x.ProduktgruppenID,
                        principalTable: "Produktgruppe",
                        principalColumn: "ProduktgruppenID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kunden_FirmaID",
                table: "Kunden",
                column: "FirmaID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchKundeProduktgruppe_KundeId",
                table: "MatchKundeProduktgruppe",
                column: "KundeId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchKundeProduktgruppe_ProduktgruppenID",
                table: "MatchKundeProduktgruppe",
                column: "ProduktgruppenID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchKundeProduktgruppe");

            migrationBuilder.DropTable(
                name: "Kunden");

            migrationBuilder.DropTable(
                name: "Produktgruppe");

            migrationBuilder.DropTable(
                name: "Firma");
        }
    }
}
