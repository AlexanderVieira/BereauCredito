using System.Linq.Expressions;
using XPTO.Core;
using XPTO.Core.Data;
using XPTO.Core.DomainObjects;

namespace XPTO.Service
{
    public abstract class BaseService<TEntity> : IService<TEntity> where TEntity : Entity, new()
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
            _repo.Dispose();
        }

        Task<TEntity> IService<TEntity>.ObterPorId(Guid id) => _repo.ObterPorId(id);//fiz com arrow por que inexplicavelmente estava dando erro.

        async Task<List<TEntity>> IService<TEntity>.ObterTodos() => await _repo.ObterTodos(); //mesma coisa.

        public async Task Remover(Guid id)
        {
            await _repo.Remover(id);
        }

        Task<int> IService<TEntity>.SaveChanges() => _repo.SaveChanges();//aqui também.
    }
}
