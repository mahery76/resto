using Microsoft.AspNetCore.Mvc;
using resto.application.Contracts;
using resto.domain.Entities;

namespace resto.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProduitsController : ControllerBase
{
    private readonly IProductContract _produitService;

    public ProduitsController(IProductContract produitService)
    {
        _produitService = produitService;

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Produit>> GetProduitById(Guid id)
    {
        var Produit = await _produitService.GetProduitByIdAsync(id);
        return Ok(new Produit
        {
            Id = Produit.Id,
            Nom = Produit.Nom,
            Prix = Produit.Prix
        });
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produit>>> GetAllProduits()
    {
        var AllProduits = await _produitService.GetAllProduitsAsync();
        return Ok(AllProduits.Select(CurrentProduit => new Produit
        {
            Id = CurrentProduit.Id,
            Nom = CurrentProduit.Nom,
            Prix = CurrentProduit.Prix
        }));
    }

    [HttpPost]
    public async Task<ActionResult<Produit>> CreateProduit(Produit dto)
    {
        var Produit = new Produit
        {
            Nom = dto.Nom,
            Prix = dto.Prix
        };

        await _produitService.CreateProduitAsync(Produit);

        return CreatedAtAction(nameof(GetProduitById), new { id = Produit.Id }, new Produit
        {
            Id = Produit.Id,
            Nom = Produit.Nom,
            Prix = Produit.Prix
        });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProduit(Guid id, Produit dto)
    {
        var Produit = await _produitService.GetProduitByIdAsync(id);
        if (Produit == null)
        {
            return NotFound();
        }

        Produit.Nom = dto.Nom;
        Produit.Prix = dto.Prix;

        await _produitService.UpdateProduitAsync(Produit);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduit(Guid id)
    {
        await _produitService.DeleteProduitAsync(id);
        return NoContent();
    }
}
