using XPTO.Data.Context;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Repositories;

namespace XPTO.Data.Repositories
{
    public class OperacaoRepository : Repository<Operacao>, IOperacaoRepository
    {
        public OperacaoRepository(AppDbContext ctx) : base(ctx)
        {
        }
    }
}
