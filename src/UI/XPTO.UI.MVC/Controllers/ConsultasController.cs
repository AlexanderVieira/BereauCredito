using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using XPTO.UI.MVC.Data;
using XPTO.UI.MVC.Models;

namespace XPTO.UI.MVC.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly XPTOUIMVCContext _context;

        public ConsultasController(XPTOUIMVCContext context)
        {
            _context = context;
        }

        // GET: Consultas
        public async Task<IActionResult> Index()
        {
            var xPTOUIMVCContext = _context.ConsultaResponseViewModel.Include(c => c.Contrato).Include(c => c.Fornecedor).Include(c => c.PlanoTarifacao);
            return View(await xPTOUIMVCContext.ToListAsync());
        }

        // GET: Consultas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ConsultaResponseViewModel == null)
            {
                return NotFound();
            }

            var consultaResponseViewModel = await _context.ConsultaResponseViewModel
                .Include(c => c.Contrato)
                .Include(c => c.Fornecedor)
                .Include(c => c.PlanoTarifacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultaResponseViewModel == null)
            {
                return NotFound();
            }

            return View(consultaResponseViewModel);
        }

        // GET: Consultas/Create
        public IActionResult Create()
        {
            ViewData["ContratoId"] = new SelectList(_context.Set<ContratoViewModel>(), "Id", "Id");
            ViewData["FornecedorId"] = new SelectList(_context.FornecedorResponseViewModel, "Id", "Descricao");
            ViewData["PlanoTarifacaoId"] = new SelectList(_context.Set<PlanoTarifacaoViewModel>(), "Id", "Id");
            return View();
        }

        // POST: Consultas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FornecedorId,PlanoTarifacaoId,ContratoId,Login,Senha")] ConsultaViewModel consultaResponseViewModel)
        {
            if (ModelState.IsValid)
            {
                consultaResponseViewModel.Id = Guid.NewGuid();
                _context.Add(consultaResponseViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContratoId"] = new SelectList(_context.Set<ContratoViewModel>(), "Id", "Id", consultaResponseViewModel.ContratoId);
            ViewData["FornecedorId"] = new SelectList(_context.FornecedorResponseViewModel, "Id", "Descricao", consultaResponseViewModel.FornecedorId);
            ViewData["PlanoTarifacaoId"] = new SelectList(_context.Set<PlanoTarifacaoViewModel>(), "Id", "Id", consultaResponseViewModel.PlanoTarifacaoId);
            return View(consultaResponseViewModel);
        }

        // GET: Consultas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.ConsultaResponseViewModel == null)
            {
                return NotFound();
            }

            var consultaResponseViewModel = await _context.ConsultaResponseViewModel.FindAsync(id);
            if (consultaResponseViewModel == null)
            {
                return NotFound();
            }
            ViewData["ContratoId"] = new SelectList(_context.Set<ContratoViewModel>(), "Id", "Id", consultaResponseViewModel.ContratoId);
            ViewData["FornecedorId"] = new SelectList(_context.FornecedorResponseViewModel, "Id", "Descricao", consultaResponseViewModel.FornecedorId);
            ViewData["PlanoTarifacaoId"] = new SelectList(_context.Set<PlanoTarifacaoViewModel>(), "Id", "Id", consultaResponseViewModel.PlanoTarifacaoId);
            return View(consultaResponseViewModel);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FornecedorId,PlanoTarifacaoId,ContratoId,Login,Senha")] ConsultaViewModel consultaResponseViewModel)
        {
            if (id != consultaResponseViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultaResponseViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaResponseViewModelExists(consultaResponseViewModel.Id))
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
            ViewData["ContratoId"] = new SelectList(_context.Set<ContratoViewModel>(), "Id", "Id", consultaResponseViewModel.ContratoId);
            ViewData["FornecedorId"] = new SelectList(_context.FornecedorResponseViewModel, "Id", "Descricao", consultaResponseViewModel.FornecedorId);
            ViewData["PlanoTarifacaoId"] = new SelectList(_context.Set<PlanoTarifacaoViewModel>(), "Id", "Id", consultaResponseViewModel.PlanoTarifacaoId);
            return View(consultaResponseViewModel);
        }

        // GET: Consultas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ConsultaResponseViewModel == null)
            {
                return NotFound();
            }

            var consultaResponseViewModel = await _context.ConsultaResponseViewModel
                .Include(c => c.Contrato)
                .Include(c => c.Fornecedor)
                .Include(c => c.PlanoTarifacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultaResponseViewModel == null)
            {
                return NotFound();
            }

            return View(consultaResponseViewModel);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.ConsultaResponseViewModel == null)
            {
                return Problem("Entity set 'XPTOUIMVCContext.ConsultaResponseViewModel'  is null.");
            }
            var consultaResponseViewModel = await _context.ConsultaResponseViewModel.FindAsync(id);
            if (consultaResponseViewModel != null)
            {
                _context.ConsultaResponseViewModel.Remove(consultaResponseViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaResponseViewModelExists(Guid id)
        {
          return _context.ConsultaResponseViewModel.Any(e => e.Id == id);
        }
    }
}
