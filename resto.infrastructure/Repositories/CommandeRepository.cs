using System;
using Microsoft.EntityFrameworkCore;
using resto.domain.Entities;
using resto.domain.Repositories;
using resto.infrastructure.Data;

namespace resto.infrastructure.Repositories;

public class CommandeRepository : ICommandeRepository
{
    private readonly PostgresContext _context;

    public CommandeRepository(PostgresContext context)
    {
        _context = context;
    }

    public async Task<Commande> GetByIdAsync(Guid id)
    {
        var commande = await _context.Commandes.FindAsync(id);
        return commande ?? throw new InvalidOperationException("commande not found");
    }
    public async Task<IEnumerable<Commande>> GetAllAsync()
    {
        return await _context.Commandes.ToListAsync();
    }
    public async Task CreateAsync(Commande commande)
    {
        await _context.Commandes.AddAsync(commande);
        await _context.SaveChangesAsync();
    }


}
