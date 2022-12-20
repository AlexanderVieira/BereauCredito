using XPTO.Data.Context;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Repositories;

namespace XPTO.Data.Repositories
{
    public class ContratoRepository : Repository<Contrato>, IContratoRepository
    {
        public ContratoRepository(AppDbContext ctx) : base(ctx)
        {
        }
    }
}
