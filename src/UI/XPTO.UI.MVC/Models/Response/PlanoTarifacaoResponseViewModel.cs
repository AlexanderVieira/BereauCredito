using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace XPTO.UI.MVC.Models.Response
{
    public class PlanoTarifacaoResponseViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Data da Vigência")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataVigencia { get; set; }

        //[Moeda]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }
        public ICollection<ConsultaResponseViewModel> Consultas { get; set; }
    }
}