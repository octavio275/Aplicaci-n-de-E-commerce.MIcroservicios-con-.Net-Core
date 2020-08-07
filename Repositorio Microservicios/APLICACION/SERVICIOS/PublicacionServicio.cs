using DOMINIO.COMANDOS;
using DOMINIO.DTOS;
using DOMINIO.ENTIDADES;
using DOMINIO.QUERYS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using DATOS;

namespace APLICACION.SERVICIOS
{

    public interface IPublicacionServicio 
    {

       Publicacion CrearPublicacion(InsertarPublicacionDto objeto);
        List<Publicacion> GetPublicaciones();
        Publicacion GetPublicacionesID(int publicacionID);
        Task<ProductoEspecificoDto> GetProductoID(int publicacionID);

        public List<string> PaginacionComentarios(PaginacionComentarioDto json);

        Task<List<ProductoEspecificoDto>> ProductosPublicacionFiltro(string filtro);

        Task<List<ProductoEspecificoDto>> ProductosPublicacionFiltroDescripcion(string filtro);

        Task<List<ProductoEspecificoDto>> ProductosPublicacionFiltroCategoria(string filtro);
        Task<List<ProductoEspecificoDto>> getProductosPublicacioens(int CANTIDAD);

        public Task<productoYcomentariosDTO> ProductoYcomentariosDePublicacion(int publicacionID, int offset);

        public Task<List<ProductoEspecificoDto>>TraerProductosPublicacionesPanel();

        public bool BorrarPublicacion(int publicacionID);
    }
    public class PublicacionServicio : IPublicacionServicio
    {

        private readonly IGenericsRepository repository;
        private readonly IQueryPublicacion query;
        private readonly Contexto contexto;

        public PublicacionServicio(IGenericsRepository repository, IQueryPublicacion query,Contexto contexto)
        {
            this.repository = repository;
            this.query = query;
            this.contexto = contexto;
        }

        public bool BorrarPublicacion(int publicacionID)
        {
            bool respuesta = false;
            var publicacion = (from x in contexto.Publicaciones where x.ID == publicacionID select x).FirstOrDefault<Publicacion>();
            if (publicacion!=null) 
            {
                repository.Delete<Publicacion>(publicacion);
                respuesta = true;

            }
            return respuesta;

        }

        public Publicacion CrearPublicacion(InsertarPublicacionDto objeto)
        {
            Publicacion publicacion = new Publicacion
            {
                ProductoID = objeto.productoID
            };
            return repository.Agregar<Publicacion>(publicacion);
        }

        public Task<ProductoEspecificoDto> GetProductoID(int publicacionID)
        {
            return query.GetProducto(publicacionID);
        }

        public Task<List<ProductoEspecificoDto>> getProductosPublicacioens(int CANTIDAD)
        {
            return query.getProductosPublicaciones(CANTIDAD);
        }

       

        public List<Publicacion> GetPublicaciones()
        {
            return query.GetPublicaciones();
        }

        public Publicacion GetPublicacionesID(int publicacionID)
        {
            return query.GetPublicacionesID(publicacionID);
        }

        public List<string> PaginacionComentarios(PaginacionComentarioDto json)
        {
            return query.PaginacionComentarios(json);
        }

        public Task<List<ProductoEspecificoDto>> ProductosPublicacionFiltro(string filtro)
        {
            return query.ProductosPublicacionFiltro(filtro);
        }

        public Task<List<ProductoEspecificoDto>> ProductosPublicacionFiltroCategoria(string filtro)
        {
            return query.ProductosPublicacionFiltroCategoria(filtro);
        }

        public Task<List<ProductoEspecificoDto>> ProductosPublicacionFiltroDescripcion(string filtro)
        {
            return query.ProductosPublicacionFiltroDescripcion(filtro);
        }

        public Task<productoYcomentariosDTO> ProductoYcomentariosDePublicacion(int publicacionID, int offset)
        {
            return query.ProductoYcomentariosDePublicacion(publicacionID,offset);
        }

        public Task<List<ProductoEspecificoDto>> TraerProductosPublicacionesPanel()
        {
            return query.TraerProductosPublicacionesPanel();
        }
    }
}
