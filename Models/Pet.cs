using System.ComponentModel.DataAnnotations;

namespace LH_Pets.Models;

public class Pet
{
    public int Id { get; set; }

    [Required, StringLength(100, MinimumLength = 2)]
    public string Nome { get; set; } = string.Empty;

    [Required, StringLength(50)]
    public string Especie { get; set; } = string.Empty;

    [Required, StringLength(80)]
    public string Raca { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int ClienteId { get; set; }
}
