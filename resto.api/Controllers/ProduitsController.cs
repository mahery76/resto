using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using resto.application.Contracts;
using resto.domain.Entities;
using resto.application.Dtos.Requests;
using resto.application.Dtos.Responses;

namespace resto.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProduitsController : ControllerBase
{
    private readonly IProduitContract _produitService;
    private readonly IMapper _mapper;
    public ProduitsController(IProduitContract produitService, IMapper mapper)
    {
        _produitService = produitService;
        _mapper = mapper; ;
    }

    [HttpPost]
    public async Task<ActionResult> CreateProduit([FromBody] CreateProduitRequestDto produit)
    {
        var InputProduit = _mapper.Map<Produit>(produit);

        await _produitService.CreateProduitAsync(InputProduit);

        return Ok(new
        {
            Message = "Produit crée avec succès",
            Data = InputProduit
        });
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produit>>> GetAllProduits()
    {
        var AllProduits = await _produitService.GetAllProduitsAsync();
        var resultDto = new List<GetProduitResponseDto>();
        foreach (var produit in AllProduits)
        {
            var outputProduit = _mapper.Map<GetProduitResponseDto>(produit);
            resultDto.Add(outputProduit);
        }
        return Ok(AllProduits);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Produit>> GetProduitById(Guid id)
    {
        var Produit = await _produitService.GetProduitByIdAsync(id);
        if (Produit == null)
        {
            return NotFound();
        }
        var ProduitResponse = _mapper.Map<GetProduitResponseDto>(Produit);
        return Ok(ProduitResponse);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProduit(Guid id, CreateProduitRequestDto produit)
    {
        var Produit = await _produitService.GetProduitByIdAsync(id);
        if (Produit == null)
        {
            return NotFound();
        }

        Produit.Nom = produit.Nom;
        Produit.Prix = produit.Prix;

        var affectedRows = await _produitService.UpdateProduitAsync(Produit);

        if (affectedRows > 0)
        {
            return Ok(new
            {
                Message = "Produit mis à jour avec succès",
                AffectedRows = affectedRows
            });
        }
        else
        {
            return StatusCode(500, "Une erreur s'est produite lors de la mise à jour du produit.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduit(Guid id)
    {
        var affectedRows = await _produitService.DeleteProduitAsync(id);
        return Ok(new
        {
            Message = "Produit mis à jour avec succès",
            AffectedRows = affectedRows
        });
    }
}
