using System.Linq.Expressions;
using XPTO.Domain.Entities;
using XPTO.Domain.Entities.Validations;
using XPTO.Domain.Interfaces.Repositories;
using XPTO.Domain.Interfaces.Services;

namespace XPTO.Service
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _repo;
        public ClienteService(IClienteRepository repo, INotificador notificador) : base(notificador)
        {
            _repo = repo;
        }

        public async Task Adicionar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidator(), cliente)) return;

            if (!ExecutarValidacaoTelefone(cliente.Telefones)) return;            

            if (_repo.Buscar(c => c.Cnpj.Numero == cliente.Cnpj.Numero).Result.Any())
            {
                Notificar("Já existe um cliente com este documento informado.");
                return;
            }

            if (AhTelefone(cliente.Telefones)) return;

            await _repo.Adicionar(cliente);
        }

        public async Task Atualizar(Cliente cliente)
        {
            await _repo.Atualizar(cliente);
        }

        public async Task<IEnumerable<Cliente>> Buscar(Expression<Func<Cliente, bool>> predicate)
        {
            return await _repo.Buscar(predicate);
        }

        public void Dispose()
        {
            _repo.Dispose();
        }

        public async Task<Cliente> ObterPorId(Guid id)
        {
            return await _repo.ObterPorId(id);
        }

        public async Task<List<Cliente>> ObterTodos()
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

        private bool AhTelefone(ICollection<Telefone> telefones)
        {
            if (telefones.Any())
            {
                foreach (var telefone in telefones)
                {
                    if (_repo.Buscar(c => c.Telefones.Contains(telefone)).Result.Any())
                    {
                        Notificar("Já existe um número de telefone informado.");
                        return true;
                    }
                }
            }
            return false;
        }

        private bool ExecutarValidacaoTelefone(ICollection<Telefone> telefones)
        {            
            if (telefones.Any())
            {
                foreach (var telefone in telefones)
                {
                    if (ExecutarValidacao(new ClienteTelefoneValidator(), telefone)) return true;                    
                }
            }
            return true;
        }
    }
    
}
