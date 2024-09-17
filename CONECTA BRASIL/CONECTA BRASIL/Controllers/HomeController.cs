using CONECTA_BRASIL.Data;
using CONECTA_BRASIL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CONECTA_BRASIL.ViewModels;

namespace CONECTA_BRASIL.Controllers
{
    public class HomeController : Controller
    {
        private readonly CONECTA_BRASILContext _context;

        public HomeController(CONECTA_BRASILContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.Categorias = _context.Categorias;
            model.Publicacoes = _context.Publicacoes;
            // Aqui vou carregar os dados que vão para a página inicial

            return View(model);
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
