using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Services;
using XPTO.Domain.Service.Notification;
using XPTO.UI.MVC.Models;

namespace XPTO.UI.MVC.Controllers
{
    public class PlanoTarifacaoController : BaseController
    {
        private readonly IPlanoTarifacaoService _service;
        private readonly IMapper _mapper;

        public PlanoTarifacaoController(IPlanoTarifacaoService service, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
              return View(_mapper.Map<IEnumerable<PlanoTarifacaoViewModel>>(await _service.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vmPlanoTarifacao = _mapper.Map<PlanoTarifacaoViewModel>(await _service.ObterPorId(id.Value));
            if (vmPlanoTarifacao == null)
            {
                return NotFound();
            }

            return View(vmPlanoTarifacao);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlanoTarifacaoViewModel vmPlanoTarifacao)
        {
            if (ModelState.IsValid)
            {
                vmPlanoTarifacao.Id = Guid.NewGuid();
                await _service.Adicionar(_mapper.Map<PlanoTarifacao>(vmPlanoTarifacao));                
                return RedirectToAction(nameof(Index));
            }
            return View(vmPlanoTarifacao);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vmPlanoTarifacao = _mapper.Map<PlanoTarifacaoViewModel>(await _service.ObterPorId(id.Value));
            if (vmPlanoTarifacao == null)
            {
                return NotFound();
            }

            return View(vmPlanoTarifacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PlanoTarifacaoViewModel vmPlanoTarifacao)
        {
            if (id != vmPlanoTarifacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _service.Atualizar(_mapper.Map<PlanoTarifacao>(vmPlanoTarifacao));
                return RedirectToAction(nameof(Index));
            }
            return View(vmPlanoTarifacao);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vmPlanoTarifacao = _mapper.Map<PlanoTarifacaoViewModel>(await _service.ObterPorId(id.Value));
            if (vmPlanoTarifacao == null)
            {
                return NotFound();
            }

            return View(vmPlanoTarifacao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (PlanoTarifacaoExists(id))
            {
                await _service.Remover(id);
            }            
            
            return RedirectToAction(nameof(Index));
        }

        private bool PlanoTarifacaoExists(Guid id)
        {
            return _service.Buscar(e => e.Id == id).Result.Any();
        }
    }
}
