using System.Linq.Expressions;
using XPTO.Core.DomainObjects;

namespace XPTO.Core.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> ObterTodos();
        Task<TEntity> ObterPorId(Guid id);        
        Task Adicionar(TEntity entity);
        Task Atualizar(TEntity entity);
        Task Remover(Guid id);        
        Task<int> SaveChanges();
    }
}
