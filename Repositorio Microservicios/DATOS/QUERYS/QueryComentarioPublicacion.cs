using DOMINIO.ENTIDADES;
using DOMINIO.QUERYS;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using DOMINIO.DTOS;

namespace DATOS.QUERYS
{
    public class QueryComentarioPublicacion : IQueryComentarioPublicacion
    {


        private readonly IDbConnection conexion;
        private readonly Compiler SqlKataCompiler;

        public QueryComentarioPublicacion(IDbConnection conexion, Compiler SqlKataCompiler)
        {
            this.conexion = conexion;
            this.SqlKataCompiler = SqlKataCompiler;
        }

        //acordarse de que la lista de comentarios que sea un string.
        //solo en el caso de que no me devuelva todos los comentarios de una publicacion.
        public List<ComentariosdePublicacion> GetComentarioPublicaciones()
        {
            var db = new QueryFactory(conexion, SqlKataCompiler);
            List<ComentariosdePublicacion> comentariosdePublicacion = new List<ComentariosdePublicacion>();
            var comentariopublicacion = db.Query("ComentarioPublicacion").
                     Select("PublicacionID", "ComentariosID").
                     Get<ComentarioPublicacion>().ToList();
            foreach (ComentarioPublicacion var in comentariopublicacion)
            {
                var Comentarios = db.Query("Comentarios").
                        Select("Comentarios","Id").
                        Where("Id", "=", var.ComentariosID).
                        Get<Comentario>().ToList();
                // acordarse de que no filtra la fecha y me tira esta verga que es null.
                //var Comentario = db.Query("Comentarios").
                //       Select("Fecha").
                //       Where("Id","=",var.ComentariosID).
                //       FirstOrDefault<Comentario>();

                var publicacion = db.Query("Publicaciones").
                       Select("ID").
                       Where("ID", "=", var.PublicacionID).
                       FirstOrDefault<Publicacion>();

                ComentariosdePublicacion objeto = new ComentariosdePublicacion
                {
                    
                    comentarios=Comentarios,
                    publicacionID=publicacion.ID
                };

                comentariosdePublicacion.Add(objeto);


            }
            return comentariosdePublicacion;


        }

        public ComentariosdePublicacion GetComentarioPublicacionesID(int comentariopublicacionID)
        {
            var db = new QueryFactory(conexion, SqlKataCompiler);
            var comentariopublicacion = db.Query("ComentarioPublicacion").
                     Select("PublicacionID", "ComentariosID").
                     Where("ID", "=", comentariopublicacionID).
                     FirstOrDefault<ComentarioPublicacion>();

            var Comentarios = db.Query("Comentarios").
                        Select("Comentarios").
                        Where("ID", "=", comentariopublicacion.ComentariosID).
                        Get<Comentario>().ToList();
            var Comentario = db.Query("Comentarios").
                        Select("Fecha").
                        Where("ID", "=", comentariopublicacion.ComentariosID).
                        FirstOrDefault<Comentario>();

            var publicacion = db.Query("Publicaciones").
                       Select("ID").
                       Where("ID", "=", comentariopublicacion.PublicacionID).
                       FirstOrDefault<Publicacion>();

            ComentariosdePublicacion objeto = new ComentariosdePublicacion
            {
                Fecha=Comentario.Fecha,
                comentarios=Comentarios,
                publicacionID=publicacion.ID
            };
            return objeto;

        }
    }
}
