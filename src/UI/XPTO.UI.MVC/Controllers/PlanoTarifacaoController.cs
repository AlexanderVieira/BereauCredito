using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XPTO.UI.MVC.Data;
using XPTO.UI.MVC.Models;

namespace XPTO.UI.MVC.Controllers
{
    public class PlanoTarifacaoController : Controller
    {
        private readonly XPTOUIMVCContext _context;

        public PlanoTarifacaoController(XPTOUIMVCContext context)
        {
            _context = context;
        }

        // GET: PlanoTarifacao
        public async Task<IActionResult> Index()
        {
              return View(await _context.PlanoTarifacaoResponseViewModel.ToListAsync());
        }

        // GET: PlanoTarifacao/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.PlanoTarifacaoResponseViewModel == null)
            {
                return NotFound();
            }

            var planoTarifacaoResponseViewModel = await _context.PlanoTarifacaoResponseViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planoTarifacaoResponseViewModel == null)
            {
                return NotFound();
            }

            return View(planoTarifacaoResponseViewModel);
        }

        // GET: PlanoTarifacao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlanoTarifacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataVigencia,Valor")] PlanoTarifacaoViewModel planoTarifacaoResponseViewModel)
        {
            if (ModelState.IsValid)
            {
                planoTarifacaoResponseViewModel.Id = Guid.NewGuid();
                _context.Add(planoTarifacaoResponseViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planoTarifacaoResponseViewModel);
        }

        // GET: PlanoTarifacao/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.PlanoTarifacaoResponseViewModel == null)
            {
                return NotFound();
            }

            var planoTarifacaoResponseViewModel = await _context.PlanoTarifacaoResponseViewModel.FindAsync(id);
            if (planoTarifacaoResponseViewModel == null)
            {
                return NotFound();
            }
            return View(planoTarifacaoResponseViewModel);
        }

        // POST: PlanoTarifacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,DataVigencia,Valor")] PlanoTarifacaoViewModel planoTarifacaoResponseViewModel)
        {
            if (id != planoTarifacaoResponseViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planoTarifacaoResponseViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanoTarifacaoResponseViewModelExists(planoTarifacaoResponseViewModel.Id))
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
            return View(planoTarifacaoResponseViewModel);
        }

        // GET: PlanoTarifacao/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.PlanoTarifacaoResponseViewModel == null)
            {
                return NotFound();
            }

            var planoTarifacaoResponseViewModel = await _context.PlanoTarifacaoResponseViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planoTarifacaoResponseViewModel == null)
            {
                return NotFound();
            }

            return View(planoTarifacaoResponseViewModel);
        }

        // POST: PlanoTarifacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.PlanoTarifacaoResponseViewModel == null)
            {
                return Problem("Entity set 'XPTOUIMVCContext.PlanoTarifacaoResponseViewModel'  is null.");
            }
            var planoTarifacaoResponseViewModel = await _context.PlanoTarifacaoResponseViewModel.FindAsync(id);
            if (planoTarifacaoResponseViewModel != null)
            {
                _context.PlanoTarifacaoResponseViewModel.Remove(planoTarifacaoResponseViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanoTarifacaoResponseViewModelExists(Guid id)
        {
          return _context.PlanoTarifacaoResponseViewModel.Any(e => e.Id == id);
        }
    }
}
