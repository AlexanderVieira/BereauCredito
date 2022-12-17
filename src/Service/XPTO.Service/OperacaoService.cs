using System.Linq.Expressions;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Repositories;
using XPTO.Domain.Interfaces.Services;

namespace XPTO.Service
{
    public class OperacaoService : BaseService, IOperacaoService
    {
        private readonly IOperacaoRepository _repo;

        public OperacaoService(IOperacaoRepository repo, INotificador notificador) : base(notificador)
        {
            _repo = repo;
        }

        public async Task Adicionar(Operacao operacao)
        {
            await _repo.Adicionar(operacao);
        }

        public async Task Atualizar(Operacao operacao)
        {
            await _repo.Atualizar(operacao);
        }

        public async Task<IEnumerable<Operacao>> Buscar(Expression<Func<Operacao, bool>> predicate)
        {
            return await _repo.Buscar(predicate);
        }

        public void Dispose()
        {
            _repo.Dispose();
        }

        public async Task<Operacao> ObterPorId(Guid id)
        {
            return await _repo.ObterPorId(id);
        }

        public async Task<List<Operacao>> ObterTodos()
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
