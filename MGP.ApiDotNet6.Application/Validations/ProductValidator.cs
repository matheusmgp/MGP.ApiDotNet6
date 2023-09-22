using FluentValidation;
using MGP.ApiDotNet6.Application.Dtos;

namespace MGP.ApiDotNet6.Application.Validations
{
    public  class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.CodErp)
               .NotEmpty()
               .NotNull()
               .WithMessage("CodErp deve ser informado.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser informado.");

            RuleFor(x => x.Price)
                .GreaterThan(0)                
                .WithMessage("Preço deve ser informado.");
        }
    }
}
