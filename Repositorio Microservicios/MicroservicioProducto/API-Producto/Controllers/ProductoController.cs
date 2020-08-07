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
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService servicio;


        public ProductoController(IProductoService servicio)
        {
            this.servicio = servicio;
        }
        [Route ("InsertarProducto")]
        [HttpPost]
        public IActionResult Post(ProductoDto productoDto)
        {
            try
            {
                return new  JsonResult(servicio.createProducto(productoDto)) { StatusCode = 201};

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }        
        }

       [Route("FiltroPrecio")]
        [HttpGet]
        public IActionResult GETSearchPrice(int precio)
        {
            try
            {
                return new JsonResult(servicio.BusquedaProducto(precio)) { StatusCode = 200 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        
        [Route("TraerProductos")]
        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                return new JsonResult(servicio.GetAllProducto()) { StatusCode = 200 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }
        [Route("BorrarProducto")]
        [HttpDelete]
        public IActionResult DeleteProducto(int id)
        {
            try
            {
                return new JsonResult(servicio.EliminarProducto(id)) { StatusCode = 200 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }




        [Route("TraerProductosID")]
        [HttpGet]
        public IActionResult GetProductsID(int publicacionID)
        {
            try
            {
                return new JsonResult(servicio.GetProductoID(publicacionID)) { StatusCode = 201 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }




        //acordarse de terminar las llamadas y la logica.

        [Route("ProductosID")]
        [HttpPost]
        public IActionResult GetProductosID(JsonProductoDTO json)
        {
            try
            {
                return new JsonResult(servicio.GetProductosID(json)) { StatusCode = 201 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }


        [Route("ProductosPublicacionesFiltro")]
        [HttpPost]
        public IActionResult ProductosPublicacionFiltro(JsonProductoFiltroDto json)
        {
            try
            {
                return new JsonResult(servicio.ProductosPublicacionFiltro(json)) { StatusCode = 201 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }



        [Route("ProductosPublicacionesFiltroDescripcion")]
        [HttpPost]
        public IActionResult ProductosPublicacionesFiltroDescripcion(JsonProductoFiltroDto json)
        {
            try
            {
                return new JsonResult(servicio.ProductosPublicacionesFiltroDescripcion(json)) { StatusCode = 201 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }


        [Route("ProductosPublicacionesFiltroCategoria")]
        [HttpPost]
        public IActionResult ProductosPublicacionesFiltroCategoria(JsonProductoFiltroDto json)
        {
            try
            {
                return new JsonResult(servicio.ProductosPublicacionesFiltroCategoria(json)) { StatusCode = 201 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }


        [Route("ProductosValorCarritoCliente")]
        [HttpPost]
        public IActionResult ProductosValorCarritoCliente(ValorCarritoDTO valor)
        {
            try
            {
                return new JsonResult(servicio.ProductosValorCarritoCliente(valor)) { StatusCode = 201 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }


        [Route("InsertarProductoPanel")]
        [HttpPost]
        public IActionResult InsertarProductoPanel(InsertoProductoPanelDto producto)
        {

            return new JsonResult(servicio.InsertarProductoPanel(producto).Result);

            
           
        }



    }
}