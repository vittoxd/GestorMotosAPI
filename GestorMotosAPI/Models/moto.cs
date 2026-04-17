namespace GestorMotosAPI.Models;

using System.ComponentModel.DataAnnotations;

public class Moto
{
    // El 'Id' es como el RUT de la moto, único para cada una.
    public int Id { get; set; }

    // 'string' es texto (como 'str' en Python)
    [Required]
    [StringLength(50)]
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;

    // 'int' es un número entero (año y kilometraje no tienen decimales)
    [Range(1900, 2027, ErrorMessage = "¡Oye! Esa moto es muy vieja o viene del futuro")]
    public int Año { get; set; }
    [Range(0, 999999)]
    public int Kilometraje { get; set; }
}