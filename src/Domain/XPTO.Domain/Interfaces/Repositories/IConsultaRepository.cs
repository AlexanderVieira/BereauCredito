using System.Linq.Expressions;
using XPTO.Core.Data;
using XPTO.Domain.Entities;

namespace XPTO.Domain.Interfaces.Repositories
{
    public interface IConsultaRepository : IRepository<Consulta>
    {
        Task<IEnumerable<Consulta>> BuscarConsultasDetalhadas();
        Task<Consulta> BuscarConsultaDetalhada(Expression<Func<Consulta, bool>> predicate);
    }
}
