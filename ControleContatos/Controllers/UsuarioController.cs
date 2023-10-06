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

    public IActionResult ApagarConfirmacao(int id)
    {
      UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
      return View(usuario);
    }

    public IActionResult Apagar(int id)
    {
      try
      {
        bool apagado = _usuarioRepositorio.Apagar(id);

        if (apagado)
        {
          TempData["MensagemSucesso"] = "Usuário excluído com sucesso";
        }
        else
        {
          TempData["MensagemErro"] = $"Erro ao excluir, tente novamente";
        }
        return RedirectToAction("Index");
      }
      catch (Exception erro)
      {
        TempData["MensagemErro"] = $"Erro ao excluir, tente novamente - {erro.Message}";
        return RedirectToAction("Index");
      }
    }

    public IActionResult Editar(int id)
    {
      UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
      return View(usuario);
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

    [HttpPost]
    public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenha)
    {
      try
      {
        UsuarioModel usuario = null;

        if (ModelState.IsValid)
        {
          usuario = new UsuarioModel()
          {
            Id = usuarioSemSenha.Id,
            Nome = usuarioSemSenha.Nome,
            Login = usuarioSemSenha.Login,
            Email = usuarioSemSenha.Email,
            Perfil = usuarioSemSenha.Perfil
          };

          usuario = _usuarioRepositorio.Editar(usuario);
          TempData["MensagemSucesso"] = "Usuário alterado com sucesso";
          return RedirectToAction("Index");
        }

        return View(usuario);
      }
      catch (Exception erro)
      {
        TempData["MensagemErro"] = $"Erro ao editar, tente novamente - {erro.Message}";
        return RedirectToAction("Index");
      }
    }
  }
}
