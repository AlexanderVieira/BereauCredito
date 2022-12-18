using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace XPTO.UI.MVC.Models.Response
{
    public class ConsultaResponseViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Fornecedor")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid FornecedorId { get; set; }

        [DisplayName("Plano de Tarifação")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid PlanoTarifacaoId { get; set; }

        [DisplayName("Contrato")]
        public Guid? ContratoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(8, ErrorMessage = "O campo {0} precisa ter {2} caracteres")]
        public string Senha { get; set; }
        public FornecedorResponseViewModel Fornecedor { get; set; }
        public PlanoTarifacaoResponseViewModel PlanoTarifacao { get; set; }
        public ContratoResponseViewModel Contrato { get; set; }
        public ICollection<ClienteResponseViewModel> Clientes { get; set; }
    }
}