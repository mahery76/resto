namespace resto.domain.Entities;

public class Produit
{
    public Guid Id { get; set; } = Guid.NewGuid(); 
    public string Nom { get; set; } = null!;
    public decimal Prix { get; set; }
    public ICollection<Commande> Commande { get; set; } = new List<Commande>();
}


