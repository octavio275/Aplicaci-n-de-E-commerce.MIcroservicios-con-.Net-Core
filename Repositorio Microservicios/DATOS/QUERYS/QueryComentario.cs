using DOMINIO.ENTIDADES;
using DOMINIO.QUERYS;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using SqlKata.Execution;
using DOMINIO.COMANDOS;
using DOMINIO.DTOS;

namespace DATOS.QUERYS
{
    public class QueryComentario : IQueryComentario
    {
        private readonly IDbConnection conexion;
        private readonly Compiler SqlKataCompiler;
        private readonly IGenericsRepository repository;

        public QueryComentario(IDbConnection conexion, Compiler SqlKataCompiler, IGenericsRepository repository)
        {
            this.conexion = conexion;
            this.SqlKataCompiler = SqlKataCompiler;
            this.repository = repository;
        }
        public Comentario GetComentarioID(int comentarioID)
        {
            var db = new QueryFactory(conexion, SqlKataCompiler);
            var comentario = db.Query("Comentarios").
               Select("Comentarios", "Fecha").
               Where("ID", "=", comentarioID).
               FirstOrDefault<Comentario>();

            return comentario;

        }

        public List<Comentario> GetComentario()
        {
            var db = new QueryFactory(conexion, SqlKataCompiler);
            var comentario = db.Query("Comentarios").
               Select("Comentarios", "Fecha").Get<Comentario>().ToList();

            return comentario;
        }

        public ComentarioPublicacion InsertarComentarioPublicacion(PublicacionComentarioDto publicacioncomentario)
        {
            var db = new QueryFactory(conexion, SqlKataCompiler);
            Comentario comentario = new Comentario()
            {
                Fecha=DateTime.Today,
                Comentarios=publicacioncomentario.comentario
            };
            repository.Agregar<Comentario>(comentario);
            var comentarioID = db.Query("Comentarios").
            Select("Id").Where("Comentarios", "=", publicacioncomentario.comentario).FirstOrDefault<Comentario>();

            ComentarioPublicacion ComentarioPublicacion = new ComentarioPublicacion
            {
                ComentariosID = comentarioID.Id,
                PublicacionID = publicacioncomentario.publicacionID
            };

            return repository.Agregar<ComentarioPublicacion>(ComentarioPublicacion);

        }
    }
}
