using System;

namespace resto.domain.Entities;

public class Commande
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string ProduitId { get; set; } = null!;

    public decimal Quantite { get; set; }
    public Produit Produit { get; set; } = null!; // Navigation property

}


