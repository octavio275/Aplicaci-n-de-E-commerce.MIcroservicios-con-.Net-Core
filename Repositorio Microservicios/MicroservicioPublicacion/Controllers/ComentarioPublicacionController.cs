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
    public class ComentarioPublicacionController : ControllerBase
    {
        private readonly IComentarioPublicacionServicio service;

        public ComentarioPublicacionController(IComentarioPublicacionServicio service)
        {
            this.service = service;
        }
        [Route("InsertarComentarioPublicacion")]
        [HttpPost]
        public IActionResult Post(ComentarioPublicacionDTO comentariopublicacion)
        {
            try
            {
                return new JsonResult(service.CrearComentarioPublicacion(comentariopublicacion)) { StatusCode = 201 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }


        [Route("TraerPublicacionComentarios")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new JsonResult(service.GetComentarioPublicaciones()) { StatusCode = 201 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }


        [Route("TraerPublicacionComentariosID")]
        [HttpGet]
        public IActionResult Get(int comentariopublicacionID)
        {
            try
            {
                return new JsonResult(service.GetComentarioPublicacionesID(comentariopublicacionID)) { StatusCode = 201 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }




    }
}