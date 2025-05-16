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
        public IActionResult Checar()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Checar(string email, string senha)
        {
            var usuario = _loginRepositorio.ObterUsuario(email);
            if (usuario == null)
            {
                return NotFound();
            }
            if(usuario != null && usuario.Senha == senha)
            {
                return RedirectToAction("Index", "Produto");
            }
            ModelState.AddModelError("", "Erro, informações incorretas.");
            return View();
        }
    }
}