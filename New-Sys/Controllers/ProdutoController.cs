using Microsoft.AspNetCore.Mvc;
using New_Sys.Models;
using New_Sys.Repositorio;

namespace New_Sys.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoRepositorio _produtoRepositorio;

        public ProdutoController(ProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IActionResult Index()
        {
            return View(_produtoRepositorio.TodosProdutos);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Produto produto)
        {
            _produtoRepositorio.Cadastrar(produto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Editar(int id)
        {
            var produto = _produtoRepositorio.ObterProduto(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, [Bind("Id, Nome, Descricao, Qauntidade")] Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (_produtoRepositorio.Atualizar(produto))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Ocorreu um erro ao editar.");
                    return View(produto);
                }
            }
            return View(produto);
        }

        public IActionResult Excluir(int id)
        {
            _produtoRepositorio.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}