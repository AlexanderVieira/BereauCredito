using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Repositories;
using XPTO.Domain.Interfaces.Services;

namespace XPTO.Service
{
    public class FornecedorService : BaseService<Fornecedor>, IFornecedorService
    {
        private readonly IFornecedorRepository _repo;

        public FornecedorService(IFornecedorRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
