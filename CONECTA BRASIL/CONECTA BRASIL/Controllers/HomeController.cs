using CONECTA_BRASIL.Data;
using CONECTA_BRASIL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CONECTA_BRASIL.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CONECTA_BRASIL.Controllers
{
    public class HomeController : Controller
    {
        private readonly CONECTA_BRASILContext _context;

        public HomeController(CONECTA_BRASILContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? categoriaId)
        {
            var usuarioNome = User.Identity.IsAuthenticated ? User.Identity.Name : "Visitante";

            var viewModel = new HomeViewModel
            {
                Categorias = _context.Categorias.ToList(),
                Publicacoes = _context.Publicacoes
                                      .Include(p => p.PublicacaoCategorias)
                                      .ThenInclude(pc => pc.Categoria)
                                      .Where(p => !categoriaId.HasValue || p.PublicacaoCategorias.Any(pc => pc.CategoriaId == categoriaId))
                                      .ToList(),
                CategoriaSelecionadaId = categoriaId ?? 0,
                UsuarioNome = usuarioNome
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
