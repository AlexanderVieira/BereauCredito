using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Services;

namespace XPTO.Service
{
    public class ReceitaFederalService : IConsultaService
    {
        private readonly IReceitaFederalService _rf;

        public ReceitaFederalService(IReceitaFederalService rf)
        {
            _rf = rf;
        }

        public async Task Consultar(Consulta consulta)
        {
            await _rf.ConsultarReceitaFederal(consulta);
        }
    }
}
