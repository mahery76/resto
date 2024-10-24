using System;

namespace resto.application.Dtos.Requests;

public class CreateProduitRequestDto
{
    public string Nom { get; set; } = null!;
    public decimal Prix { get; set; }
}
