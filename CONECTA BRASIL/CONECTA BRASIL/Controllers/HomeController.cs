using CONECTA_BRASIL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CONECTA_BRASIL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

<<<<<<< Updated upstream
        public IActionResult Index()
=======
        public IActionResult Index(int? categoriaId) // categoriaId agora é nullable
        {
            var usuarioNome = User.Identity.IsAuthenticated ? User.Identity.Name : "Visitante";

            var viewModel = new HomeViewModel
            {
                Categorias = _context.Categorias.ToList(),
                Publicacoes = _context.Publicacoes
                                      .Include(p => p.Criador)
                                      .Include(p => p.PublicacaoCategorias)
                                      .ThenInclude(pc => pc.Categoria)
                                      // Adicionada a verificação se categoriaId tem valor antes de usá-lo
                                      .Where(p => !categoriaId.HasValue || p.PublicacaoCategorias.Any(pc => pc.CategoriaId == categoriaId.Value))
                                      .OrderByDescending(p => p.DataCriacao)
                                      .ToList(),
                CategoriaSelecionadaId = categoriaId ?? 0,
                UsuarioNome = usuarioNome
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
>>>>>>> Stashed changes
        {
            return View();
        }

        public IActionResult Privacy()
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