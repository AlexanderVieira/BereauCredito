using FluentValidation;
using XPTO.Core.DomainObjects.ValueObjects;

namespace XPTO.Domain.Entities.Validations
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("O campo {PropertyName} inválido.");

            RuleFor(c=> c.Nome)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres")
                .Matches("[A-Z]*")
                .WithMessage("O campo {PropertyName} deve ter apenas caracteres");

            RuleFor(c => c.Cnpj.Numero.Length)
                .Equal(Cnpj.CNPJ_MAX_LENGTH)
                .WithMessage("O campo CNPJ precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            
            RuleFor(c => Cnpj.Validar(c.Cnpj.Numero))
                .Equal(true)
                .WithMessage("O documento fornecido é inválido.");
            
        }
    }
}
