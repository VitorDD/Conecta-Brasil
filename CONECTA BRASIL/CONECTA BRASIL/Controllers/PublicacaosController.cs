using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CONECTA_BRASIL.Data;
using CONECTA_BRASIL.Models;
using System.Security.Claims;

namespace CONECTA_BRASIL.Controllers
{
    public class PublicacaoController : Controller
    {
        private readonly CONECTA_BRASILContext _context;

        public PublicacaoController(CONECTA_BRASILContext context)
        {
            _context = context;
        }

        // GET: Publicacaos
        public async Task<IActionResult> Index()
        {
            try
            {
                var publicacoes = await _context.Publicacoes
                    .Include(p => p.Criador)
                    .ToListAsync();

                return View(publicacoes);
            }
            catch (Exception ex)
            {
                // Log the exception and handle it as needed
                // Example: ViewBag.ErrorMessage = "Erro ao carregar publicações.";
                return View("Error"); // Redireciona para uma view de erro genérico
            }
        }

        // GET: Publicacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacao = await _context.Publicacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publicacao == null)
            {
                return NotFound();
            }

            return View(publicacao);
        }

        // GET: Publicacao/Create
        [HttpGet]
        public IActionResult Create()
        {
            // Passa a lista de categorias para a View
            ViewBag.CategoriaId = new SelectList(_context.Categorias, "Id", "Tipo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Publicacao publicacao, int CategoriaId)
        {
            // Obtém o ID do usuário conectado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }

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

            _context.Publicacoes.Add(publicacao);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Index", "Home");
        }

        // GET: Publicacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacao = await _context.Publicacoes.FindAsync(id);
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

        // GET: Publicacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacao = await _context.Publicacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publicacao == null)
            {
                return NotFound();
            }

            return View(publicacao);
        }

        // POST: Publicacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publicacao = await _context.Publicacoes.FindAsync(id);
            if (publicacao != null)
            {
                _context.Publicacoes.Remove(publicacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicacaoExists(int id)
        {
            return _context.Publicacoes.Any(e => e.Id == id);
        }
    }
}
