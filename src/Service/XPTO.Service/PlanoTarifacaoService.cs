using System.Linq.Expressions;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Repositories;
using XPTO.Domain.Interfaces.Services;
using XPTO.Domain.Service.Notification;
using XPTO.Service;

namespace XPTO.Domain.Service
{
    public class PlanoTarifacaoService : BaseService, IPlanoTarifacaoService
    {
        private readonly IPlanoTarifacaoRepository _repo;

        public PlanoTarifacaoService(IPlanoTarifacaoRepository repo, INotificador notificador) : base(notificador)
        {
            _repo = repo;
        }

        public async Task Adicionar(PlanoTarifacao plano)
        {
            await _repo.Adicionar(plano);   
        }

        public async Task Atualizar(PlanoTarifacao plano)
        {
            await _repo.Atualizar(plano);
        }

        public async Task<IEnumerable<PlanoTarifacao>> Buscar(Expression<Func<PlanoTarifacao, bool>> predicate)
        {
            return await _repo.Buscar(predicate);
        }

        public void Dispose()
        {
            _repo.Dispose();
        }

        public async Task<PlanoTarifacao> ObterPorId(Guid id)
        {
            return await _repo.ObterPorId(id);
        }

        public async Task<List<PlanoTarifacao>> ObterTodos()
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
