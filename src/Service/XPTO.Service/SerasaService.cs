using XPTO.Crosscutting.Bereaus.Interfaces;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Services;
using XPTO.Domain.Service.Notification;

namespace XPTO.Service
{
    public class SerasaService : BaseService, IBereauService
    {
        private readonly ISerasaFacade _serasa;

        public SerasaService(ISerasaFacade serasa, INotificador notificador) : base(notificador)
        {
            _serasa = serasa;
        }                     

        public async Task Consultar(Consulta consulta)
        {
            await _serasa.ConsultarSerasa(consulta);
        }
    }
}
