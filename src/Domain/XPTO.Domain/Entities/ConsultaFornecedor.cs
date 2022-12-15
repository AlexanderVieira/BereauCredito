using XPTO.Core.DomainObjects;

namespace XPTO.Domain.Entities
{
    public class ConsultaFornecedor : Entity
    {
        public Guid ContratoId { get; set; }        
        public Guid ConsultaId { get; set; }
        public Guid FornecedorId { get; set; }
        public Contrato Contrato { get; set; }
        public Consulta Consulta { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
