using XPTO.Core.DomainObjects;
using XPTO.Core.DomainObjects.ValueObjects;

namespace XPTO.Domain.Entities
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public Cnpj Cnpj { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
        public ICollection<Consulta> Consultas { get; set; }

        public Cliente()
        {
            Telefones = new HashSet<Telefone>();
            Usuarios = new HashSet<Usuario>();
            Consultas = new HashSet<Consulta>();
        }
    }
    
}
