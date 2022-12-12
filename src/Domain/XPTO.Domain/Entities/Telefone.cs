using XPTO.Core.DomainObjects;

namespace XPTO.Domain.Entities
{
    public class Telefone : Entity
    {
        public Guid ClienteId { get; set; }
        public string Numero { get; set; }
        public Cliente Cliente { get; set; }
    }
}
