using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace XPTO.UI.MVC.Models.Response
{
    public class ClienteResponseViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter {1} caracteres")]
        [DisplayName("CNPJ")]
        public string Cnpj { get; set; }
        public ICollection<TelefoneResponseViewModel> Telefones { get; set; }
        public ICollection<UsuarioResponseViewModel> Usuarios { get; set; }
        public ICollection<ConsultaResponseViewModel> Consultas { get; set; }
    }
}
