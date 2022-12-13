using XPTO.Crosscutting.Bereaus.Interfaces;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Services;

namespace XPTO.Service
{
    public class SpcService : IConsultaService
    {
        private readonly ISpcFacade _spc;

        public SpcService(ISpcFacade spc)
        {
            _spc = spc;
        }

        public async Task Consultar(Consulta consulta)
        {
            await _spc.ConsultarSpc(consulta);
        }
    }
}
