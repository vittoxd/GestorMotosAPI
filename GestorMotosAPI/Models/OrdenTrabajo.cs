using System.ComponentModel.DataAnnotations;

namespace GestorMotosAPI.Models
{
    public class OrdenTrabajo
    {
        [Key]
        public int Id {  get; set; }
        public DateTime fecha {  get; set; } = DateTime.Now;
        public string Descripcion { get; set; } = string.Empty;

        public string Estado { get; set; } = "En Espera";
        public decimal costo { get; set; }

        public int MotoId { get; set; }
        public Moto? moto { get; set; }

        public int MecanicoId { get; set; }
        public Mecanico? mecanico { get; set; }
    }
}
