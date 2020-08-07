using DOMINIO.COMANDOS;
using DOMINIO.DTOS;
using DOMINIO.ENTIDADES;
using DOMINIO.QUERYS;
using System;
using System.Collections.Generic;
using System.Text;

namespace APLICACION.SERVICIOS
{
    public interface IComentarioPublicacionServicio
    {
        ComentarioPublicacion CrearComentarioPublicacion(ComentarioPublicacionDTO comentariopublicacion);
        List<ComentariosdePublicacion> GetComentarioPublicaciones();
        ComentariosdePublicacion GetComentarioPublicacionesID(int comentariopublicacionID);
    }



    public class ComentarioPublicacionServicio : IComentarioPublicacionServicio
    {

        private readonly IGenericsRepository repository;
        private readonly IQueryComentarioPublicacion query;


        public ComentarioPublicacionServicio(IGenericsRepository repository, IQueryComentarioPublicacion query)
        {
            this.repository = repository;
            this.query = query;
        }
        public ComentarioPublicacion CrearComentarioPublicacion(ComentarioPublicacionDTO comentariopublicacion)
        {
            ComentarioPublicacion ComentarioPublicacion = new ComentarioPublicacion
            {
                ComentariosID = comentariopublicacion.ComentariosID,
                PublicacionID= comentariopublicacion.PublicacionID
            };
            return repository.Agregar<ComentarioPublicacion>(ComentarioPublicacion);
        }

        public List<ComentariosdePublicacion> GetComentarioPublicaciones()
        {
            return query.GetComentarioPublicaciones();
        }

        public ComentariosdePublicacion GetComentarioPublicacionesID(int comentariopublicacionID)
        {
            return query.GetComentarioPublicacionesID(comentariopublicacionID);
        }
    }
}
