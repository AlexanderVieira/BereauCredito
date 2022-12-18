using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace XPTO.UI.MVC.Models.Request
{
    public class ClienteRequestViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter {1} caracteres")]
        [DisplayName("CNPJ")]
        public string Cnpj { get; set; }
        public ICollection<TelefoneRequestViewModel> Telefones { get; set; }
        public ICollection<UsuarioRequestViewModel> Usuarios { get; set; }
        public ICollection<ConsultaRequestViewModel> Consultas { get; set; }

        public ClienteRequestViewModel()
        {
            Telefones = new List<TelefoneRequestViewModel>();
            Usuarios = new List<UsuarioRequestViewModel>();
            Consultas = new List<ConsultaRequestViewModel>();
        }
    }
}
