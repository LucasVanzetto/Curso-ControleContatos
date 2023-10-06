using ControleContatos.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
  public class UsuarioSemSenhaModel
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Digite o nome do usuário")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Digite o login do usuário")]
    public string Login { get; set; }

    [Required(ErrorMessage = "Digite o email do usuário")]
    [EmailAddress(ErrorMessage = "E-mail inválido!")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Selecione o perfil do usuário")]
    public PerfilEnum? Perfil { get; set; }
  }
}
