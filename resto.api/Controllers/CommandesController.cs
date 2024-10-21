using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using resto.application.Contracts;
using resto.application.Dtos;
using resto.domain.Entities;

namespace resto.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommandesController : ControllerBase
{
    private readonly ICommandeContract _commandeService;
    private readonly IProduitContract _produitService;
    private readonly IMapper _mapper;

    public CommandesController(ICommandeContract commandeService, IProduitContract produitService, IMapper mapper)
    {
        _commandeService = commandeService;
        _produitService = produitService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<Commande>> CreateCommande(Commande dto)
    {
        var produit = await _produitService.GetProduitByIdAsync(dto.ProduitId);
        if (produit == null)
        {
            return BadRequest("Invalid ProduitId.");
        }

        var commande = _mapper.Map<Commande>(dto);
        commande.Produit = produit;
        commande.DateCommande = commande.DateCommande.ToUniversalTime(); // Ensure DateCommande is in UTC
        await _commandeService.CreateCommandeAsync(commande);

        var resultDto = _mapper.Map<CreateCommandeDto>(commande);
        resultDto.Produit = produit;

        return CreatedAtAction(nameof(GetCommandeById), new { id = commande.Id }, resultDto);
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
            // return produit object here
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