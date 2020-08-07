using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicioUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticacionController : ControllerBase
    {
        private readonly IAuthenticacionService _service;

        public AuthenticacionController(IAuthenticacionService service)
        {
            _service = service;
        }
        //----------------validar con token de usuario-----------------------------//
       
        [HttpGet("[action]")]
        public IActionResult getCliente([FromQuery] string uids)
        {
            
                return new JsonResult(_service.getCarrito(uids).Result);
        

        }
        [Authorize]
        [HttpGet("[action]")]
        public IActionResult getClienteAdmin([FromQuery] string uids)
        {
            try
            {

                return new JsonResult(_service.getCarrito(uids).Result) { StatusCode = 200 };
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }

        }

    }
}
