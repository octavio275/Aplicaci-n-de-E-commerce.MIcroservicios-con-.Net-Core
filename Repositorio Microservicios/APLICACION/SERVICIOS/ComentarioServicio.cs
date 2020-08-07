using DOMINIO.COMANDOS;
using DOMINIO.DTOS;
using DOMINIO.ENTIDADES;
using DOMINIO.QUERYS;
using System;
using System.Collections.Generic;
using System.Text;

namespace APLICACION.SERVICIOS
{
    public interface IComentarioServicio 
    {
        Comentario CrearComentario(string comentario);
        List<Comentario> GetComentario();
        Comentario GetComentarioID(int comentarioID);

        public ComentarioPublicacion InsertarComentarioPublicacion(PublicacionComentarioDto publicacioncomentario);
    }
    public class ComentarioServicio : IComentarioServicio
    {
        private readonly IGenericsRepository repository;
        private readonly IQueryComentario query;


        public ComentarioServicio(IGenericsRepository repository, IQueryComentario query)
        {
            this.repository = repository;
            this.query = query;
        }
        public Comentario CrearComentario(string comentario)
        {
            Comentario nuevocomentario = new Comentario
            {
                Comentarios=comentario,
                Fecha=DateTime.Now
            };
            return repository.Agregar<Comentario>(nuevocomentario);
        }

        public List<Comentario> GetComentario()
        {
            return query.GetComentario();
        }

        public Comentario GetComentarioID(int comentarioID)
        {
            return query.GetComentarioID(comentarioID);
        }

        public ComentarioPublicacion InsertarComentarioPublicacion(PublicacionComentarioDto publicacioncomentario)
        {
            return query.InsertarComentarioPublicacion(publicacioncomentario);
        }
    }
}
