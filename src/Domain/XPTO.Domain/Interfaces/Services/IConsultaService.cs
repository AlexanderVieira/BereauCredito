using XPTO.Domain.Entities;

namespace XPTO.Domain.Interfaces.Services
{
    public interface IConsultaService
    {
        Task Consultar(Consulta consulta);
    }

    public interface ISpcService
    {
        Task ConsultarSpc(Consulta consulta);
    }

    public interface ISerasaService
    {
        Task ConsultarSerasa(Consulta consulta);
    }

    public interface IReceitaFederalService
    {
        Task ConsultarReceitaFederal(Consulta consulta);
    }
    
}
