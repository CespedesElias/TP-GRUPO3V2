using Microsoft.AspNetCore.Mvc;
using TP_GRUPO3.Context;
using TP_GRUPO3.Models;
using TP_GRUPO3.Utils;

namespace TP_GRUPO3.Controllers
{
    public class SesionController : Controller
    {
        private readonly NegocioDatabaseContext _context;

        public SesionController(NegocioDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Si las variables de sesión ya están asignadas, redirige al dashboard
            if (HttpContext.Session.GetString("Username") != null)
            {                
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Si ya hay variables de usuario porque ya nos logeamos, no debería ir al login
            if (HttpContext.Session.GetString("Username") != null)
            {                
                return RedirectToAction("Index", "Home");
            }

            // Validar el usuario y contraseña en la base de datos
            var user = _context.Usuario.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {             
                HttpContext.Session.SetString("Username", user.Username.ToString());

                HttpContext.Session.SetObject("Usuario", user);

                ViewData["Usuario"] = user;                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["LoginError"] = "Credenciales inválidas";
                Usuario invalidUser = new Usuario { nombre = username };
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Logout()
        {
            // Eliminar las variables de sesión
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("Usuario");

            return RedirectToAction("Index", "Home"); // Redirigir a la página de inicio u otra página de tu elección
        }

        // GET: Sessions/CrearUsuario
        public IActionResult CrearUsuario()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (ModelState.IsValid && (!UsernameExists(usuario.Username)))
            {

                _context.Add(usuario);
                await _context.SaveChangesAsync();
                
                HttpContext.Session.SetString("Username", usuario.Username.ToString());
                // Guardar el objeto usuario en la sesión
                HttpContext.Session.SetObject("Usuario", usuario);
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["CreateNewUserError"] = "No se pudo crear el usuario debido a duplicados. Usuario y/o dni ya existentes.";                
                return RedirectToAction("CrearUsuario");
            }

        }


        private bool UsernameExists(string user)
        {
            bool exists = _context.Usuario.Any(e => e.Username == user);
            if (exists)
            {
                TempData["CrearUsuario"] = "Usuario repetido.";
            }
            return exists;
        }
    }
}
