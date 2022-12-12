using System.Linq.Expressions;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Services;

namespace XPTO.Service
{
    public class ClienteService : BaseService, IClienteService
    {        

        public Task<IEnumerable<Cliente>> Buscar(Expression<Func<Cliente, bool>> predicate)
        {
            throw new NotImplementedException();
        }        

        public Task<Cliente> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cliente>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task Adicionar(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Cliente entity)
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
