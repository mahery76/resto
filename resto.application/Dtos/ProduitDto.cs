namespace resto.application.Dtos;

public record ProduitDto(
     Guid Id,
     string Nom_Produit,
     decimal Prix_produit
);
