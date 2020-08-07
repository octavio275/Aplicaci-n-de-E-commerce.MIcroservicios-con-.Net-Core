using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaAplicacion.SERVICIOS;
using CapaDominio.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicioCarrito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoProductoController : ControllerBase
    {
        private readonly ICarritoProductoServicio servicio;

        [Route("InsertarCarritoProductoCliente")]
        [HttpPost]
        public IActionResult InsertarCarritoProductoCliente(int carritoID, int productoID)
        {
            try
            {
                return new JsonResult(servicio.InsertarCarritoProductoCliente(carritoID,productoID)) { StatusCode = 200 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }


        [Route("InsertarCarritoProductoCantidad")]
        [HttpPost]
        public IActionResult InsertarCarritoProductoCantidad(PublicacionCarritoDto objeto)
        {
            try
            {
                return new JsonResult(servicio.InsertarCarritoProductoCantidad(objeto)) { StatusCode = 200 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }




        public CarritoProductoController(ICarritoProductoServicio servicio)
        {
            this.servicio = servicio;

        }
    }
}
