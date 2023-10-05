using ControleContatos.Data;
using ControleContatos.Models;

namespace ControleContatos.Repositorio
{
  public class UsuarioRepositorio : IUsuarioRepositorio
  {
    private readonly BancoContext _bancoContext;

    public UsuarioRepositorio(BancoContext bancoContext)
    {
      _bancoContext = bancoContext;
    }

    public UsuarioModel Adicionar(UsuarioModel usuario)
    {
      usuario.DataCadastro = DateTime.Now;
      _bancoContext.Usuarios.Add(usuario);
      _bancoContext.SaveChanges();

      return usuario;
    }

    public bool Apagar(int id)
    {
      UsuarioModel usuarioDB = ListarPorId(id);

      if (usuarioDB == null) throw new System.Exception("Houve um erro ao tentar excluir o usuário");

      _bancoContext.Usuarios.Remove(usuarioDB);
      _bancoContext.SaveChanges();

      return true;
    }

    public List<UsuarioModel> BuscarTodos()
    {
      return _bancoContext.Usuarios.ToList();
    }

    public UsuarioModel Editar(UsuarioModel usuario)
    {
      UsuarioModel usuarioDB = ListarPorId(usuario.Id);

      if (usuarioDB == null) throw new System.Exception("Houve um erro na edição do usuário");

      usuarioDB.Nome = usuario.Nome;
      usuarioDB.Email = usuario.Email;
      usuarioDB.Login = usuario.Login;
      usuarioDB.Perfil = usuario.Perfil;
      usuarioDB.DataAtualizacao = DateTime.Now;

      _bancoContext.Usuarios.Update(usuarioDB);
      _bancoContext.SaveChanges();

      return usuario;
    }

    public UsuarioModel ListarPorId(int id)
    {
      return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
    }
  }
}
