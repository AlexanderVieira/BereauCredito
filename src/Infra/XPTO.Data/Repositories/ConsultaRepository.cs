using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using XPTO.Data.Context;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Repositories;

namespace XPTO.Data.Repositories
{
    public class ConsultaRepository : Repository<Consulta>, IConsultaRepository
    {        
        public ConsultaRepository(AppDbContext ctx) : base(ctx)
        {            
        }

        public async Task<Consulta> BuscarConsultaDetalhada(Expression<Func<Consulta, bool>> predicate)
        {
            return await Context.Consultas
                .Include(c => c.Contrato)
                .Include(c => c.Fornecedor)
                .Include(c => c.PlanoTarifacao).FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Consulta>> BuscarConsultasDetalhadas()
        {
            return await Context.Consultas
                .Include(c => c.Contrato)
                .Include(c => c.Fornecedor)
                .Include(c => c.PlanoTarifacao).ToListAsync();
        }
    }
}
