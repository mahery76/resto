using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace resto.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixProduitCommandeRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Produits_ProduitId1",
                table: "Commandes");

            migrationBuilder.DropIndex(
                name: "IX_Commandes_ProduitId1",
                table: "Commandes");

            migrationBuilder.DropColumn(
                name: "ProduitId1",
                table: "Commandes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProduitId1",
                table: "Commandes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_ProduitId1",
                table: "Commandes",
                column: "ProduitId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Produits_ProduitId1",
                table: "Commandes",
                column: "ProduitId1",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
