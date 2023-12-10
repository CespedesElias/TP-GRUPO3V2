using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP_GRUPO3.Context;
using TP_GRUPO3.Models;

namespace TP_GRUPO3.Controllers
{
    public class CarritoController : Controller
    {
        private readonly NegocioDatabaseContext _context;

        public CarritoController(NegocioDatabaseContext context)
        {
            _context = context;
        }

        // GET: Carrito
        public async Task<IActionResult> Index()
        {
            var negocioDatabaseContext = _context.Carrito.Include(c => c.producto).Include(c => c.usuario);
            return View(await negocioDatabaseContext.ToListAsync());
        }

        // GET: Carrito/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carrito == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carrito
                .Include(c => c.producto)
                .Include(c => c.usuario)
                .FirstOrDefaultAsync(m => m.id == id);
            if (carrito == null)
            {
                return NotFound();
            }

            return View(carrito);
        }

        // GET: Carrito/Create
        public IActionResult Create()
        {
            ViewData["productoid"] = new SelectList(_context.Productos, "id", "nombreColor");
            ViewData["usuarioid"] = new SelectList(_context.Usuario, "id", "nombreApellido");
            return View();
        }

        // POST: Carrito/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,productoid,usuarioid")] Carrito carrito)
        {
            if (!(ModelState.IsValid))
            {
                _context.Add(carrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["productoid"] = new SelectList(_context.Productos, "id", "nombreColor", carrito.productoid);
           
            ViewData["usuarioid"] = new SelectList(_context.Usuario, "id", "nombreApellido", carrito.usuarioid);
            return View(carrito);
        }

        // GET: Carrito/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carrito == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carrito.FindAsync(id);
            if (carrito == null)
            {
                return NotFound();
            }
            ViewData["productoid"] = new SelectList(_context.Productos, "id", "color", carrito.productoid);
            ViewData["usuarioid"] = new SelectList(_context.Usuario, "id", "apellido", carrito.usuarioid);
            return View(carrito);
        }

        // POST: Carrito/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,productoid,usuarioid")] Carrito carrito)
        {
            if (id != carrito.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarritoExists(carrito.id))
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
            ViewData["productoid"] = new SelectList(_context.Productos, "id", "color", carrito.productoid);
            ViewData["usuarioid"] = new SelectList(_context.Usuario, "id", "apellido", carrito.usuarioid);
            return View(carrito);
        }

        // GET: Carrito/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carrito == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carrito
                .Include(c => c.producto)
                .Include(c => c.usuario)
                .FirstOrDefaultAsync(m => m.id == id);
            if (carrito == null)
            {
                return NotFound();
            }

            return View(carrito);
        }

        // POST: Carrito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carrito == null)
            {
                return Problem("Entity set 'NegocioDatabaseContext.Carrito'  is null.");
            }
            var carrito = await _context.Carrito.FindAsync(id);
            if (carrito != null)
            {
                _context.Carrito.Remove(carrito);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarritoExists(int id)
        {
          return (_context.Carrito?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
