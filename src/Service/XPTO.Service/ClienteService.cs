using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Repositories;
using XPTO.Domain.Interfaces.Services;

namespace XPTO.Service
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        private readonly IClienteRepository _repo;
        public ClienteService(IClienteRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
