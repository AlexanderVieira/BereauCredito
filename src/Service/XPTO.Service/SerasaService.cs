using XPTO.Crosscutting.Bereaus.Interfaces;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Services;

namespace XPTO.Service
{
    public class SerasaService : IConsultaService
    {
        private readonly ISerasaFacade _serasa;

        public SerasaService(ISerasaFacade serasa)
        {
            _serasa = serasa;
        }

        public async Task Consultar(Consulta consulta)
        {
            await _serasa.ConsultarSerasa(consulta);
        }
    }
}
