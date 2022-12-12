using XPTO.Core.DomainObjects;

namespace XPTO.Domain.Entities
{
    public class Fornecedor : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public ICollection<Consulta> Consultas { get; set; }

        public Fornecedor()
        {
            Consultas = new HashSet<Consulta>();
        }
    }
}
