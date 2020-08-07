using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaAplicacionProductos.Servicios;
using CapaDominioProductos.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Producto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService servicio;

        public MarcaController(IMarcaService servicio)
        {
            this.servicio = servicio;
        }
        [Route("InsertarMarca")]
        [HttpPost]
        public IActionResult Post( MarcaDto marca)
        {
            try
            {
                return new JsonResult(servicio.createMarca(marca)) { StatusCode = 201 };

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}