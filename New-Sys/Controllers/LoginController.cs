using Microsoft.AspNetCore.Mvc;
using New_Sys.Repositorio;
using New_Sys.Models;


namespace New_Sys.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginRepositorio _loginRepositorio;

        public LoginController(LoginRepositorio loginRepositorio)
        {
            _loginRepositorio = loginRepositorio;
        }

        public IActionResult ChecarUsuario(string email)
        {
            var usuario = _loginRepositorio.ObterUsuario(email);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }
    }
}