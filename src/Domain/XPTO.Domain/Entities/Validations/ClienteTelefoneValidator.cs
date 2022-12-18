using FluentValidation;
using XPTO.Domain.Enums;

namespace XPTO.Domain.Entities.Validations
{
    public class ClienteTelefoneValidator : AbstractValidator<Telefone>
    {
        public ClienteTelefoneValidator()
        {
            RuleFor(t => t.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("O campo {PropertyName} inválido.");

            RuleFor(t => t.Numero)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} não foi informado.")
                .Matches("[0-9]*")
                .WithMessage("O campo {PropertyName} inválido.");

            RuleFor(t => t.TipoTelefone)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} não foi informado.");

            When(t => t.TipoTelefone == TipoTelefone.Comercial, () =>
            {
                RuleFor(t => t.Numero.Length).Equal(10)
                    .WithMessage("O campo Número precisa ter {ComparisonValue} dígitos e foi fornecido {PropertyValue}.");
            });

            When(t => t.TipoTelefone == TipoTelefone.Celular, () =>
            {
                RuleFor(t => t.Numero.Length).Equal(11)
                    .WithMessage("O campo Número precisa ter {ComparisonValue} dígitos e foi fornecido {PropertyValue}.");

                RuleFor(t => t.Numero.Substring(3)).Equal("9")
                    .WithMessage("O campo {PropertyName} inválido.");
            });

            When(t => t.TipoTelefone == TipoTelefone.Residencial, () =>
            {
                RuleFor(t => t.Numero.Length).Equal(10)
                    .WithMessage("O campo Número precisa ter {ComparisonValue} dígitos e foi fornecido {PropertyValue}.");

                RuleFor(t => t.Numero.Substring(3)).Equal("3")
                    .WithMessage("O campo {PropertyName} inválido.");
            });

        }
    }
}
