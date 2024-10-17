using System.ComponentModel.DataAnnotations.Schema;

namespace resto.domain.Entities;

public class Produit
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Nom { get; set; } = null!;
    public decimal Prix { get; set; }
}


