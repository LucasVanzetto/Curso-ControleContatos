using ControleContatos.Models;
using ControleContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
  public class UsuarioController : Controller
  {
    private readonly IUsuarioRepositorio _usuarioRepositorio;

    public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
    {
      _usuarioRepositorio = usuarioRepositorio;
    }
    public IActionResult Index()
    {
      List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
      return View(usuarios);
    }

    public IActionResult Criar()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Criar(UsuarioModel usuario)
    {
      try
      {
        if (ModelState.IsValid)
        {
          _usuarioRepositorio.Adicionar(usuario);
          TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso";
          return RedirectToAction("Index");
        }

        return View(usuario);
      }
      catch (Exception erro)
      {
        TempData["MensagemErro"] = $"Erro ao cadastrar, tente novamente - {erro.Message}";
        return RedirectToAction("Index");
      }
    }
  }
}
