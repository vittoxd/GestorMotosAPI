using Microsoft.AspNetCore.Mvc;
using GestorMotosAPI.Models; // ¡Vital! Le dice al controlador dónde está tu clase Moto

namespace GestorMotosAPI.Controllers
{
    // Esta línea define la URL de internet. Quedará como: tusitio.com/api/Motos
    [Route("api/[controller]")]
    [ApiController]
    public class MotosController : ControllerBase
    {
        // 1. Nuestra "Base de datos" temporal (Una lista de C#)
        private static List<Moto> _baseDatosMotos = new List<Moto>
        {
            new Moto { Id = 1, Marca = "Yamaha", Modelo = "MT-07", Año = 2021, Kilometraje = 15000 },
            new Moto { Id = 2, Marca = "Honda", Modelo = "CB500F", Año = 2023, Kilometraje = 5000 }
        };

        // 2. El método que responde cuando alguien pide ver las motos
        [HttpGet] // Significa "Petición para LEER datos"
        public ActionResult<IEnumerable<Moto>> ObtenerMotos()
        {
            // El recepcionista simplemente devuelve la lista completa con un mensaje de "Todo OK" (Código 200)
            return Ok(_baseDatosMotos);
        }
    }
}