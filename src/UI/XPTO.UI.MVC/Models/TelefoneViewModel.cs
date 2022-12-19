using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace XPTO.UI.MVC.Models
{
    public class TelefoneViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Cliente")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ClienteId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(11, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        [DisplayName("Telefone")]
        public string Numero { get; set; }

        [DisplayName("Tipo")]
        public int TipoTelefone { get; set; }
    }
}