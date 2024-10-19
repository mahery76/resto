using Microsoft.AspNetCore.Mvc;
using resto.application.Contracts;
using resto.domain.Entities;

namespace resto.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommandesController : ControllerBase
{
    private readonly ICommandeContract _commandeService;

    public CommandesController(ICommandeContract commandeService)
    {
        _commandeService = commandeService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Commande>> GetCommandeById(Guid id)
    {
        var Commande = await _commandeService.GetCommandeByIdAsync(id);
        return Ok(new Commande
        {
            Id = Commande.Id,
            QuantiteProduit = Commande.QuantiteProduit,
            DateCommande = Commande.DateCommande,
            // we need to return produit object here
            ProduitId = Commande.ProduitId
        });
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Commande>>> GetAllCommandes()
    {
        var AllCommandes = await _commandeService.GetAllCommandeAsync();
        return Ok(AllCommandes.Select(CurrentCommande => new Commande
        {
            Id = CurrentCommande.Id,
            DateCommande = CurrentCommande.DateCommande,
            QuantiteProduit = CurrentCommande.QuantiteProduit,
            ProduitId = CurrentCommande.ProduitId
        }));
    }

    [HttpPost]
    public async Task<ActionResult<Commande>> CreateCommande(Commande dto)
    {
        var Commande = new Commande
        {
            DateCommande = dto.DateCommande,
            QuantiteProduit = dto.QuantiteProduit,
            ProduitId = dto.ProduitId
        };
        await _commandeService.CreateCommandeAsync(Commande);
        return CreatedAtAction(nameof(GetCommandeById), new {id = Commande.Id }, new Commande
        {
            Id = Commande.Id,
            DateCommande = Commande.DateCommande,
            QuantiteProduit = Commande.QuantiteProduit,
            ProduitId = Commande.ProduitId
        });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCommande(Guid id, Commande dto)
    {
        var Commande = await _commandeService.GetCommandeByIdAsync(id);
        if (Commande == null)
        {
            return NotFound();
        }
        Commande.DateCommande = dto.DateCommande;
        Commande.QuantiteProduit = dto.QuantiteProduit;
        Commande.ProduitId = dto.ProduitId;

        await _commandeService.UpdateCommandeAsync(Commande);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCommande(Guid id)
    {
        await _commandeService.DeleteCommandeAsync(id);
        return NoContent();
    }
}