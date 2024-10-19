using System;
using resto.domain.Entities;
namespace resto.domain.Repositories;

public interface ICommandeRepository
{
    Task<Commande> GetByIdAsync(Guid id);

    Task<IEnumerable<Commande>> GetAllAsync();

    Task CreateAsync(Commande commande);
    Task UpdateAsync(Commande commande);
    Task DeleteAsync(Guid id);
}
