using XPTO.Data.Context;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Repositories;

namespace XPTO.Data.Repositories
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(AppDbContext ctx) : base(ctx)
        {
        }
    }
}
