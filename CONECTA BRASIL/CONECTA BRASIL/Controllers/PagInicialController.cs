using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CONECTA_BRASIL.Data;
using CONECTA_BRASIL.Models;

namespace CONECTA_BRASIL.Controllers
{
    public class PagInicialController : Controller
    {
        private readonly CONECTA_BRASILContext _context;

        public PagInicialController(CONECTA_BRASILContext context)
        {
            _context = context;
        }

        // GET: PagInicials
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var publicacoes = await _context.Publicacoes
                .Include(p => p.PublicacaoCategorias)
                    .ThenInclude(pc => pc.Categoria)
                .ToListAsync();

            var model = new PagInicial
            {
                Publicacoes = publicacoes
            };

            return View(model);
        }

        // GET: PagInicials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagInicial = await _context.PagInicial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagInicial == null)
            {
                return NotFound();
            }

            return View(pagInicial);
        }

        // GET: PagInicials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PagInicials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] PagInicial pagInicial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagInicial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pagInicial);
        }

        // GET: PagInicials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagInicial = await _context.PagInicial.FindAsync(id);
            if (pagInicial == null)
            {
                return NotFound();
            }
            return View(pagInicial);
        }

        // POST: PagInicials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] PagInicial pagInicial)
        {
            if (id != pagInicial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagInicial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagInicialExists(pagInicial.Id))
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
            return View(pagInicial);
        }

        // GET: PagInicials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagInicial = await _context.PagInicial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagInicial == null)
            {
                return NotFound();
            }

            return View(pagInicial);
        }

        // POST: PagInicials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagInicial = await _context.PagInicial.FindAsync(id);
            if (pagInicial != null)
            {
                _context.PagInicial.Remove(pagInicial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagInicialExists(int id)
        {
            return _context.PagInicial.Any(e => e.Id == id);
        }
    }
}
