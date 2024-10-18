using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using resto.domain.Entities;
using resto.domain.Repositories;
using resto.infrastructure.Data;


namespace resto.infrastructure.Repositories;

public class ProduitRepository : IProduitRepository
{
    private readonly PostgresProduitContext _context;

    public ProduitRepository(PostgresProduitContext context)
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

    public async Task UpdateAsync(Produit produit)
    {
        _context.Produits.Update(produit);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var produit = await GetByIdAsync(id);
        if (produit != null)
        {
            _context.Produits.Remove(produit);
            await _context.SaveChangesAsync();
        }
    }
}
