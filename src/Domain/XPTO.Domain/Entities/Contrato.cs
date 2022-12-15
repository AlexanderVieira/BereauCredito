using XPTO.Core.DomainObjects;

namespace XPTO.Domain.Entities
{
    public class Contrato : Entity
    {
        public Guid ConsultaId { get; set; }
        public DateTime DataVigencia { get; set; }
        public decimal Valor  { get; set; }
        public Consulta Consulta { get; set; }
    }
}
