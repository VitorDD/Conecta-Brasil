﻿using System;
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
    public class InstituiçãoController : Controller
    {
        private readonly CONECTA_BRASILContext _context;

        public InstituiçãoController(CONECTA_BRASILContext context)
        {
            _context = context;
        }

        // GET: Instituição
        public async Task<IActionResult> Index()
        {
            return View(await _context.Instituição.ToListAsync());
        }

        // GET: Instituição/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituição = await _context.Instituição
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instituição == null)
            {
                return NotFound();
            }

            return View(instituição);
        }

        // GET: Instituição/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instituição/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Atuacao,CNPJ,Id,Name,Email,Telefone,Senha")] Instituicao instituição)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instituição);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instituição);
        }

        // GET: Instituição/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituição = await _context.Instituição.FindAsync(id);
            if (instituição == null)
            {
                return NotFound();
            }
            return View(instituição);
        }

        // POST: Instituição/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Atuacao,CNPJ,Id,Name,Email,Telefone,Senha")] Instituicao instituição)
        {
            if (id != instituição.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instituição);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstituiçãoExists(instituição.Id))
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
            return View(instituição);
        }

        // GET: Instituição/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituição = await _context.Instituição
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instituição == null)
            {
                return NotFound();
            }

            return View(instituição);
        }

        // POST: Instituição/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instituição = await _context.Instituição.FindAsync(id);
            if (instituição != null)
            {
                _context.Instituição.Remove(instituição);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstituiçãoExists(int id)
        {
            return _context.Instituição.Any(e => e.Id == id);
        }
    }
}
