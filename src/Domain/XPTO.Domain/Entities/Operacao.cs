using XPTO.Core.DomainObjects;

namespace XPTO.Domain.Entities
{
    public class Operacao : Entity
    {
        public string Descricao { get; set; }
        public DateTime DataOperacao { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }

        public Operacao()
        {
            Usuarios = new HashSet<Usuario>();
        }
    }
}
