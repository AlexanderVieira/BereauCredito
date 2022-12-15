using XPTO.Core.DomainObjects;
using XPTO.Core.DomainObjects.ValueObjects;

namespace XPTO.Domain.Entities
{
    public class Consulta : Entity
    {
        public Guid FornecedorId { get; set; }
        public Guid PlanoTarifacaoId { get; set; }
        public string Login { get; set; }
        public Senha Senha { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public PlanoTarifacao PlanoTarifacao { get; set; }        
        public ICollection<Cliente> Clientes { get; set; }

        public Consulta()
        {
            Clientes = new HashSet<Cliente>();
        }
    }
    
}
