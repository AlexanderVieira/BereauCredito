using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Services;
using XPTO.Domain.Service.Notification;
using XPTO.UI.MVC.Models;

namespace XPTO.UI.MVC.Controllers
{
    public class ConsultasController : BaseController
    {        
        private readonly IConsultaService _consultaService;
        private readonly IFornecedorService _fornecedorService;
        private readonly IPlanoTarifacaoService _planoTarifacaoService;
        private readonly IContratoService _contratoService;
        private readonly IMapper _mapper;

        public ConsultasController(IConsultaService service, 
                                   IFornecedorService fornecedorService, 
                                   IPlanoTarifacaoService planoTarifacaoService, 
                                   IContratoService contratoService, 
                                   IMapper mapper, INotificador notificador) : base(notificador)
        {            
            _consultaService = service;
            _fornecedorService = fornecedorService;
            _planoTarifacaoService = planoTarifacaoService;
            _contratoService = contratoService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {            
            return View(_mapper.Map<IEnumerable<ConsultaViewModel>>(await _consultaService.BuscarConsultasDetalhadas()));
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {                
                return NotFound();
            }
            
            var vmConsulta = _mapper.Map<ConsultaViewModel>(await _consultaService.BuscarConsultaDetalhada(c => c.Id == id));
                
            if (vmConsulta == null)
            {
                return NotFound();
            }

            return View(vmConsulta);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["ContratoId"] = new SelectList(await _contratoService.ObterTodos(), "Id", "Id");
            ViewData["FornecedorId"] = new SelectList(await _fornecedorService.ObterTodos(), "Id", "Descricao");
            ViewData["PlanoTarifacaoId"] = new SelectList(await _planoTarifacaoService.ObterTodos(), "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FornecedorId,PlanoTarifacaoId,ContratoId,Login,Senha")] ConsultaViewModel vmConsulta)
        {
            if (ModelState.IsValid)
            {
                vmConsulta.Id = Guid.NewGuid();
                await _consultaService.Adicionar(_mapper.Map<Consulta>(vmConsulta));
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContratoId"] = new SelectList(await _contratoService.ObterTodos(), "Id", "Id", vmConsulta.ContratoId);
            ViewData["FornecedorId"] = new SelectList(await _fornecedorService.ObterTodos(), "Id", "Descricao", vmConsulta.FornecedorId);
            ViewData["PlanoTarifacaoId"] = new SelectList(await _planoTarifacaoService.ObterTodos(), "Id", "Id", vmConsulta.PlanoTarifacaoId);
            return View(vmConsulta);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vmConsulta = _mapper.Map<ConsultaViewModel>(await _consultaService.ObterPorId(id.Value));
            if (vmConsulta == null)
            {
                return NotFound();
            }
            ViewData["ContratoId"] = new SelectList(await _contratoService.ObterTodos(), "Id", "Id", vmConsulta.ContratoId);
            ViewData["FornecedorId"] = new SelectList(await _fornecedorService.ObterTodos(), "Id", "Descricao", vmConsulta.FornecedorId);
            ViewData["PlanoTarifacaoId"] = new SelectList(await _planoTarifacaoService.ObterTodos(), "Id", "Id", vmConsulta.PlanoTarifacaoId);
            return View(vmConsulta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FornecedorId,PlanoTarifacaoId,ContratoId,Login,Senha")] ConsultaViewModel vmConsulta)
        {
            if (id != vmConsulta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _consultaService.Atualizar(_mapper.Map<Consulta>(vmConsulta));
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContratoId"] = new SelectList(await _contratoService.ObterTodos(), "Id", "Id", vmConsulta.ContratoId);
            ViewData["FornecedorId"] = new SelectList(await _fornecedorService.ObterTodos(), "Id", "Descricao", vmConsulta.FornecedorId);
            ViewData["PlanoTarifacaoId"] = new SelectList(await _planoTarifacaoService.ObterTodos(), "Id", "Id", vmConsulta.PlanoTarifacaoId);
            return View(vmConsulta);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vmConsulta = _mapper.Map<ConsultaViewModel>(await _consultaService.BuscarConsultaDetalhada(c => c.Id == id));

            if (vmConsulta == null)
            {
                return NotFound();
            }

            return View(vmConsulta);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {   
            if (ConsultaExists(id))
            {
                await _consultaService.Remover(id);
            }           
            
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaExists(Guid id)
        {
          return _consultaService.Buscar(e => e.Id == id).Result.Any();
        }
    }
}
