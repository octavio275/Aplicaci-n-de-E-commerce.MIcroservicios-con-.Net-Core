using CapaDominioProductos.Comandos;
using CapaDominioProductos.DTOs;
using CapaDominioProductos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaAplicacionProductos.Servicios
{
    public interface IimagenProductoService
    {
        ImagenProductoDto createImagenProducto(string nombre);
    }
    public class ImagenProductoService : IimagenProductoService
    {
        private readonly IGenericsRepository repository;

        public ImagenProductoService(IGenericsRepository repository)
        {
            this.repository = repository;
        }

        public ImagenProductoDto createImagenProducto(string nombre)
        {
            var entity = new ImagenProducto()
            {
                Nombre = nombre +".jpg" 
            };
             repository.Agregarr<ImagenProducto>(entity);
            return new ImagenProductoDto
            {
                Nombre= nombre + ".jpg"
            };



         }
    }
}
