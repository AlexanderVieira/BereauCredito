using XPTO.Crosscutting.Bereaus.Interfaces;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Services;
using XPTO.Domain.Service.Notification;

namespace XPTO.Service
{
    public class SpcService : BaseService, IBereauService
    {
        private readonly ISpcFacade _spc;       

        public SpcService(ISpcFacade spc, INotificador notificador) : base(notificador)
        {            
            _spc = spc;            
        }
        public async Task Consultar(Consulta consulta)
        {
            await _spc.ConsultarSpc(consulta);
        }
    }
}
