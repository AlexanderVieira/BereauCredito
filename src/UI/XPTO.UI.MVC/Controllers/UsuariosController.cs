using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XPTO.UI.MVC.Data;
using XPTO.UI.MVC.Models;

namespace XPTO.UI.MVC.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly XPTOUIMVCContext _context;

        public UsuariosController(XPTOUIMVCContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
              return View(await _context.UsuarioResponseViewModel.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.UsuarioResponseViewModel == null)
            {
                return NotFound();
            }

            var usuarioResponseViewModel = await _context.UsuarioResponseViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioResponseViewModel == null)
            {
                return NotFound();
            }

            return View(usuarioResponseViewModel);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,Login,Senha")] UsuarioViewModel usuarioResponseViewModel)
        {
            if (ModelState.IsValid)
            {
                usuarioResponseViewModel.Id = Guid.NewGuid();
                _context.Add(usuarioResponseViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioResponseViewModel);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.UsuarioResponseViewModel == null)
            {
                return NotFound();
            }

            var usuarioResponseViewModel = await _context.UsuarioResponseViewModel.FindAsync(id);
            if (usuarioResponseViewModel == null)
            {
                return NotFound();
            }
            return View(usuarioResponseViewModel);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ClienteId,Login,Senha")] UsuarioViewModel usuarioResponseViewModel)
        {
            if (id != usuarioResponseViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioResponseViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioResponseViewModelExists(usuarioResponseViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioResponseViewModel);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.UsuarioResponseViewModel == null)
            {
                return NotFound();
            }

            var usuarioResponseViewModel = await _context.UsuarioResponseViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioResponseViewModel == null)
            {
                return NotFound();
            }

            return View(usuarioResponseViewModel);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.UsuarioResponseViewModel == null)
            {
                return Problem("Entity set 'XPTOUIMVCContext.UsuarioResponseViewModel'  is null.");
            }
            var usuarioResponseViewModel = await _context.UsuarioResponseViewModel.FindAsync(id);
            if (usuarioResponseViewModel != null)
            {
                _context.UsuarioResponseViewModel.Remove(usuarioResponseViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioResponseViewModelExists(Guid id)
        {
          return _context.UsuarioResponseViewModel.Any(e => e.Id == id);
        }
    }
}
