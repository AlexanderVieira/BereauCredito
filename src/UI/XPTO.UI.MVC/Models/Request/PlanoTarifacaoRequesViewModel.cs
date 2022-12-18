using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace XPTO.UI.MVC.Models.Request
{
    public class PlanoTarifacaoRequesViewModel
    {
        [DisplayName("Data da Vigência")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataVigencia { get; set; }

        //[Moeda]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }
        public ICollection<ConsultaRequestViewModel> Consultas { get; set; }
    }
}