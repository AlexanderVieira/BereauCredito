using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using XPTO.Domain.Entities;
using XPTO.Domain.Interfaces.Services;
using XPTO.Domain.Service.Notification;
using XPTO.UI.MVC.Models;

namespace XPTO.UI.MVC.Controllers
{
    public class ClientesController : BaseController
    {
        private readonly IClienteService _service;
        private readonly IMapper _mapper;

        public ClientesController(IClienteService service, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ClienteViewModel>>(await _service.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vmCliente = _mapper.Map<ClienteViewModel>(await _service.ObterPorId(id.Value));
            if (vmCliente == null)
            {
                return NotFound();
            }

            return View(vmCliente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel vmCliente)
        {
            if (ModelState.IsValid)
            {                   
                vmCliente.Id = Guid.NewGuid();
                await _service.Adicionar(_mapper.Map<Cliente>(vmCliente));
                if (!OperacaoValida()) return View(vmCliente);
                return RedirectToAction(nameof(Index));
            }
            return View(vmCliente);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vmCliente = _mapper.Map<ClienteViewModel>(await _service.ObterPorId(id.Value));
            if (vmCliente == null)
            {
                return NotFound();
            }
            return View(vmCliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ClienteViewModel vmCliente)
        {
            if (id != vmCliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //var cliente = new Cliente { Id = vmCliente.Id, Nome = vmCliente.Nome, Cnpj = new Cnpj(vmCliente.Cnpj) };
                await _service.Atualizar(_mapper.Map<Cliente>(vmCliente));
                return RedirectToAction(nameof(Index));
            }
            return View(vmCliente);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vmCliente = _mapper.Map<ClienteViewModel>(await _service.ObterPorId(id.Value));
            if (vmCliente == null)
            {
                return NotFound();
            }

            return View(vmCliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {   
            if (ClienteExists(id))
            {
                await _service.Remover(id);
            }           
            
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(Guid id)
        {
          return _service.Buscar(e => e.Id == id).Result.Any();
        }
    }
}
