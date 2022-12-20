using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using XPTO.Crosscutting.Bereaus;
using XPTO.Domain.Entities;
using XPTO.Domain.Service.Notification;
using XPTO.Service;

namespace XPTO.UI.MVC.Controllers
{
    public class BereausController : BaseController
    {
        //private IBereauService _bereauService;
        private readonly IMapper _mapper;

        public BereausController(IMapper mapper, INotificador notificador) : base(notificador)
        {
            //_bereauService = bereauService;
            _mapper = mapper;
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> ConsultarSpc()
        {
            if(!ModelState.IsValid) return View();

            var consulta = new Consulta(); //_mapper.Map<Consulta>(vmConsulta);
            var _bereauService = new SpcService(new SpcFacade(), new Notificador());
            await _bereauService.Consultar(consulta);
            
            return View();
        }

        public async Task<IActionResult> ConsultarSerasa()
        {
            if (!ModelState.IsValid) return View();

            var consulta = new Consulta(); //_mapper.Map<Consulta>(vmConsulta);
            var _bereauService = new SerasaService(new SerasaFacade(), new Notificador());
            await _bereauService.Consultar(consulta);

            return View();
        }

        public async Task<IActionResult> ConsultarReceitaFederal()
        {
            if (!ModelState.IsValid) return View();

            var consulta = new Consulta(); //_mapper.Map<Consulta>(vmConsulta);
            var _bereauService = new ReceitaFederalService(new ReceitaFederalFacade(), new Notificador());
            await _bereauService.Consultar(consulta);

            return View();
        }
    }
}
