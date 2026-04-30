using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GestorMotosAPI.Models
{
    [Index(nameof(Patente),IsUnique = true)]
    [Index(nameof(RutDueno))]
    public class Moto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(8)]
        public string Patente { get; set; } = string.Empty;

        [Required(ErrorMessage = "La marca es obligatoria")]
        public string Marca { get; set; } = string.Empty;

        [Required(ErrorMessage = "El modelo es obligatorio")]
        public string Modelo { get; set; } = string.Empty;

        public int Año { get; set; }

        public int Kilometraje { get; set; }

        public string RutDueno { get; set; } = string.Empty;

    }
}