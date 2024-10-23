using System;

namespace resto.application.Dtos.Requests;

public class CreateCommandeRequestDto
{
    public decimal QuantiteProduit { get; set; }
    public Guid ProduitId { get; set; }
}
