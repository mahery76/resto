using System;
using resto.domain.Entities;
namespace resto.application.Dtos;

public class CreateCommandeDto
{
    public decimal QuantiteProduit { get; set; }
    public DateTime DateCommande { get; set; }
    public Guid ProduitId { get; set; }
    public Produit? Produit { get; set; } 
}
