using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Services;
using XPTO.Domain.Service.Notification;
using XPTO.UI.MVC.Models;

namespace XPTO.UI.MVC.Controllers
{
    public class OperacoesController : BaseController
    {
        private readonly IOperacaoService _service;
        private readonly IMapper _mapper;
        public OperacoesController(IOperacaoService service, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<OperacaoViewModel>>(await _service.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vmOperacao = _mapper.Map<OperacaoViewModel>(await _service.ObterPorId(id.Value));
            if (vmOperacao == null)
            {
                return NotFound();
            }

            return View(vmOperacao);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OperacaoViewModel vmOperacao)
        {
            if (ModelState.IsValid)
            {
                vmOperacao.Id = Guid.NewGuid();
                vmOperacao.DataOperacao = DateTime.Now;
                await _service.Adicionar(_mapper.Map<Operacao>(vmOperacao));
                return RedirectToAction(nameof(Index));
            }
            return View(vmOperacao);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vmOperacao = _mapper.Map<OperacaoViewModel>(await _service.ObterPorId(id.Value));
            if (vmOperacao == null)
            {
                return NotFound();
            }

            return View(vmOperacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, OperacaoViewModel vmOperacao)
        {
            if (id != vmOperacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _service.Atualizar(_mapper.Map<Operacao>(vmOperacao));
                return RedirectToAction(nameof(Index));
            }
            return View(vmOperacao);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vmOperacao = _mapper.Map<OperacaoViewModel>(await _service.ObterPorId(id.Value));
            if (vmOperacao == null)
            {
                return NotFound();
            }

            return View(vmOperacao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (OperacaoExists(id))
            {
                await _service.Remover(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool OperacaoExists(Guid id)
        {
          return _service.Buscar(e => e.Id == id).Result.Any();
        }
    }
}
