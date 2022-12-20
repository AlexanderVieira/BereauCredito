using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Services;
using XPTO.Domain.Service.Notification;
using XPTO.UI.MVC.Models;

namespace XPTO.UI.MVC.Controllers
{
    public class FornecedoresController : BaseController
    {
        private readonly IFornecedorService _service;
        private readonly IMapper _mapper;

        public FornecedoresController(IFornecedorService service, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<FornecedorViewModel>>(await _service.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vmFornecedor = _mapper.Map<FornecedorViewModel>(await _service.ObterPorId(id.Value));
            if (vmFornecedor == null)
            {
                return NotFound();
            }

            return View(vmFornecedor);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FornecedorViewModel vmFornecedor)
        {
            if (ModelState.IsValid)
            {
                vmFornecedor.Id = Guid.NewGuid();
                await _service.Adicionar(_mapper.Map<Fornecedor>(vmFornecedor));
                return RedirectToAction(nameof(Index));
            }
            return View(vmFornecedor);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vmFornecedor = _mapper.Map<FornecedorViewModel>(await _service.ObterPorId(id.Value));
            if (vmFornecedor == null)
            {
                return NotFound();
            }

            return View(vmFornecedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, FornecedorViewModel vmFornecedor)
        {
            if (id != vmFornecedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _service.Atualizar(_mapper.Map<Fornecedor>(vmFornecedor));
                return RedirectToAction(nameof(Index));
            }
            return View(vmFornecedor);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vmFornecedor = _mapper.Map<FornecedorViewModel>(await _service.ObterPorId(id.Value));
            if (vmFornecedor == null)
            {
                return NotFound();
            }

            return View(vmFornecedor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (FornecedorExists(id))
            {
                await _service.Remover(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool FornecedorExists(Guid id)
        {
          return _service.Buscar(e => e.Id == id).Result.Any();
        }
    }
}
