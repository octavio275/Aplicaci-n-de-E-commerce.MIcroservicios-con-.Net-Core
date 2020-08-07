using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaAplicacionProductos.Servicios;
using CapaDominioProductos.DTOs;
using CapaDominioProductos.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Producto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService service;

        public CategoriasController(ICategoriaService service)
        {
            this.service = service;
        }
        [Route("InsertarCategoria")]
        [HttpPost]
        public IActionResult Post(string Descripcion)
        {
            try
            {
                return new JsonResult(service.createCategoria(Descripcion)) { StatusCode = 201 };

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("ActualizarCategoria")]
        [HttpPut]
        public IActionResult Put(Categoria categoria)
        {
            try
            {
                return new JsonResult(service.actualizarCategoria(categoria)) { StatusCode = 201 };

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}