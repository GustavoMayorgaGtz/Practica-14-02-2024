using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practica_14_02_2024.Context;
using Practica_14_02_2024.Models;

namespace Practica_14_02_2024.Controllers
{
    public class CompradorsController : Controller
    {
        private readonly ProjectContext _context;

        public CompradorsController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Compradors
        public async Task<IActionResult> Index()
        {
              return _context.Comprador != null ? 
                          View(await _context.Comprador.ToListAsync()) :
                          Problem("Entity set 'ProjectContext.Comprador'  is null.");
        }

        // GET: Compradors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Comprador == null)
            {
                return NotFound();
            }

            var comprador = await _context.Comprador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comprador == null)
            {
                return NotFound();
            }

            return View(comprador);
        }

        // GET: Compradors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Compradors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Telefono,Correo,Activo,URLpath,FechaRegistro")] Comprador comprador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comprador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comprador);
        }

        // GET: Compradors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Comprador == null)
            {
                return NotFound();
            }

            var comprador = await _context.Comprador.FindAsync(id);
            if (comprador == null)
            {
                return NotFound();
            }
            return View(comprador);
        }

        // POST: Compradors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Telefono,Correo,Activo,URLpath,FechaRegistro")] Comprador comprador)
        {
            if (id != comprador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comprador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompradorExists(comprador.Id))
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
            return View(comprador);
        }

        // GET: Compradors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Comprador == null)
            {
                return NotFound();
            }

            var comprador = await _context.Comprador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comprador == null)
            {
                return NotFound();
            }

            return View(comprador);
        }

        // POST: Compradors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Comprador == null)
            {
                return Problem("Entity set 'ProjectContext.Comprador'  is null.");
            }
            var comprador = await _context.Comprador.FindAsync(id);
            if (comprador != null)
            {
                _context.Comprador.Remove(comprador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompradorExists(int id)
        {
          return (_context.Comprador?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
