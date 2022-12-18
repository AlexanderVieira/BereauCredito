using FluentValidation;

namespace XPTO.Domain.Entities.Validations
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(c => c.Id) 
                .NotEqual(Guid.Empty)
                .WithMessage("O campo {PropertyName} inválido.");

            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("O campo {PropertyName} inválido.");

            RuleFor(c => c.Login)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 50)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres")
                .Matches("[A-Z]*")
                .WithMessage("O campo {PropertyName} deve ter apenas caracteres");

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage("Senha é obrigatória.")
                .SetValidator(new SenhaValidator());
        }
    }
}
