using System;

namespace resto.application.Dtos.Responses;

public class GetProduitResponseDto
{
    public Guid Id { get; set; }
    public string Nom { get; set; } = null!;
    public decimal Prix { get; set; }
}
