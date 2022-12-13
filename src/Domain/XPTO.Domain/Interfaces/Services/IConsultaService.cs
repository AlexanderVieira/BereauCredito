using XPTO.Domain.Entities;

namespace XPTO.Domain.Interfaces.Services
{
    public interface IConsultaService
    {
        Task Consultar(Consulta consulta);
    }    
}
