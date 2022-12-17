using FluentValidation;

namespace XPTO.Domain.Entities.Validations
{
    public class FornecedorValidator : AbstractValidator<Fornecedor>
    {
        public FornecedorValidator()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("O campo {PropertyName} inválido.");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres")
                .Matches("[A-Z]*")
                .WithMessage("O campo {PropertyName} deve ter apenas caracteres");

            RuleFor(c => c.Descricao)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres")
                .Matches("[A-Z]*")
                .WithMessage("O campo {PropertyName} deve ter apenas caracteres");
        }
    }
}
