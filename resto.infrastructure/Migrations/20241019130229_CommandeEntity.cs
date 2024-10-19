using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace resto.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CommandeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuantiteProduit = table.Column<decimal>(type: "numeric", nullable: false),
                    DateCommande = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProduitId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProduitId1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commandes_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commandes_Produits_ProduitId1",
                        column: x => x.ProduitId1,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_ProduitId",
                table: "Commandes",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_ProduitId1",
                table: "Commandes",
                column: "ProduitId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commandes");
        }
    }
}
