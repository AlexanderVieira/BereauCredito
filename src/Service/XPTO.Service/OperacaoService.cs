using System.Linq.Expressions;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Services;

namespace XPTO.Service
{
    public class OperacaoService : BaseService, IOperacaoService
    {
        public Task Adicionar(Operacao entity)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Operacao entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Operacao>> Buscar(Expression<Func<Operacao, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Operacao> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Operacao>> ObterTodos()
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
