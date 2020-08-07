using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaAplicacionProductos.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Producto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenProductoController : ControllerBase
    {
        private readonly IimagenProductoService servicio;

        public ImagenProductoController(IimagenProductoService servicio)
        {
            this.servicio = servicio;
        }
        [Route("InsertarImagen")]
        [HttpPost]
        
        public IActionResult Post(string nombre)
        {
            try
            {
                return new JsonResult(servicio.createImagenProducto(nombre)) { StatusCode = 201 };

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}