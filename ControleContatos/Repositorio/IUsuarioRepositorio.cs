﻿using ControleContatos.Models;

namespace ControleContatos.Repositorio
{
  public interface IUsuarioRepositorio
  {
    UsuarioModel ListarPorId(int id);
    List<UsuarioModel> BuscarTodos();
    UsuarioModel Adicionar(UsuarioModel usuario);
    UsuarioModel Editar(UsuarioModel usuario);
    bool Apagar(int id);
  }
}
