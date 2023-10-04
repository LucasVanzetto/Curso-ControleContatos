using ControleContatos.Models;
using ControleContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleContatos.Controllers
{
  public class ContatoController : Controller
  {
    private readonly IContatoRepositorio _contatoRepositorio;

    public ContatoController(IContatoRepositorio contatoRepositorio)
    {
      _contatoRepositorio = contatoRepositorio;
    }

    public IActionResult Index()
    {
      List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
      return View(contatos);
    }

    public IActionResult Criar()
    {
      return View();
    }

    public IActionResult Editar(int id)
    {
      ContatoModel contato = _contatoRepositorio.ListarPorId(id);
      return View(contato);
    }

    public IActionResult ApagarConfirmacao(int id)
    {
      ContatoModel contato = _contatoRepositorio.ListarPorId(id);
      return View(contato);
    }

    public IActionResult Apagar(int id)
    {
      try
      {
        bool apagado = _contatoRepositorio.Apagar(id);

        if (apagado)
        {
          TempData["MensagemSucesso"] = "Cadastro excluído com sucesso";
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

    [HttpPost]
    public IActionResult Criar(ContatoModel contato)
    {
      try
      {
        if (ModelState.IsValid)
        {
          _contatoRepositorio.Adicionar(contato);
          TempData["MensagemSucesso"] = "Cadastro concluído com sucesso";
          return RedirectToAction("Index");
        }

        return View(contato);
      }
      catch (Exception erro) 
      {
        TempData["MensagemErro"] = $"Erro ao cadastrar, tente novamente - {erro.Message}";
        return RedirectToAction("Index");
      }
    }

    [HttpPost]
    public IActionResult Editar(ContatoModel contato)
    {
      try
      {
        if (ModelState.IsValid)
        {
          _contatoRepositorio.Editar(contato);
          TempData["MensagemSucesso"] = "Cadastro alterado com sucesso";
          return RedirectToAction("Index");
        }

        return View(contato);
      }
      catch (Exception erro)
      {
        TempData["MensagemErro"] = $"Erro ao editar, tente novamente - {erro.Message}";
        return RedirectToAction("Index");
      }
    }
  }
}
