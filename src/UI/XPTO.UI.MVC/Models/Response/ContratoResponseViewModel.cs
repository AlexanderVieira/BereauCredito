using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace XPTO.UI.MVC.Models.Response
{
    public class ContratoResponseViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Consulta")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ConsultaId { get; set; }

        [DisplayName("Data da Vigência")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataVigencia { get; set; }

        //[Moeda]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }
        public ConsultaResponseViewModel Consulta { get; set; }
    }
}