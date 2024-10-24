using System;
using resto.domain.Entities;
namespace resto.application.Contracts;

public interface ICommandeContract
{
    Task<Commande> GetCommandeByIdAsync(Guid id);

    Task<IEnumerable<Commande>> GetAllCommandeAsync();

    Task CreateCommandeAsync(Commande commande);
}
