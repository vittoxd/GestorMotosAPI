using GestorMotosAPI.Data;
using GestorMotosAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace GestorMotosAPI.Controllers
{
    [Route("api/Mecanicos")] // 👈 Usa una ruta fija para evitar líos
    [ApiController]
    public class MecanicosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MecanicosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Mecanicos (Trae la lista)
        [HttpGet]
        public ActionResult<IEnumerable<Mecanico>> ObtenerMecanicos()
        {
            return Ok(_context.Mecanicos.ToList());
        }

        // GET: api/Mecanicos/5 (Trae uno solo)
        [HttpGet("{id}")]
        public ActionResult<Mecanico> ObtenerMecanico(int id)
        {
            var mecanico = _context.Mecanicos.Find(id);
            if (mecanico == null) return NotFound();
            return Ok(mecanico);
        }

        // POST: api/Mecanicos (Registra uno nuevo)
        [HttpPost]
        public ActionResult AgregarMecanico([FromBody] Mecanico nuevoMecanico)
        {
            _context.Mecanicos.Add(nuevoMecanico);
            _context.SaveChanges();
            return Ok(nuevoMecanico); // 👈 Devuelve el objeto para que el JS sea feliz
        }

        // PUT: api/Mecanicos/5 (Edita uno existente)
        [HttpPut("{id}")]
        public ActionResult EditarMecanico(int id, [FromBody] Mecanico mecanicoActualizado)
        {
            var mecanicoEnDB = _context.Mecanicos.Find(id);
            if (mecanicoEnDB == null) return NotFound();

            mecanicoEnDB.Rut = mecanicoActualizado.Rut;
            mecanicoEnDB.Nombre = mecanicoActualizado.Nombre;
            mecanicoEnDB.Especialidad = mecanicoActualizado.Especialidad;
            mecanicoEnDB.Telefono = mecanicoActualizado.Telefono;

            _context.SaveChanges();
            return Ok("Mecánico actualizado con éxito");
        }

        // DELETE: api/Mecanicos/5 (Borra uno)
        [HttpDelete("{id}")]
        public ActionResult BorrarMecanico(int id)
        {
            var mecanico = _context.Mecanicos.Find(id);
            if (mecanico == null) return NotFound();

            _context.Mecanicos.Remove(mecanico);
            _context.SaveChanges();
            return Ok($"El mecánico {mecanico.Nombre} ha sido eliminado.");
        }
    }

}


