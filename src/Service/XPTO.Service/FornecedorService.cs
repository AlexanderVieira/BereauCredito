using System.Linq.Expressions;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Services;

namespace XPTO.Service
{
    public class FornecedorService : BaseService, IFornecedorService

    {
        public Task Adicionar(Fornecedor entity)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Fornecedor entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Fornecedor>> Buscar(Expression<Func<Fornecedor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Fornecedor> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Fornecedor>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
