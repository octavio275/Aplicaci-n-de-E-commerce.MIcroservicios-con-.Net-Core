using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APLICACION.SERVICIOS;
using DOMINIO.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicioPublicacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioServicio service;

        public ComentarioController(IComentarioServicio service)
        {
            this.service = service;
        }
        [Route("InsertarComentario")]
        [HttpPost]
        public IActionResult Post(string comentario)
        {
            try
            {
                return new JsonResult(service.CrearComentario(comentario)) { StatusCode = 201 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }





        [Route("TraerComentarios")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new JsonResult(service.GetComentario()) { StatusCode = 201 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }


        [Route("TraerComentariosID")]
        [HttpGet]
        public IActionResult Get(int comentarioID)
        {
            try
            {
                return new JsonResult(service.GetComentarioID(comentarioID)) { StatusCode = 201 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }
        //consumir al oprimir el agregar comentario.
        [Route("InsertarComentarioPublicacion")]
        [HttpPost]
        public IActionResult InsertarComentarioPublicacion(PublicacionComentarioDto publicacioncomentario)
        {
            try
            {
                return new JsonResult(service.InsertarComentarioPublicacion(publicacioncomentario)) { StatusCode = 200 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }




    }
}