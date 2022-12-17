using System.Linq.Expressions;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Repositories;
using XPTO.Domain.Interfaces.Services;

namespace XPTO.Service
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioService(IUsuarioRepository repo, INotificador notificador) : base(notificador)
        {
            _repo = repo;
        }

        public async Task Adicionar(Usuario usuario)
        {
            await _repo.Adicionar(usuario);
        }

        public async Task Atualizar(Usuario usuario)
        {
            await _repo.Atualizar(usuario);
        }

        public async Task<IEnumerable<Usuario>> Buscar(Expression<Func<Usuario, bool>> predicate)
        {
            return await _repo.Buscar(predicate);
        }

        public void Dispose()
        {
            _repo.Dispose();
        }

        public async Task<Usuario> ObterPorId(Guid id)
        {
            return await _repo.ObterPorId(id);
        }

        public async Task<List<Usuario>> ObterTodos()
        {
            return await _repo.ObterTodos();
        }

        public async Task Remover(Guid id)
        {
            await _repo.Remover(id);
        }

        public async Task<int> SaveChanges()
        {
            return await _repo.SaveChanges();
        }
    }
}
