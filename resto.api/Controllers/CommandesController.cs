using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using resto.application.Contracts;
using resto.application.Dtos.Responses;
using resto.application.Dtos.Requests;
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
    public async Task<ActionResult<Commande>> CreateCommande([FromBody] CreateCommandeRequestDto commande)
    {
        var produit = await _produitService.GetProduitByIdAsync(commande.ProduitId);
        if (produit == null)
        {
            return BadRequest("Invalid ProduitId.");
        }
        var InputCommande = _mapper.Map<Commande>(commande);
        
        // Assign the retrieved product to the Commande entity
        InputCommande.Produit = produit;
        
        
        // Create the Commande entity using the service
        await _commandeService.CreateCommandeAsync(InputCommande);

        // Map the created Commande entity  to a CreateCommandeResponseDto
        var resultDto = _mapper.Map<CreateCommandeResponseDto>(InputCommande);

        return Ok(resultDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Commande>> GetCommandeById(Guid id)
    {
        var Commande = await _commandeService.GetCommandeByIdAsync(id);
        if (Commande == null)
        {
            return BadRequest("Invalid CommandeID.");
        }

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
    public async Task<ActionResult<IEnumerable<GetAllCommandesResponseDto>>> GetAllCommandes()
    {
        var AllCommandes = await _commandeService.GetAllCommandeAsync();
        var resultDto = new List<GetAllCommandesResponseDto>();
        foreach (var commande in AllCommandes)
        {
            var outputCommande = _mapper.Map<GetAllCommandesResponseDto>(commande);
            var produit = await _produitService.GetProduitByIdAsync(commande.ProduitId);
            if (produit != null)
            {
                outputCommande.Produit = produit;
            }
            resultDto.Add(outputCommande);
        }
        return Ok(resultDto);
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
}