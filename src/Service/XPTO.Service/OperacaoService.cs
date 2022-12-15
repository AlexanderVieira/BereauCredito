using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Repositories;
using XPTO.Domain.Interfaces.Services;

namespace XPTO.Service
{
    public class OperacaoService : BaseService<Operacao>, IOperacaoService
    {
        private readonly IOperacaoRepository _repo;

        public OperacaoService(IOperacaoRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
