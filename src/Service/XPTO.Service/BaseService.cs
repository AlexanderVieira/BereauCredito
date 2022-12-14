using FluentValidation;
using FluentValidation.Results;
using XPTO.Core.DomainObjects;
using XPTO.Domain.Service.Notification;

namespace XPTO.Service
{
    public class BaseService
    {        
        private readonly INotificador _notificador;

        public BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }        

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {   
            var validator = validacao.Validate(entidade);            
            if (validator.IsValid) return true;
            Notificar(validator);
            return false;
        }        
    }
}
