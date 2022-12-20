using System.Linq.Expressions;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Repositories;
using XPTO.Domain.Interfaces.Services;
using XPTO.Domain.Service.Notification;
using XPTO.Service;

namespace XPTO.Domain.Service
{
    public class ConsultaService : BaseService, IConsultaService
    {
        private readonly IConsultaRepository _repo;

        public ConsultaService(IConsultaRepository repo, INotificador notificador) : base(notificador)
        {
            _repo = repo;
        }

        public async Task Adicionar(Consulta consulta)
        {
            await _repo.Adicionar(consulta);
        }

        public async Task Atualizar(Consulta consulta)
        {
            await _repo.Atualizar(consulta);
        }

        public async Task<IEnumerable<Consulta>> Buscar(Expression<Func<Consulta, bool>> predicate)
        {
            return await _repo.Buscar(predicate);
        }

        public async Task<Consulta> BuscarConsultaDetalhada(Expression<Func<Consulta, bool>> predicate)
        {            
            return await _repo.BuscarConsultaDetalhada(predicate);
        }
        
        public async Task<IEnumerable<Consulta>> BuscarConsultasDetalhadas()
        {
            return await _repo.BuscarConsultasDetalhadas();
        }

        public void Dispose()
        {
            _repo.Dispose();
        }

        public async Task<Consulta> ObterPorId(Guid id)
        {
            return await _repo.ObterPorId(id);
        }

        public async Task<List<Consulta>> ObterTodos()
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
