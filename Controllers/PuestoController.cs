using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using feria.Models;

namespace feria.Controllers
{
    public class PuestoController : Controller
    {
        private readonly feriaAgricultorContext _context;

        public PuestoController(feriaAgricultorContext context)
        {
            _context = context;
        }

        // GET: Puesto
        public async Task<IActionResult> Index()
        {
            var feriaAgricultorContext = _context.Puestos.Include(p => p.IdAgricultorNavigation).Include(p => p.IdProducto1Navigation).Include(p => p.IdProducto2Navigation).Include(p => p.IdProducto3Navigation).Include(p => p.IdProducto4Navigation).Include(p => p.IdProducto5Navigation);
            return View(await feriaAgricultorContext.ToListAsync());
        }

        // GET: Puesto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puesto = await _context.Puestos
                .Include(p => p.IdAgricultorNavigation)
                .Include(p => p.IdProducto1Navigation)
                .Include(p => p.IdProducto2Navigation)
                .Include(p => p.IdProducto3Navigation)
                .Include(p => p.IdProducto4Navigation)
                .Include(p => p.IdProducto5Navigation)
                .FirstOrDefaultAsync(m => m.IdPuesto == id);
            if (puesto == null)
            {
                return NotFound();
            }

            return View(puesto);
        }

        // GET: Puesto/Create
        public IActionResult Create()
        {
            ViewData["IdAgricultor"] = new SelectList(_context.Agricultors, "IdAgricultor", "Nombre");
            ViewData["IdProducto1"] = new SelectList(_context.Productos, "IdProducto", "Nombre");
            ViewData["IdProducto2"] = new SelectList(_context.Productos, "IdProducto", "Nombre");
            ViewData["IdProducto3"] = new SelectList(_context.Productos, "IdProducto", "Nombre");
            ViewData["IdProducto4"] = new SelectList(_context.Productos, "IdProducto", "Nombre");
            ViewData["IdProducto5"] = new SelectList(_context.Productos, "IdProducto", "Nombre");
            return View();
        }

        // POST: Puesto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPuesto,IdAgricultor,IdProducto1,IdProducto2,IdProducto3,IdProducto4,IdProducto5,Disponibilidad")] Puesto puesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(puesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAgricultor"] = new SelectList(_context.Agricultors, "IdAgricultor", "IdAgricultor", puesto.IdAgricultor);
            ViewData["IdProducto1"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", puesto.IdProducto1);
            ViewData["IdProducto2"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", puesto.IdProducto2);
            ViewData["IdProducto3"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", puesto.IdProducto3);
            ViewData["IdProducto4"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", puesto.IdProducto4);
            ViewData["IdProducto5"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", puesto.IdProducto5);
            return View(puesto);
        }

        // GET: Puesto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puesto = await _context.Puestos.FindAsync(id);
            if (puesto == null)
            {
                return NotFound();
            }
            ViewData["IdAgricultor"] = new SelectList(_context.Agricultors, "IdAgricultor", "Nombre", puesto.IdAgricultor);
            ViewData["IdProducto1"] = new SelectList(_context.Productos, "IdProducto", "Nombre", puesto.IdProducto1);
            ViewData["IdProducto2"] = new SelectList(_context.Productos, "IdProducto", "Nombre", puesto.IdProducto2);
            ViewData["IdProducto3"] = new SelectList(_context.Productos, "IdProducto", "Nombre", puesto.IdProducto3);
            ViewData["IdProducto4"] = new SelectList(_context.Productos, "IdProducto", "Nombre", puesto.IdProducto4);
            ViewData["IdProducto5"] = new SelectList(_context.Productos, "IdProducto", "Nombre", puesto.IdProducto5);
            return View(puesto);
        }

        // POST: Puesto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPuesto,IdAgricultor,IdProducto1,IdProducto2,IdProducto3,IdProducto4,IdProducto5,Disponibilidad")] Puesto puesto)
        {
            if (id != puesto.IdPuesto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(puesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuestoExists(puesto.IdPuesto))
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
            ViewData["IdAgricultor"] = new SelectList(_context.Agricultors, "IdAgricultor", "IdAgricultor", puesto.IdAgricultor);
            ViewData["IdProducto1"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", puesto.IdProducto1);
            ViewData["IdProducto2"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", puesto.IdProducto2);
            ViewData["IdProducto3"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", puesto.IdProducto3);
            ViewData["IdProducto4"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", puesto.IdProducto4);
            ViewData["IdProducto5"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", puesto.IdProducto5);
            return View(puesto);
        }

        // GET: Puesto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puesto = await _context.Puestos
                .Include(p => p.IdAgricultorNavigation)
                .Include(p => p.IdProducto1Navigation)
                .Include(p => p.IdProducto2Navigation)
                .Include(p => p.IdProducto3Navigation)
                .Include(p => p.IdProducto4Navigation)
                .Include(p => p.IdProducto5Navigation)
                .FirstOrDefaultAsync(m => m.IdPuesto == id);
            if (puesto == null)
            {
                return NotFound();
            }

            return View(puesto);
        }

        // POST: Puesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var puesto = await _context.Puestos.FindAsync(id);
            _context.Puestos.Remove(puesto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuestoExists(int id)
        {
            return _context.Puestos.Any(e => e.IdPuesto == id);
        }
    }
}
