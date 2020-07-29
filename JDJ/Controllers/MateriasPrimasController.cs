using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JDJ.Data;
using JDJ.Models;

namespace JDJ.Controllers
{
    public class MateriasPrimasController : Controller
    {
        private readonly PrincipalContext _context;

        public MateriasPrimasController(PrincipalContext context)
        {
            _context = context;
        }

        // GET: MateriasPrimas
        public async Task<IActionResult> Index()
        {
            return View(await _context.MateriasPrimas.ToListAsync());
        }

        // GET: MateriasPrimas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaPrima = await _context.MateriasPrimas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materiaPrima == null)
            {
                return NotFound();
            }

            return View(materiaPrima);
        }

        // GET: MateriasPrimas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MateriasPrimas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,UnidadMedida")] MateriaPrima materiaPrima)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materiaPrima);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materiaPrima);
        }

        // GET: MateriasPrimas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaPrima = await _context.MateriasPrimas.FindAsync(id);
            if (materiaPrima == null)
            {
                return NotFound();
            }
            return View(materiaPrima);
        }

        // POST: MateriasPrimas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,UnidadMedida")] MateriaPrima materiaPrima)
        {
            if (id != materiaPrima.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materiaPrima);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaPrimaExists(materiaPrima.Id))
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
            return View(materiaPrima);
        }

        // GET: MateriasPrimas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaPrima = await _context.MateriasPrimas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materiaPrima == null)
            {
                return NotFound();
            }

            return View(materiaPrima);
        }

        // POST: MateriasPrimas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materiaPrima = await _context.MateriasPrimas.FindAsync(id);
            _context.MateriasPrimas.Remove(materiaPrima);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriaPrimaExists(int id)
        {
            return _context.MateriasPrimas.Any(e => e.Id == id);
        }
    }
}
