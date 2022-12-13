using XPTO.Domain.Entities;

namespace XPTO.Crosscutting.Bereaus.Interfaces
{
    public interface ISpcFacade
    {
        Task ConsultarSpc(Consulta consulta);
    }
}
