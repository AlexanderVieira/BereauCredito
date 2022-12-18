using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace XPTO.UI.MVC.Models.Request
{
    public class OperacaoRequestViewModel
    {
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataOperacao { get; set; }
        public ICollection<UsuarioRequestViewModel> Usuarios { get; set; }
    }
}