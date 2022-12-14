using XPTO.Data.Context;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Repositories;

namespace XPTO.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext ctx) : base(ctx)
        {
        }
    }
}
