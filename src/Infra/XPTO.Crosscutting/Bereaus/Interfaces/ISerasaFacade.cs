using XPTO.Domain.Entities;

namespace XPTO.Crosscutting.Bereaus.Interfaces
{
    public interface ISerasaFacade
    {
        Task ConsultarSerasa(Consulta consulta);
    }
}
