using FluentValidation;
using XPTO.Core.DomainObjects.ValueObjects;

namespace XPTO.Domain.Entities.Validations
{
    public class SenhaValidator : AbstractValidator<Senha>
    {   
        public SenhaValidator()
        {
            RuleFor(x => x.Valor)
                .NotEmpty()
                .WithMessage("Senha é obrigatória.")
                .Length(8, 12)
                .WithMessage("O campo {PropertyName} precisa ter no mínimo {MinLength} caracteres, uma letra, um caracter especial e um número")
                .Must(Senha.Validar)
                .WithMessage("Login ou senha inválido");                
        }

    }
}
