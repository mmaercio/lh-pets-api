using System.ComponentModel.DataAnnotations;

namespace LH_Pets.Models;

public class Cliente
{
    public int Id { get; set; }

    [Required, StringLength(100, MinimumLength = 2)]
    public string Nome { get; set; } = string.Empty;

    [Required, RegularExpression(@"^(\d{11}|\d{3}\.\d{3}\.\d{3}-\d{2})$", ErrorMessage = "Informe o CPF com 11 dígitos, com ou sem pontuação.")]
    public string Cpf { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
}
