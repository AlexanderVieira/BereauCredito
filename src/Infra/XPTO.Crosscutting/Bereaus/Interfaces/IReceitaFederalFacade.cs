using XPTO.Domain.Entities;

namespace XPTO.Crosscutting.Bereaus.Interfaces
{
    public interface IReceitaFederalFacade
    {
        Task ConsultarReceitaFederal(Consulta consulta);
    }
}
