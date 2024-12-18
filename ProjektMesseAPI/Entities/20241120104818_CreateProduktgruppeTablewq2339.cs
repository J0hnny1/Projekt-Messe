using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektMesseAPI.Entities
{
    /// <inheritdoc />
    public partial class CreateProduktgruppeTablewq2339 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kunden_Firma_FirmaID",
                table: "Kunden");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchKundeProduktgruppe_Produktgruppe_ProduktgruppenID",
                table: "MatchKundeProduktgruppe");

            migrationBuilder.DropIndex(
                name: "IX_MatchKundeProduktgruppe_ProduktgruppenID",
                table: "MatchKundeProduktgruppe");

            migrationBuilder.DropColumn(
                name: "ProduktgruppenID",
                table: "MatchKundeProduktgruppe");

            migrationBuilder.RenameColumn(
                name: "ProduktgruppenId",
                table: "MatchKundeProduktgruppe",
                newName: "ProduktgruppenID");

            migrationBuilder.AlterColumn<int>(
                name: "FirmaID",
                table: "Kunden",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_MatchKundeProduktgruppe_ProduktgruppenID",
                table: "MatchKundeProduktgruppe",
                column: "ProduktgruppenID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kunden_Firma_FirmaID",
                table: "Kunden",
                column: "FirmaID",
                principalTable: "Firma",
                principalColumn: "FirmaID");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchKundeProduktgruppe_Produktgruppe_ProduktgruppenID",
                table: "MatchKundeProduktgruppe",
                column: "ProduktgruppenID",
                principalTable: "Produktgruppe",
                principalColumn: "ProduktgruppenID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kunden_Firma_FirmaID",
                table: "Kunden");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchKundeProduktgruppe_Produktgruppe_ProduktgruppenID",
                table: "MatchKundeProduktgruppe");

            migrationBuilder.DropIndex(
                name: "IX_MatchKundeProduktgruppe_ProduktgruppenID",
                table: "MatchKundeProduktgruppe");

            migrationBuilder.RenameColumn(
                name: "ProduktgruppenID",
                table: "MatchKundeProduktgruppe",
                newName: "ProduktgruppenId");

            migrationBuilder.AddColumn<int>(
                name: "ProduktgruppenID",
                table: "MatchKundeProduktgruppe",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FirmaID",
                table: "Kunden",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchKundeProduktgruppe_ProduktgruppenID",
                table: "MatchKundeProduktgruppe",
                column: "ProduktgruppenID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kunden_Firma_FirmaID",
                table: "Kunden",
                column: "FirmaID",
                principalTable: "Firma",
                principalColumn: "FirmaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchKundeProduktgruppe_Produktgruppe_ProduktgruppenID",
                table: "MatchKundeProduktgruppe",
                column: "ProduktgruppenID",
                principalTable: "Produktgruppe",
                principalColumn: "ProduktgruppenID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
