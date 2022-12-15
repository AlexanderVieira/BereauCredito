using System.Linq.Expressions;
using XPTO.Core;
using XPTO.Core.Data;
using XPTO.Core.DomainObjects;

namespace XPTO.Service
{
    public class BaseService<TEntity> : IService<TEntity> where TEntity : Entity, new()
    {
        private readonly IRepository<TEntity> _repo;

        protected BaseService(IRepository<TEntity> repo)
        {
            _repo = repo;
        }

        public async Task Adicionar(TEntity entity)
        {
            await _repo.Adicionar(entity);
        }

        public async Task Atualizar(TEntity entity)
        {
            await _repo.Atualizar(entity);
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repo.Buscar(predicate);
        }

        public void Dispose()
        {
            _repo?.Dispose();
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await _repo.ObterPorId(id);
        }

        public async Task<List<TEntity>> ObterTodos()
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
