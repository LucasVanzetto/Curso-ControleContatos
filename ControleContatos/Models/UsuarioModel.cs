using ControleContatos.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
  public class UsuarioModel
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Digite o nome de usuário")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Digite o nome de login")]
    public string Login { get; set; }

    [Required(ErrorMessage = "Digite o nome de e-mail")]
    [EmailAddress(ErrorMessage = "E-mail inválido!")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Digite o nome de senha")]
    public string Senha { get; set; }
    public PerfilEnum Perfil { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataAtualizacao { get; set; }
  }
}
