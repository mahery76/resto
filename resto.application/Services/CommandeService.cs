using System;
using resto.domain.Entities;
using resto.domain.Repositories;
using resto.application.Contracts;

namespace resto.application.Services;

public class CommandeService : ICommandeContract
{
    private readonly ICommandeRepository _repository;

    public CommandeService(ICommandeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Commande> GetCommandeByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }
    public async Task<IEnumerable<Commande>> GetAllCommandeAsync()
    {
        return await _repository.GetAllAsync();
    } 
    public async Task CreateCommandeAsync(Commande commande)
    {
        commande.Id = Guid.NewGuid();
        await _repository.CreateAsync(commande);
    }
    public async Task UpdateCommandeAsync(Commande commande)
    {
        await _repository.UpdateAsync(commande);
    }
    public async Task DeleteCommandeAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
