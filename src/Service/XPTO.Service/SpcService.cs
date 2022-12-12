using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Services;

namespace XPTO.Service
{
    public class SpcService : IConsultaService
    {
        private readonly ISpcService _spc;

        public SpcService(ISpcService spc)
        {
            _spc = spc;
        }

        public async Task Consultar(Consulta consulta)
        {
            await _spc.ConsultarSpc(consulta);
        }
    }
}
