using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace XPTO.UI.MVC.Models.Request
{
    public class ContratoRequestViewModel
    {
        [DisplayName("Data da Vigência")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataVigencia { get; set; }

        //[Moeda]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }
        public ConsultaRequestViewModel Consulta { get; set; }
    }
}