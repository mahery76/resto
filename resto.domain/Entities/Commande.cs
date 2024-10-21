using System;
namespace resto.domain.Entities;

public class Commande
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal QuantiteProduit { get; set; }
    public DateTime DateCommande { get; set; }
    public Guid ProduitId { get; set; }
    public Produit? Produit { get; set; } // Navigation property
}


