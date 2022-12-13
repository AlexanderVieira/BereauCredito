using Microsoft.EntityFrameworkCore;
using XPTO.Data.Context;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Repositories;

namespace XPTO.Data.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext ctx) : base(ctx)
        {
        }
    }
}
