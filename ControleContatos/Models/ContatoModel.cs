using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
  public class ContatoModel
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    [EmailAddress(ErrorMessage = "E-mail inválido!")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    [Phone(ErrorMessage = "Telefone inválido!")]
    public string Telefone { get; set; }
  }
}
