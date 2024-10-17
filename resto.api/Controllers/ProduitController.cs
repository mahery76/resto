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
        var produit = await _produitService.GetProduitByIdAsync(id);
        return Ok(new Produit
        {
            Id = produit.Id,
            Nom = produit.Nom,
            Prix = produit.Prix
        });
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produit>>> GetAllProduits()
    {
        var produits = await _produitService.GetAllProduitsAsync();
        return Ok(produits.Select(p => new Produit
        {
            Id = p.Id,
            Nom = p.Nom,
            Prix = p.Prix
        }));
    }

    [HttpPost]
    [Route("/add_produit")]
    public async Task<ActionResult<Produit>> CreateProduit(Produit dto)
    {
        var produit = new Produit
        {
            Nom = dto.Nom,
            Prix = dto.Prix
        };

        await _produitService.CreateProduitAsync(produit);

        return CreatedAtAction(nameof(GetProduitById), new { id = produit.Id }, new Produit
        {
            Id = produit.Id,
            Nom = produit.Nom,
            Prix = produit.Prix
        });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProduit(Guid id, Produit dto)
    {
        var produit = await _produitService.GetProduitByIdAsync(id);
        if (produit == null)
        {
            return NotFound();
        }

        produit.Nom = dto.Nom;
        produit.Prix = dto.Prix;

        await _produitService.UpdateProduitAsync(produit);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduit(Guid id)
    {
        await _produitService.DeleteProduitAsync(id);
        return NoContent();
    }
}
