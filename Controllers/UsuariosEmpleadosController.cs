using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    public class UsuariosEmpleadosController : Controller
    {
        private readonly SqlDatabaseBibliotecaContext _context;

        public UsuariosEmpleadosController(SqlDatabaseBibliotecaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, int? pageNumber)
        {

            int pageSize = 5;
            int currentPage = pageNumber ?? 1;

            var usuariosEmpleados = _context.UsuariosEmpleado.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                usuariosEmpleados = usuariosEmpleados.Where(l =>
                    l.Name.ToLower().Contains(searchString.ToLower()) ||
                    l.Rol.ToLower().Contains(searchString.ToLower()) ||
                    l.Identificador.ToString().ToLower().Contains(searchString.ToLower()) ||
                    l.FechaCreacion.ToString().ToLower().Contains(searchString.ToLower()) ||
                    (l.Estado ? "activo" : "inactivo").Contains(searchString.ToLower())
                );
            }

            var usuariosEmpleado_view = PaginatedList<UsuariosEmpleado>.Create(usuariosEmpleados, currentPage, pageSize);

            ViewData["CurrentFilter"] = searchString;

            return View(usuariosEmpleado_view);

        }

        // GET: UsuariosEmpleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuariosEmpleado = await _context.UsuariosEmpleado
                .Include(u => u.EmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.Identificador == id);
                
            if (usuariosEmpleado == null)
            {
                return NotFound();
            }

            return View(usuariosEmpleado);
        }

        // GET: UsuariosEmpleados/Create
        public IActionResult Create()
        {
            ViewData["Empleado"] = new SelectList(_context.Empleados, "Identificador", "Nombre");
            return View();
        }

        // POST: UsuariosEmpleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Identificador,Name,Password,Rol,Estado,Empleado")] UsuariosEmpleado usuariosEmpleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuariosEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Empleado"] = new SelectList(_context.Empleados, "Identificador", "Identificador", usuariosEmpleado.Empleado);
            return View(usuariosEmpleado);
        }

        // GET: UsuariosEmpleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuariosEmpleado = await _context.UsuariosEmpleado.FindAsync(id);
            if (usuariosEmpleado == null)
            {
                return NotFound();
            }
            ViewData["Empleado"] = new SelectList(_context.Empleados, "Identificador", "Identificador", usuariosEmpleado.Empleado);
            return View(usuariosEmpleado);
        }

        // POST: UsuariosEmpleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Identificador,Name,Password,Rol,Estado,Empleado")] UsuariosEmpleado usuariosEmpleado)
        {
            if (id != usuariosEmpleado.Identificador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuariosEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosEmpleadoExists(usuariosEmpleado.Identificador))
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
            ViewData["Empleado"] = new SelectList(_context.Empleados, "Identificador", "Identificador", usuariosEmpleado.Empleado);
            return View(usuariosEmpleado);
        }

        // GET: UsuariosEmpleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuariosEmpleado = await _context.UsuariosEmpleado
                .Include(u => u.EmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (usuariosEmpleado == null)
            {
                return NotFound();
            }

            return View(usuariosEmpleado);
        }

        // POST: UsuariosEmpleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuariosEmpleado = await _context.UsuariosEmpleado.FindAsync(id);
            if (usuariosEmpleado != null)
            {
                _context.UsuariosEmpleado.Remove(usuariosEmpleado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuariosEmpleadoExists(int id)
        {
            return _context.UsuariosEmpleado.Any(e => e.Identificador == id);
        }
    }
}
