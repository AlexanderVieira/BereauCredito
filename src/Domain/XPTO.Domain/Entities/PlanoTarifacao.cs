using XPTO.Core.DomainObjects;

namespace XPTO.Domain.Entities
{
    public class PlanoTarifacao : Entity
    {
        public DateTime DataVigencia { get; set; }
        public decimal Valor { get; set; }
        public ICollection<Consulta> Consultas { get; set; }

        public PlanoTarifacao()
        {
            Consultas = new HashSet<Consulta>();
        }
    }
}
