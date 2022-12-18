using XPTO.Core.DomainObjects;
using XPTO.Domain.Enums;

namespace XPTO.Domain.Entities
{
    public class Telefone : Entity
    {
        public Guid ClienteId { get; set; }
        public string Numero { get; set; }
        public TipoTelefone TipoTelefone { get; set; } 
        
    }
}
