using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektMesseDesktop.Migrations
{
    /// <inheritdoc />
    public partial class CreateKundenTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kunde_Firma_FirmaID",
                table: "Kunde");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchKundeProduktgruppe_Kunde_KundeId",
                table: "MatchKundeProduktgruppe");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchKundeProduktgruppe_Produktgruppe_ProduktgruppenID",
                table: "MatchKundeProduktgruppe");

            migrationBuilder.DropIndex(
                name: "IX_MatchKundeProduktgruppe_ProduktgruppenID",
                table: "MatchKundeProduktgruppe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kunde",
                table: "Kunde");

            migrationBuilder.RenameTable(
                name: "Kunde",
                newName: "Kunden");

            migrationBuilder.RenameColumn(
                name: "ProduktgruppenID",
                table: "MatchKundeProduktgruppe",
                newName: "ProduktgruppenId");

            migrationBuilder.RenameIndex(
                name: "IX_Kunde_FirmaID",
                table: "Kunden",
                newName: "IX_Kunden_FirmaID");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kunden",
                table: "Kunden",
                column: "Id");

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
                name: "FK_MatchKundeProduktgruppe_Kunden_KundeId",
                table: "MatchKundeProduktgruppe",
                column: "KundeId",
                principalTable: "Kunden",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_MatchKundeProduktgruppe_Kunden_KundeId",
                table: "MatchKundeProduktgruppe");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchKundeProduktgruppe_Produktgruppe_ProduktgruppenID",
                table: "MatchKundeProduktgruppe");

            migrationBuilder.DropIndex(
                name: "IX_MatchKundeProduktgruppe_ProduktgruppenID",
                table: "MatchKundeProduktgruppe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kunden",
                table: "Kunden");

            migrationBuilder.DropColumn(
                name: "ProduktgruppenID",
                table: "MatchKundeProduktgruppe");

            migrationBuilder.RenameTable(
                name: "Kunden",
                newName: "Kunde");

            migrationBuilder.RenameColumn(
                name: "ProduktgruppenId",
                table: "MatchKundeProduktgruppe",
                newName: "ProduktgruppenID");

            migrationBuilder.RenameIndex(
                name: "IX_Kunden_FirmaID",
                table: "Kunde",
                newName: "IX_Kunde_FirmaID");

            migrationBuilder.AlterColumn<int>(
                name: "FirmaID",
                table: "Kunde",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kunde",
                table: "Kunde",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MatchKundeProduktgruppe_ProduktgruppenID",
                table: "MatchKundeProduktgruppe",
                column: "ProduktgruppenID");

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
