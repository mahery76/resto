using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using resto.domain.Entities;
using resto.domain.Repositories;
using resto.infrastructure.Data;

namespace resto.infrastructure.Repositories;

public class ProduitRepository : IProduitRepository
{
    private readonly PostgresContext _context;

    public ProduitRepository(PostgresContext context)
    {
        _context = context;
    }

    public async Task<Produit> GetByIdAsync(Guid id)
    {
        var produit = await _context.Produits.FindAsync(id);
        return produit ?? throw new InvalidOperationException("produit not found");
    }

    public async Task<IEnumerable<Produit>> GetAllAsync()
    {
        return await _context.Produits.ToListAsync();
    }

    public async Task CreateAsync(Produit produit)
    {
        await _context.Produits.AddAsync(produit);
        await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(Produit produit)
    {
        _context.Produits.Update(produit);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(Guid id)
    {
        var produit = await GetByIdAsync(id);
        if (produit != null)
        {
            _context.Produits.Remove(produit);
            return await _context.SaveChangesAsync();
        }
        return 0; 
    }
}
