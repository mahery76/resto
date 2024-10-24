using System;
using resto.domain.Entities;
namespace resto.application.Dtos.Responses;

public class GetCommandeResponseDto
{
    public Guid Id { get; set; } 
    public decimal QuantiteProduit { get; set; }
    public DateTime DateCommande { get; set; }
    public Produit? Produit { get; set; } 
}
