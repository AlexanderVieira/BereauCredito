using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XPTO.UI.MVC.Data;
using XPTO.UI.MVC.Models;

namespace XPTO.UI.MVC.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly XPTOUIMVCContext _context;

        public FornecedoresController(XPTOUIMVCContext context)
        {
            _context = context;
        }

        // GET: Fornecedores
        public async Task<IActionResult> Index()
        {
              return View(await _context.FornecedorResponseViewModel.ToListAsync());
        }

        // GET: Fornecedores/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.FornecedorResponseViewModel == null)
            {
                return NotFound();
            }

            var fornecedorResponseViewModel = await _context.FornecedorResponseViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedorResponseViewModel == null)
            {
                return NotFound();
            }

            return View(fornecedorResponseViewModel);
        }

        // GET: Fornecedores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fornecedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao")] FornecedorViewModel fornecedorResponseViewModel)
        {
            if (ModelState.IsValid)
            {
                fornecedorResponseViewModel.Id = Guid.NewGuid();
                _context.Add(fornecedorResponseViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedorResponseViewModel);
        }

        // GET: Fornecedores/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.FornecedorResponseViewModel == null)
            {
                return NotFound();
            }

            var fornecedorResponseViewModel = await _context.FornecedorResponseViewModel.FindAsync(id);
            if (fornecedorResponseViewModel == null)
            {
                return NotFound();
            }
            return View(fornecedorResponseViewModel);
        }

        // POST: Fornecedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Descricao")] FornecedorViewModel fornecedorResponseViewModel)
        {
            if (id != fornecedorResponseViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fornecedorResponseViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedorResponseViewModelExists(fornecedorResponseViewModel.Id))
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
            return View(fornecedorResponseViewModel);
        }

        // GET: Fornecedores/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.FornecedorResponseViewModel == null)
            {
                return NotFound();
            }

            var fornecedorResponseViewModel = await _context.FornecedorResponseViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedorResponseViewModel == null)
            {
                return NotFound();
            }

            return View(fornecedorResponseViewModel);
        }

        // POST: Fornecedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.FornecedorResponseViewModel == null)
            {
                return Problem("Entity set 'XPTOUIMVCContext.FornecedorResponseViewModel'  is null.");
            }
            var fornecedorResponseViewModel = await _context.FornecedorResponseViewModel.FindAsync(id);
            if (fornecedorResponseViewModel != null)
            {
                _context.FornecedorResponseViewModel.Remove(fornecedorResponseViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FornecedorResponseViewModelExists(Guid id)
        {
          return _context.FornecedorResponseViewModel.Any(e => e.Id == id);
        }
    }
}
