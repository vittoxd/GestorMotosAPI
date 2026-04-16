using Microsoft.EntityFrameworkCore;
using GestorMotosAPI.Models; // Para que reconozca a Moto y Mecanico

namespace GestorMotosAPI.Data
{
    // Heredamos de DbContext: esta es la clase maestra de Entity Framework
    public class AppDbContext : DbContext
    {
        // El constructor: recibe la configuración (como la ruta del archivo .db)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Un DbSet representa una TABLA en la base de datos.
        // Aquí le decimos: "Crea una tabla llamada 'Motos' basada en mi modelo 'Moto'".
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Mecanico> Mecanicos { get; set; }
    }
}