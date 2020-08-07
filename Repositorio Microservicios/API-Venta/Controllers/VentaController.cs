using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaDeAplicacion.Services;
using CapaDeDominio.Commands;
using CapaDeDominio.DTOs;
using CapaDeDominio.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Venta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _servicio;
        public VentaController(IVentaService servicio)
        {
            _servicio = servicio;
        }


        [Route("InsertarVenta")]
        [HttpPost]
        public IActionResult InsertarCarritoCliente(int carritoID)
        {
            try
            {
                return new JsonResult(_servicio.InsertarVenta(carritoID)) { StatusCode = 201 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }






    }
}
