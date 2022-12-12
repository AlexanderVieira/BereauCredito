using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Services;

namespace XPTO.Service
{
    public class SerasaService : IConsultaService
    {
        private readonly ISerasaService _serasa;

        public SerasaService(ISerasaService serasa)
        {
            _serasa = serasa;
        }

        public async Task Consultar(Consulta consulta)
        {
            await _serasa.ConsultarSerasa(consulta);
        }
    }
}
