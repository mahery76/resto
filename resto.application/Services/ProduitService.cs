using System.Threading.Tasks;
using resto.domain.Entities;
using resto.domain.Interfaces;
using resto.application.Contracts;

namespace resto.application.Services;

public class ProduitService : IProductContract
{
    private readonly IProduitRepository _repository;

    public ProduitService(IProduitRepository repository)
    {
        _repository = repository;
    }

    public async Task<Produit> GetProduitByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Produit>> GetAllProduitsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task CreateProduitAsync(Produit produit)
    {
        await _repository.CreateAsync(produit);
    }

    public async Task UpdateProduitAsync(Produit produit)
    {
        await _repository.UpdateAsync(produit);
    }

    public async Task DeleteProduitAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}

