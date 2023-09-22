using FluentValidation;
using MGP.ApiDotNet6.Application.Dtos;

namespace MGP.ApiDotNet6.Application.Validations
{
    public class PurchaseValidator : AbstractValidator<PurchaseDto>
    {
        public PurchaseValidator()
        {
            RuleFor(x => x.ProductId)
              .NotEmpty()
              .NotNull()
              .WithMessage("ProductId deve ser informado.");

            RuleFor(x => x.PersonId)
                .NotEmpty()
                .NotNull()
                .WithMessage("PersonId deve ser informado.");

            RuleFor(x => x.Date)
                .NotEmpty()
                .NotNull()
                .WithMessage("Data deve ser informado.");
        }
    }
}
