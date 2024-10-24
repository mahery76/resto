using System.Threading.Tasks;
using resto.domain.Entities;

namespace resto.domain.Repositories;

public interface IProduitRepository
{
    Task<Produit> GetByIdAsync(Guid id);
    Task<IEnumerable<Produit>> GetAllAsync();
    Task CreateAsync(Produit produit);
    Task<int> UpdateAsync(Produit produit);
    Task<int> DeleteAsync(Guid id);
}
