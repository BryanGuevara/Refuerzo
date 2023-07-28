using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Refuerzo.Models;
using Refuerzo.Models.DAL;

namespace Refuerzo.Controllers
{
    public class TablasController : Controller
    {
        private readonly DBContext _context;

        public TablasController(DBContext context)
        {
            _context = context;
        }

        // GET: Tablas
        public async Task<IActionResult> Index()
        {
              return _context.MiTablas != null ? 
                          View(await _context.MiTablas.ToListAsync()) :
                          Problem("Entity set 'DBContext.MiTablas'  is null.");
        }

        // GET: Tablas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MiTablas == null)
            {
                return NotFound();
            }

            var miTabla = await _context.MiTablas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miTabla == null)
            {
                return NotFound();
            }

            return View(miTabla);
        }

        // GET: Tablas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tablas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Edad,CorreoElectronico")] MiTabla miTabla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(miTabla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(miTabla);
        }

        // GET: Tablas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MiTablas == null)
            {
                return NotFound();
            }

            var miTabla = await _context.MiTablas.FindAsync(id);
            if (miTabla == null)
            {
                return NotFound();
            }
            return View(miTabla);
        }

        // POST: Tablas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Edad,CorreoElectronico")] MiTabla miTabla)
        {
            if (id != miTabla.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miTabla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiTablaExists(miTabla.Id))
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
            return View(miTabla);
        }

        // GET: Tablas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MiTablas == null)
            {
                return NotFound();
            }

            var miTabla = await _context.MiTablas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miTabla == null)
            {
                return NotFound();
            }

            return View(miTabla);
        }

        // POST: Tablas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MiTablas == null)
            {
                return Problem("Entity set 'DBContext.MiTablas'  is null.");
            }
            var miTabla = await _context.MiTablas.FindAsync(id);
            if (miTabla != null)
            {
                _context.MiTablas.Remove(miTabla);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiTablaExists(int id)
        {
          return (_context.MiTablas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
