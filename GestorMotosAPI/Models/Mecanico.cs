using System.ComponentModel.DataAnnotations;

namespace GestorMotosAPI.Models
{
    public class Mecanico
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;
        [MinLength(3)]
        public string Especialidad {  get; set; } = string.Empty;
        [Range(0, 60, ErrorMessage = "¡eres un dinosaurio o que?!")]
        public int AniosExperiencia { get; set; } 

    }

}