using GestorMotosAPI.Data;
using GestorMotosAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace GestorMotosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MecanicosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MecanicosController(AppDbContext context)
        { _context = context; }
        [HttpGet]
        public ActionResult<IEnumerable<Mecanico>> ObtenerMecanicos()
        {
            return Ok(_context.Mecanicos.ToList());
        }
        [HttpPost]
        public ActionResult AgregarMecanico([FromBody] Mecanico nuevoMecanico)
        {
            // 1. Agregamos el mecánico al archivador de la BD
            _context.Mecanicos.Add(nuevoMecanico);

            // 2. ¡IMPORTANTE! Esto le dice a la BD: "Guarda los cambios físicamente en el SSD"
            _context.SaveChanges();

            return Ok($"Mecánico {nuevoMecanico.Nombre} guardado para siempre en la base de datos!");
        }
        [HttpDelete("{id}")]
        public ActionResult BorrarMecanicos(int id)
        {
            var mecanico = _context.Mecanicos.Find(id);
            if (mecanico == null)
            {
                return NotFound($"Lo siento, el mecánico con ID {id} no existe.");
          
            }
            _context.Mecanicos.Remove(mecanico);
            _context.SaveChanges();

            return Ok($"El Mecanico {mecanico.Nombre} ha sido eliminada con éxito.");
        }
        [HttpPut("{id}")]
        public ActionResult Editarmecanico(int id, [FromBody]  Mecanico mecanicoActualizado)
        {
            var mecanicoEnDB = _context.Mecanicos.Find(id);
            if (mecanicoEnDB == null)
            {
                return NotFound($"no se encontro mecanico con esa id {id}");
            }
            mecanicoEnDB.Rut = mecanicoActualizado.Rut;
            mecanicoEnDB.Nombre = mecanicoActualizado.Nombre;
            mecanicoEnDB.Especialidad = mecanicoActualizado.Especialidad;
            mecanicoEnDB.Telefono = mecanicoActualizado.Telefono;

            _context.SaveChanges();
            return Ok("Mecanico actualizado con exito");
        }       
        

    }   

}


