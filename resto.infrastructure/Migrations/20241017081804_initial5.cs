using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace resto.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prix_produit",
                table: "Produits",
                newName: "Prix");

            migrationBuilder.RenameColumn(
                name: "Nom_Produit",
                table: "Produits",
                newName: "Nom");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prix",
                table: "Produits",
                newName: "Prix_produit");

            migrationBuilder.RenameColumn(
                name: "Nom",
                table: "Produits",
                newName: "Nom_Produit");
        }
    }
}
