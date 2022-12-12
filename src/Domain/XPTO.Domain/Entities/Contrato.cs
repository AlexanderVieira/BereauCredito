using XPTO.Core.DomainObjects;

namespace XPTO.Domain.Entities
{
    public class Contrato : Entity
    {
        public DateTime DataVigencia { get; set; }
        public decimal Valor  { get; set; }
    }
}
