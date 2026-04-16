using GestorMotosAPI.Data;
using GestorMotosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace GestorMotosAPI.Controllers
{   [ApiController]
    [Route("api/[controller]")]
    public class OrdenesTrabajoController : ControllerBase 
    {
        private readonly AppDbContext _context;
        public OrdenesTrabajoController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public ActionResult CrearOrden([FromBody] OrdenTrabajo nuevaOrden)
        {
            var motoExiste = _context.Motos.Any(m => m.Id == nuevaOrden.MotoId);

            var mecanicoExiste = _context.Mecanicos.Any(m => m.Id == nuevaOrden.MecanicoId);
            if (!motoExiste || !mecanicoExiste)
            {
                return BadRequest("Error: La moto o el mecánico no existen en el sistema.");

            }

            _context.OrdenesTrabajo.Add(nuevaOrden);
            _context.SaveChanges();

            return Ok("¡Orden de trabajo creada con éxito!");
        }
        [HttpGet]
        public ActionResult VerOrdenes()
        {
            var lista = _context.OrdenesTrabajo
            .Include(o => o.moto)
            .Include(o => o.mecanico)
            .ToList();



            return Ok(lista);
        }
    }
}
