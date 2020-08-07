using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaAplicacion.SERVICIOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicioCarrito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoServicio servicio;

        //esto inserta
        [Route("InsertarCarritoCliente")]
        [HttpPost]
        public IActionResult InsertarCarritoCliente(int clienteID)
        {
            try
            {
                return new JsonResult(servicio.InsertarCarritoCliente(clienteID)) { StatusCode = 201};

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }




       //esto devuelve el valor del carrito y los productos.

        [Route("ProductosValorCarritoCliente")]
        [HttpGet]
        public IActionResult ProductosCarritoCliente(int clienteID)
        {

            return new JsonResult(servicio.ProductosValorCarritoCliente(clienteID).Result);

        }

        //esta api consume maty

        [Route("VerificarClienteCarrito")]
        [HttpGet]
        public IActionResult VerificarClienteCarrito(int clienteID)
        {
            try
            {
                return new JsonResult(servicio.VerificarClienteCarrito(clienteID)) { StatusCode = 200 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }


        

        [Route("BorrarProductoCarrito")]
        [HttpGet]
        public IActionResult BorrarProductoCarrito(int productoID, int carritoID)
        {
            try
            {
                return new JsonResult(servicio.BorrarProductoCarrito(productoID, carritoID)) { StatusCode = 200 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [Route("BorrarCarritoCompleto")]
        [HttpGet]
        public IActionResult BorrarCarritoCompleto(int carritoID)
        {
            try
            {
                return new JsonResult(servicio.BorrarCarritoCompleto(carritoID)) { StatusCode = 200 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }



        public CarritoController(ICarritoServicio servicio)
        {
            this.servicio = servicio;

        }
    }
}
