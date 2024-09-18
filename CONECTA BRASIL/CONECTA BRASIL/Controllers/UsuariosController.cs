using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CONECTA_BRASIL.Data;
using CONECTA_BRASIL.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace CONECTA_BRASIL.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly CONECTA_BRASILContext _context;
        private Pessoa pessoa;
        private Instituicao instituicao;

        public UsuariosController(CONECTA_BRASILContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Registro para Pessoa
        [HttpGet]
        public IActionResult RegisterPessoa()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPessoa(Pessoa model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Pessoa.Add(pessoa);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Login", "Usuarios");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                ViewBag.ErrorMessage = ex.Message;
            }
            return View(model);
        }

        // Registro para Instituição
        [HttpGet]
        public IActionResult RegisterInstituicao()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterInstituicao(Instituicao model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Instituicao.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Login", "Usuarios");
                }
            }
            catch (Exception ex)
            {
                // Use logging framework in real-world applications
                Console.WriteLine(ex.ToString());
                ViewBag.ErrorMessage = ex.Message;
            }

            return View(model);
        }

        // Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        private Usuario BuscarUsuarioPorEmail(string email)
        {
            // Buscando usuário na base de dados, pode ser Pessoa ou Instituicao
            return _context.Usuario
                .FirstOrDefault(u => u.Email == email);
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string senha)
        {
            Usuario usuario = BuscarUsuarioPorEmail(email);
            if (usuario != null && usuario.Senha == senha)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()), // Adiciona o ID do usuário
                    new Claim(ClaimTypes.Name, usuario.Name),
                    new Claim(ClaimTypes.Role, usuario is Pessoa ? "Pessoa" : "Instituicao")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Email ou senha inválidos");
            return View();
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuario.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Telefone,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Telefone,Senha")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }
    }
}
