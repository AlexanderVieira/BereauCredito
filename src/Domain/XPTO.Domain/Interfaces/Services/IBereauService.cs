using XPTO.Domain.Entities;

namespace XPTO.Domain.Interfaces.Services
{
    public interface IBereauService
    {
        Task Consultar(Consulta consulta);
    }
}
