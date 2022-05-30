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
    public class AgricultorController : Controller
    {
        private readonly feriaAgricultorContext _context;

        public AgricultorController(feriaAgricultorContext context)
        {
            _context = context;
        }

        // GET: Agricultor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agricultors.ToListAsync());
        }

        // GET: Agricultor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agricultor = await _context.Agricultors
                .FirstOrDefaultAsync(m => m.IdAgricultor == id);
            if (agricultor == null)
            {
                return NotFound();
            }

            return View(agricultor);
        }

        // GET: Agricultor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agricultor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAgricultor,Nombre,Apel1,Apel2")] Agricultor agricultor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agricultor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agricultor);
        }

        // GET: Agricultor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agricultor = await _context.Agricultors.FindAsync(id);
            if (agricultor == null)
            {
                return NotFound();
            }
            return View(agricultor);
        }

        // POST: Agricultor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAgricultor,Nombre,Apel1,Apel2")] Agricultor agricultor)
        {
            if (id != agricultor.IdAgricultor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agricultor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgricultorExists(agricultor.IdAgricultor))
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
            return View(agricultor);
        }

        // GET: Agricultor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agricultor = await _context.Agricultors
                .FirstOrDefaultAsync(m => m.IdAgricultor == id);
            if (agricultor == null)
            {
                return NotFound();
            }

            return View(agricultor);
        }

        // POST: Agricultor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agricultor = await _context.Agricultors.FindAsync(id);
            _context.Agricultors.Remove(agricultor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgricultorExists(int id)
        {
            return _context.Agricultors.Any(e => e.IdAgricultor == id);
        }
    }
}
