using System.Threading.Tasks;
using resto.domain.Entities;

namespace resto.application.Contracts;

public interface IProductContract
{
    Task<Produit> GetProduitByIdAsync(Guid id);
    Task<IEnumerable<Produit>> GetAllProduitsAsync();
    Task CreateProduitAsync(Produit produit);
    Task UpdateProduitAsync(Produit produit);
    Task DeleteProduitAsync(Guid id);
}

