using XPTO.Core.DomainObjects;
using XPTO.Core.DomainObjects.ValueObjects;

namespace XPTO.Domain.Entities
{
    public class Usuario : Entity
    {
        public Guid ClienteId { get; set; }
        public string Login { get; set; }
        public Senha Senha { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<Operacao> Operacoes { get; set; }

        public Usuario()
        {
            Operacoes = new HashSet<Operacao>();
        }
    }
    
}
