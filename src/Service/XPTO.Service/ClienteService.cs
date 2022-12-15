using XPTO.Core.Data;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Services;

namespace XPTO.Service
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        public ClienteService(IRepository<Cliente> repo) : base(repo)
        {
        }
    }
}
