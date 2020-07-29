using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JDJ.Data;
using JDJ.Models;

namespace JDJ.Controllers
{
    public class TipoPersonasController : Controller
    {
        private readonly PrincipalContext _context;

        public TipoPersonasController(PrincipalContext context)
        {
            _context = context;
        }

        // GET: TipoPersonas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoPersonas.ToListAsync());
        }

        // GET: TipoPersonas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPersona = await _context.TipoPersonas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoPersona == null)
            {
                return NotFound();
            }

            return View(tipoPersona);
        }

        // GET: TipoPersonas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPersonas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonaTipo")] TipoPersona tipoPersona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPersona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPersona);
        }

        // GET: TipoPersonas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPersona = await _context.TipoPersonas.FindAsync(id);
            if (tipoPersona == null)
            {
                return NotFound();
            }
            return View(tipoPersona);
        }

        // POST: TipoPersonas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonaTipo")] TipoPersona tipoPersona)
        {
            if (id != tipoPersona.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPersona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPersonaExists(tipoPersona.Id))
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
            return View(tipoPersona);
        }

        // GET: TipoPersonas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPersona = await _context.TipoPersonas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoPersona == null)
            {
                return NotFound();
            }

            return View(tipoPersona);
        }

        // POST: TipoPersonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoPersona = await _context.TipoPersonas.FindAsync(id);
            _context.TipoPersonas.Remove(tipoPersona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPersonaExists(int id)
        {
            return _context.TipoPersonas.Any(e => e.Id == id);
        }
    }
}
