using System.Linq.Expressions;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Services;

namespace XPTO.Service
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        public Task Adicionar(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> Buscar(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Usuario>> ObterTodos()
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
