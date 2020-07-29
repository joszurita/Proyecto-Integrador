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
    public class DetalleProduccionesController : Controller
    {
        private readonly PrincipalContext _context;

        public DetalleProduccionesController(PrincipalContext context)
        {
            _context = context;
        }

        // GET: DetalleProducciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.DetalleProducciones.ToListAsync());
        }

        // GET: DetalleProducciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleProduccion = await _context.DetalleProducciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleProduccion == null)
            {
                return NotFound();
            }

            return View(detalleProduccion);
        }

        // GET: DetalleProducciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DetalleProducciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MateriaPrimaConsumida,MargenGanancia,Costo")] DetalleProduccion detalleProduccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleProduccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detalleProduccion);
        }

        // GET: DetalleProducciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleProduccion = await _context.DetalleProducciones.FindAsync(id);
            if (detalleProduccion == null)
            {
                return NotFound();
            }
            return View(detalleProduccion);
        }

        // POST: DetalleProducciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MateriaPrimaConsumida,MargenGanancia,Costo")] DetalleProduccion detalleProduccion)
        {
            if (id != detalleProduccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleProduccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleProduccionExists(detalleProduccion.Id))
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
            return View(detalleProduccion);
        }

        // GET: DetalleProducciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleProduccion = await _context.DetalleProducciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleProduccion == null)
            {
                return NotFound();
            }

            return View(detalleProduccion);
        }

        // POST: DetalleProducciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleProduccion = await _context.DetalleProducciones.FindAsync(id);
            _context.DetalleProducciones.Remove(detalleProduccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleProduccionExists(int id)
        {
            return _context.DetalleProducciones.Any(e => e.Id == id);
        }
    }
}
