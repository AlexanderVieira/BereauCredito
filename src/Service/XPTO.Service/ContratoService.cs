using System.Linq.Expressions;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Repositories;
using XPTO.Domain.Interfaces.Services;
using XPTO.Domain.Service.Notification;
using XPTO.Service;

namespace XPTO.Domain.Service
{
    public class ContratoService : BaseService, IContratoService
    {
        private readonly IContratoRepository _repo;

        public ContratoService(IContratoRepository repo, INotificador notificador) : base(notificador)
        {
            _repo = repo;
        }

        public async Task Adicionar(Contrato contrato)
        {
            await _repo.Adicionar(contrato);
        }

        public async Task Atualizar(Contrato contrato)
        {
            await _repo.Atualizar(contrato);
        }

        public async Task<IEnumerable<Contrato>> Buscar(Expression<Func<Contrato, bool>> predicate)
        {
            return await _repo.Buscar(predicate);
        }

        public void Dispose()
        {
            _repo.Dispose();
        }

        public async Task<Contrato> ObterPorId(Guid id)
        {
            return await _repo.ObterPorId(id);
        }

        public async Task<List<Contrato>> ObterTodos()
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
