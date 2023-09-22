using FluentValidation;
using MGP.ApiDotNet6.Application.Dtos;

namespace MGP.ApiDotNet6.Application.Validations
{
    public  class PersonValidator :AbstractValidator<PersonDto>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Document)
                .NotEmpty()
                .NotNull()
                .WithMessage("Documento deve ser informado.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser informado.");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .NotNull()
                .WithMessage("Telefone deve ser informado.");
        }
    }
}
