﻿using ControleContatos.Models;

namespace ControleContatos.Repositorio
{
  public interface IContatoRepositorio
  {
    ContatoModel ListarPorId(int id);
    List<ContatoModel> BuscarTodos();
    ContatoModel Adicionar(ContatoModel contato);
    ContatoModel Editar(ContatoModel contato);
    bool Apagar(int id);
  }
}
