using GestorMotosAPI.Data;
using GestorMotosAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestorMotosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MecanicosController :  ControllerBase
    {
        private readonly AppDbContext _context;
        public MecanicosController(AppDbContext context)
        {  _context = context; }
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
    }

}
