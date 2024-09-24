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
    public class PublicacaosController : Controller
    {
        private readonly CONECTA_BRASILContext _context;

        public PublicacaosController(CONECTA_BRASILContext context)
        {
            _context = context;
        }

        // GET: Publicacaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Publicacao.ToListAsync());
        }

        // GET: Publicacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacao = await _context.Publicacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publicacao == null)
            {
                return NotFound();
            }

            return View(publicacao);
        }

        // GET: Publicacaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publicacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Categoria")] Publicacao publicacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publicacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
<<<<<<< Updated upstream
            return View(publicacao);
=======

            // Inicializa a lista de PublicacaoCategorias
            if (CategoriaId > 0)
            {
                publicacao.PublicacaoCategorias = new List<PublicacaoCategoria>
                {
                    new PublicacaoCategoria
                    {
                        CategoriaId = CategoriaId,
                        Publicacao = publicacao,
                        Categoria = await _context.Categorias.FindAsync(CategoriaId)
                    }
                };
            }

            // Associa o ID do usuário à publicação
            publicacao.CriadorId = int.Parse(userId); // Assumindo que o ID é um inteiro
            publicacao.Criador = await _context.Usuario.FindAsync(publicacao.CriadorId);
            publicacao.DataCriacao = DateTime.Now;

            _context.Publicacoes.Add(publicacao);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Index", "Home");
>>>>>>> Stashed changes
        }

        // GET: Publicacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacao = await _context.Publicacao.FindAsync(id);
            if (publicacao == null)
            {
                return NotFound();
            }
            return View(publicacao);
        }

        // POST: Publicacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Categoria")] Publicacao publicacao)
        {
            if (id != publicacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publicacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicacaoExists(publicacao.Id))
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
            return View(publicacao);
        }

        // GET: Publicacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacao = await _context.Publicacao
                .FirstOrDefaultAsync(m => m.Id == id);

            if (publicacao == null)
            {
                return NotFound();
            }

            return View(publicacao);
        }

        // POST: Home/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
<<<<<<< Updated upstream
            var publicacao = await _context.Publicacao.FindAsync(id);
            if (publicacao != null)
            {
                _context.Publicacao.Remove(publicacao);
=======
            var publicacaoCategorias = _context.PublicacaoCategorias.Where(pc => pc.PublicacaoId == id);
            _context.PublicacaoCategorias.RemoveRange(publicacaoCategorias);
            var publicacao = await _context.Publicacoes.FindAsync(id);
            if (publicacao != null)
            {
                _context.Publicacoes.Remove(publicacao);
                await _context.SaveChangesAsync();
>>>>>>> Stashed changes
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PublicacaoExists(int id)
        {
            return _context.Publicacao.Any(e => e.Id == id);
        }
    }
}
