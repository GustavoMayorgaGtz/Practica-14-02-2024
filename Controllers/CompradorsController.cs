using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Practica_14_02_2024.Context;
using Practica_14_02_2024.Helpers;
using Practica_14_02_2024.Models;

namespace Practica_14_02_2024.Controllers
{
    public class CompradorsController : Controller
    {
        private readonly ProjectContext _context;
        private readonly AzureStorageConfig _config;

        public CompradorsController(ProjectContext context, IOptions<AzureStorageConfig> config)
        {
            _context = context;
            _config = config.Value;
        }

        // GET: Compradors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comprador.Include(e => e.OrdenCompra).ToListAsync());
        }

        // GET: Compradors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Comprador == null)
            {
                return NotFound();
            }

            var comprador = await _context.Comprador
                .Include(e => e.OrdenCompra)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comprador == null)
            {
                return NotFound();
            }

            return View(comprador);
        }

        // GET: Compradors/Create
        public async Task<IActionResult> Create()
        {
            
            var orden_comprador = await _context.OrdenCompra.ToListAsync();
            ViewBag.OrdenCompra = new SelectList(orden_comprador, "Id", "Proyecto");
            // Puedes agregar un mensaje en el ViewBag para ser utilizado en la vista.
            ViewBag.AlertMessage = "¡Esto es una alerta desde el servidor!";

            return View();
        }

        // POST: Compradors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Telefono,Correo,Activo,FechaRegistro, OrdenCompra")] Comprador comprador, IFormFile foto)
        {
            // Puedes agregar un mensaje en el ViewBag para ser utilizado en la vista.


            ViewBag.AlertMessage = "" + comprador.Correo + "" + comprador.Telefono + "" +
                                       comprador.Nombre + "" + comprador.Activo + "" + comprador.URLpath + "" + comprador.FechaRegistro + "" + comprador.OrdenCompra;


            //ViewBag.AlertMessage = "todo bien";
                if (foto == null)
                {
                    comprador.URLpath = StorageHelper.URL_Image;
                }else
                {
                    
                    string extension = foto.FileName.Split(".")[1];
                    ViewBag.AlertMessage = ""+foto.FileName;
                    string nombre = $"{Guid.NewGuid()}.{extension}";
                    comprador.URLpath = await StorageHelper.SubirArchivo(foto.OpenReadStream(), nombre, _config);
                }

                try
                {

                    _context.Set<Comprador>().Add(comprador);
                    _context.Entry(comprador.OrdenCompra).State = EntityState.Unchanged;

                    int registrosGuardados = await _context.SaveChangesAsync();

                    if (registrosGuardados > 0)
                    {
                        // Log exitoso
                        Console.WriteLine($"Se guardaron {registrosGuardados} registros en la base de datos.");

                        //return RedirectToAction("Compradors");
                    }
                    else
                    {
                        // Log sin cambios
                        Console.WriteLine("No se realizaron cambios en la base de datos.");

                        //return RedirectToAction("OtraAccion");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.AlertMessage = "" + ex;
                }
            //}
            //else
            //{
              
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
                .Include(e => e.OrdenCompra)
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
