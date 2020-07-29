using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JDJ.Data;
using JDJ.Models;

namespace JDJ.Controllers
{
    public class TipoPrendasController : Controller
    {
        private readonly PrincipalContext _context;

        public TipoPrendasController(PrincipalContext context)
        {
            _context = context;
        }

        // GET: TipoPrendas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoPrendas.ToListAsync());
        }

        // GET: TipoPrendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPrenda = await _context.TipoPrendas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoPrenda == null)
            {
                return NotFound();
            }

            return View(tipoPrenda);
        }

        // GET: TipoPrendas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPrendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PrendaTipo")] TipoPrenda tipoPrenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPrenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPrenda);
        }

        // GET: TipoPrendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPrenda = await _context.TipoPrendas.FindAsync(id);
            if (tipoPrenda == null)
            {
                return NotFound();
            }
            return View(tipoPrenda);
        }

        // POST: TipoPrendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PrendaTipo")] TipoPrenda tipoPrenda)
        {
            if (id != tipoPrenda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPrenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPrendaExists(tipoPrenda.Id))
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
            return View(tipoPrenda);
        }

        // GET: TipoPrendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPrenda = await _context.TipoPrendas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoPrenda == null)
            {
                return NotFound();
            }

            return View(tipoPrenda);
        }

        // POST: TipoPrendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoPrenda = await _context.TipoPrendas.FindAsync(id);
            _context.TipoPrendas.Remove(tipoPrenda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPrendaExists(int id)
        {
            return _context.TipoPrendas.Any(e => e.Id == id);
        }
    }
}
