using FluentValidation;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using resto.domain.Entities;

namespace resto.application.Validators;

public class ProduitValidator : AbstractValidator<Produit>
{
    public ProduitValidator()
    {
        RuleFor(p => p.Nom).NotEmpty().WithMessage("Name is required");
        RuleFor(p => p.Prix).GreaterThan(0).WithMessage("Price must be greater than zero");
    }
}
