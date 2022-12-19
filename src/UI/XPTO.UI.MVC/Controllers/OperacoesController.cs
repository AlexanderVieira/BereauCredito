using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XPTO.UI.MVC.Data;
using XPTO.UI.MVC.Models;

namespace XPTO.UI.MVC.Controllers
{
    public class OperacoesController : Controller
    {
        private readonly XPTOUIMVCContext _context;

        public OperacoesController(XPTOUIMVCContext context)
        {
            _context = context;
        }

        // GET: Operacoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.OperacaoResponseViewModel.ToListAsync());
        }

        // GET: Operacoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.OperacaoResponseViewModel == null)
            {
                return NotFound();
            }

            var operacaoResponseViewModel = await _context.OperacaoResponseViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (operacaoResponseViewModel == null)
            {
                return NotFound();
            }

            return View(operacaoResponseViewModel);
        }

        // GET: Operacoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Operacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] OperacaoViewModel operacaoResponseViewModel)
        {
            if (ModelState.IsValid)
            {
                operacaoResponseViewModel.Id = Guid.NewGuid();
                _context.Add(operacaoResponseViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(operacaoResponseViewModel);
        }

        // GET: Operacoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.OperacaoResponseViewModel == null)
            {
                return NotFound();
            }

            var operacaoResponseViewModel = await _context.OperacaoResponseViewModel.FindAsync(id);
            if (operacaoResponseViewModel == null)
            {
                return NotFound();
            }
            return View(operacaoResponseViewModel);
        }

        // POST: Operacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Descricao")] OperacaoViewModel operacaoResponseViewModel)
        {
            if (id != operacaoResponseViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operacaoResponseViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperacaoResponseViewModelExists(operacaoResponseViewModel.Id))
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
            return View(operacaoResponseViewModel);
        }

        // GET: Operacoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.OperacaoResponseViewModel == null)
            {
                return NotFound();
            }

            var operacaoResponseViewModel = await _context.OperacaoResponseViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (operacaoResponseViewModel == null)
            {
                return NotFound();
            }

            return View(operacaoResponseViewModel);
        }

        // POST: Operacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.OperacaoResponseViewModel == null)
            {
                return Problem("Entity set 'XPTOUIMVCContext.OperacaoResponseViewModel'  is null.");
            }
            var operacaoResponseViewModel = await _context.OperacaoResponseViewModel.FindAsync(id);
            if (operacaoResponseViewModel != null)
            {
                _context.OperacaoResponseViewModel.Remove(operacaoResponseViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperacaoResponseViewModelExists(Guid id)
        {
          return _context.OperacaoResponseViewModel.Any(e => e.Id == id);
        }
    }
}
