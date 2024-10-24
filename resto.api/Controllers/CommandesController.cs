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
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetCommandeResponseDto>>> GetAllCommandes()
    {
        var AllCommandes = await _commandeService.GetAllCommandeAsync();
        var resultDto = new List<GetCommandeResponseDto>();
        foreach (var commande in AllCommandes)
        {
            var outputCommande = _mapper.Map<GetCommandeResponseDto>(commande);
            var produit = await _produitService.GetProduitByIdAsync(commande.ProduitId);
            if (produit != null)
            {
                outputCommande.Produit = produit;
            }
            resultDto.Add(outputCommande);
        }
        return Ok(resultDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetCommandeResponseDto>> GetCommandeById(Guid id)
    {
        var Commande = await _commandeService.GetCommandeByIdAsync(id);
        if (Commande == null)
        {
            return BadRequest("Invalid CommandeID.");
        }
        var outputCommande = _mapper.Map<GetCommandeResponseDto>(Commande);
        var produit = await _produitService.GetProduitByIdAsync(Commande.ProduitId);
        if (produit != null)
        {
            outputCommande.Produit = produit;
        }
        return Ok(outputCommande);
    }


}