using AutoMapper;
using XPTO.Domain.Entities;
using XPTO.UI.MVC.Models;

namespace XPTO.UI.MVC.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Cliente, ClienteViewModel>().ForPath(x => x.Cnpj, x => x.MapFrom(x => x.Cnpj.Numero)).ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Consulta, ConsultaViewModel>().ReverseMap();
            CreateMap<Operacao, OperacaoViewModel>().ReverseMap();
            CreateMap<PlanoTarifacao, PlanoTarifacaoViewModel>().ReverseMap();
        }
    }
}
