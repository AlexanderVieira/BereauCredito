using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Services;
using XPTO.Domain.Service.Notification;
using XPTO.UI.MVC.Models;

namespace XPTO.UI.MVC.Controllers
{
    public class UsuariosController : BaseController
    {
        private readonly IUsuarioService _service;        
        private readonly IMapper _mapper;
        public UsuariosController(IUsuarioService service, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<UsuarioViewModel>>(await _service.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vmUsuario = _mapper.Map<UsuarioViewModel>(await _service.ObterPorId(id.Value));
            if (vmUsuario == null)
            {
                return NotFound();
            }

            return View(vmUsuario);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioViewModel vmUsuario)
        {
            if (ModelState.IsValid)
            {
                vmUsuario.Id = Guid.NewGuid();                
                await _service.Adicionar(_mapper.Map<Usuario>(vmUsuario));
                return RedirectToAction(nameof(Index));
            }
            return View(vmUsuario);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vmUsuario = _mapper.Map<UsuarioViewModel>(await _service.ObterPorId(id.Value));
            if (vmUsuario == null)
            {
                return NotFound();
            }

            return View(vmUsuario);            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, UsuarioViewModel vmUsuario)
        {
            if (id != vmUsuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _service.Atualizar(_mapper.Map<Usuario>(vmUsuario));
                return RedirectToAction(nameof(Index));
            }
            return View(vmUsuario);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vmUsuario = _mapper.Map<UsuarioViewModel>(await _service.ObterPorId(id.Value));
            if (vmUsuario == null)
            {
                return NotFound();
            }

            return View(vmUsuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (UsuarioExists(id))
            {
                await _service.Remover(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(Guid id)
        {
            return _service.Buscar(e => e.Id == id).Result.Any();
        }
    }
}
