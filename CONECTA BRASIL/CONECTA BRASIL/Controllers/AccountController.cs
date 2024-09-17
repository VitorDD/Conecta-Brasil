using CONECTA_BRASIL.Data;
using CONECTA_BRASIL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CONECTA_BRASIL.Controllers
{
    public class AccountController : Controller
    {
        private readonly CONECTA_BRASILContext _context;

        public AccountController(CONECTA_BRASILContext context)
        {
            _context = context;
        }

        // Exibe a tela de Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Processa o login
        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var usuario = _context.Usuario.SingleOrDefault(u => u.Email == email && u.Senha == senha);

            if (usuario == null)
            {
                ViewBag.Message = "Email ou Senha incorretos";
                return View();
            }

            // Redirecionar com base no tipo de usuário (Pessoa ou Instituição)
            if (usuario is Pessoa)
            {
                return RedirectToAction("Dashboard", "Pessoa");
            }
            else if (usuario is Instituicao)
            {
                return RedirectToAction("Dashboard", "Instituicao");
            }

            return View();
        }

        // Redireciona para a tela de registro
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        }
    }