using System.Linq.Expressions;
using XPTO.Core;
using XPTO.Domain.Entities;

namespace XPTO.Domain.Interfaces.Services
{
    public interface IConsultaService : IService<Consulta>
    {
        //Task Consultar(Consulta consulta);
        Task<IEnumerable<Consulta>> BuscarConsultasDetalhadas();
        Task<Consulta> BuscarConsultaDetalhada(Expression<Func<Consulta, bool>> predicate);
    }    
}
