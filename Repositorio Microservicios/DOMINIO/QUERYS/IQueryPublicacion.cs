using DOMINIO.DTOS;
using DOMINIO.ENTIDADES;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO.QUERYS
{
    public interface IQueryPublicacion
    {
        List<Publicacion> GetPublicaciones();
        Publicacion GetPublicacionesID(int publicacionID);

        

        Task<ProductoEspecificoDto> GetProducto(int publicacionID);


        Task<List<ProductoEspecificoDto>> getProductosPublicaciones(int CANTIDAD);

        public List<string> PaginacionComentarios(PaginacionComentarioDto json);

        Task<List<ProductoEspecificoDto>> ProductosPublicacionFiltro(string filtro);
        public Task<productoYcomentariosDTO> ProductoYcomentariosDePublicacion(int publicacionID, int offset);

        public Task<List<ProductoEspecificoDto>> ProductosPublicacionFiltroDescripcion(string filtro);
        public Task<List<ProductoEspecificoDto>> ProductosPublicacionFiltroCategoria(string filtro);

        public Task<List<ProductoEspecificoDto>> TraerProductosPublicacionesPanel();

    }
}
