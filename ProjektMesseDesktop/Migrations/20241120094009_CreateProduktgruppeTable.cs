using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektMesseDesktop.Migrations
{
    /// <inheritdoc />
    public partial class CreateProduktgruppeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kunden_Firma_FirmaID",
                table: "Kunden");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchKundeProduktgruppe_Kunden_KundeId",
                table: "MatchKundeProduktgruppe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kunden",
                table: "Kunden");

            migrationBuilder.RenameTable(
                name: "Kunden",
                newName: "Kunde");

            migrationBuilder.RenameIndex(
                name: "IX_Kunden_FirmaID",
                table: "Kunde",
                newName: "IX_Kunde_FirmaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kunde",
                table: "Kunde",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kunde_Firma_FirmaID",
                table: "Kunde",
                column: "FirmaID",
                principalTable: "Firma",
                principalColumn: "FirmaID");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchKundeProduktgruppe_Kunde_KundeId",
                table: "MatchKundeProduktgruppe",
                column: "KundeId",
                principalTable: "Kunde",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kunde_Firma_FirmaID",
                table: "Kunde");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchKundeProduktgruppe_Kunde_KundeId",
                table: "MatchKundeProduktgruppe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kunde",
                table: "Kunde");

            migrationBuilder.RenameTable(
                name: "Kunde",
                newName: "Kunden");

            migrationBuilder.RenameIndex(
                name: "IX_Kunde_FirmaID",
                table: "Kunden",
                newName: "IX_Kunden_FirmaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kunden",
                table: "Kunden",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kunden_Firma_FirmaID",
                table: "Kunden",
                column: "FirmaID",
                principalTable: "Firma",
                principalColumn: "FirmaID");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchKundeProduktgruppe_Kunden_KundeId",
                table: "MatchKundeProduktgruppe",
                column: "KundeId",
                principalTable: "Kunden",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
