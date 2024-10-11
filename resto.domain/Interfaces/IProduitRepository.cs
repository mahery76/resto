using System.Threading.Tasks;
using resto.domain.Entities;

namespace resto.domain.Interfaces;

public interface IProduitRepository
{
    Task<Produit> GetByIdAsync(Guid id);
    Task<IEnumerable<Produit>> GetAllAsync();
    Task CreateAsync(Produit produit);
    Task UpdateAsync(Produit produit);
    Task DeleteAsync(Guid id);
}
