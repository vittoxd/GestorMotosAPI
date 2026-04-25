using System.ComponentModel.DataAnnotations;

namespace GestorMotosAPI.Models
{
    public class Mecanico
    {
        public int Id { get; set; }

        [Required]
        public string Rut { get; set; } = string.Empty;

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Especialidad { get; set; } = string.Empty;

        [Required]
        public string Telefono { get; set; } = string.Empty;
    }
}