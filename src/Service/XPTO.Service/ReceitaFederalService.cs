using XPTO.Crosscutting.Bereaus.Interfaces;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Services;
using XPTO.Domain.Service.Notification;

namespace XPTO.Service
{
    public class ReceitaFederalService : BaseService, IBereauService
    {
        private readonly IReceitaFederalFacade _rf;

        public ReceitaFederalService(IReceitaFederalFacade rf, INotificador notificador)  : base(notificador)
        {
            _rf = rf;
        }

        public async Task Consultar(Consulta consulta)
        {
            await _rf.ConsultarReceitaFederal(consulta);
        }
    }
}
