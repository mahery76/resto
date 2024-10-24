using System.Threading.Tasks;
using resto.domain.Entities;

namespace resto.application.Contracts;

public interface IProduitContract
{
    Task<Produit> GetProduitByIdAsync(Guid id);
    Task<IEnumerable<Produit>> GetAllProduitsAsync();
    Task CreateProduitAsync(Produit produit);
    Task<int> UpdateProduitAsync(Produit produit);
    Task<int> DeleteProduitAsync(Guid id);
}

