using XPTO.Data.Context;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Repositories;

namespace XPTO.Data.Repositories
{
    public class PlanoTarifacaoRepository : Repository<PlanoTarifacao>, IPlanoTarifacaoRepository
    {
        public PlanoTarifacaoRepository(AppDbContext ctx) : base(ctx)
        {
        }
    }
}
