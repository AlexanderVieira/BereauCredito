using XPTO.Crosscutting.Bereaus.Interfaces;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Services;

namespace XPTO.Service
{
    public class ReceitaFederalService : IConsultaService
    {
        private readonly IReceitaFederalFacade _rf;

        public ReceitaFederalService(IReceitaFederalFacade rf)
        {
            _rf = rf;
        }

        public async Task Consultar(Consulta consulta)
        {
            await _rf.ConsultarReceitaFederal(consulta);
        }
    }
}
