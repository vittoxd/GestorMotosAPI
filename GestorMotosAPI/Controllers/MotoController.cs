using GestorMotosAPI.Data;
using GestorMotosAPI.Models; // ¡Vital! Le dice al controlador dónde está tu clase Moto
using Microsoft.AspNetCore.Mvc;

namespace GestorMotosAPI.Controllers
{
    // Esta línea define la URL de internet. Quedará como: tusitio.com/api/Motos
    [Route("api/[controller]")]
    [ApiController]
    public class MotosController : ControllerBase
    {
        // 1. Nuestra "Base de datos" temporal (Una lista de C#)
        private readonly AppDbContext _context;
        public MotosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Moto>> ObtenerMotos()
        {
            // Traemos la lista directamente del SSD
            return Ok(_context.Motos.ToList());
        }

        // 2. El método que responde cuando alguien pide ver las motos
        [HttpPost] // Significa "Petición para LEER datos"
        public ActionResult AgregarMoto([FromBody] Moto nuevaMoto)
        {
            // A. Añadimos la moto al archivador en memoria
            _context.Motos.Add(nuevaMoto);

            // B. ¡CLAVE! Guardamos los cambios físicamente en el taller.db
            _context.SaveChanges();

            return Ok("¡Moto guardada con éxito en el SSD!");
        }
        [HttpDelete("{id}")] // El {id} en la URL indica qué moto queremos borrar
        public ActionResult BorrarMoto(int id)
        {
            // A. Buscamos la moto en la base de datos por su ID
            var motoParaBorrar = _context.Motos.Find(id);

            // B. Si la moto no existe, avisamos al usuario (Error 404)
            if (motoParaBorrar == null)
            {
                return NotFound($"Lo siento, la moto con ID {id} no existe en el taller.");
            }

            // C. Si existe, la eliminamos del archivador
            _context.Motos.Remove(motoParaBorrar);

            // D. ¡IMPORTANTE! Guardamos el cambio en el SSD
            _context.SaveChanges();

            return Ok($"La moto {motoParaBorrar.Modelo} ha sido eliminada con éxito.");
        }
        [HttpPut("{id}")]
        public ActionResult editarmoto (int id , [FromBody] Moto motoActualizada)
        {
            var motoEnDB = _context.Motos.Find(id);
            if (motoEnDB == null)
            {
                return NotFound($"No se encontró una moto con el ID {id}");
            }
            motoEnDB.Marca = motoActualizada.Marca;
            motoEnDB.Modelo = motoActualizada.Modelo;
            motoEnDB.Año = motoActualizada.Año;
            motoEnDB.Kilometraje = motoActualizada.Kilometraje;
            _context.SaveChanges(); 
            
            return Ok("¡Moto actualizada con éxito!");
        }
    }
}