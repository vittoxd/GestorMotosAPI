using System.ComponentModel.DataAnnotations;

namespace GestorMotosAPI.Models
{
    public class Moto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria")]
        public string Marca { get; set; } = string.Empty;

        [Required(ErrorMessage = "El modelo es obligatorio")]
        public string Modelo { get; set; } = string.Empty;

        public int Año { get; set; }

        public int Kilometraje { get; set; }
    }
}