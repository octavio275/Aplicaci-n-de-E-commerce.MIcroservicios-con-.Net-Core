using DOMINIO.DTOS;
using DOMINIO.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOMINIO.QUERYS
{
    public interface IQueryComentario
    {


        List<Comentario> GetComentario();
        Comentario GetComentarioID(int comentarioID);
        public ComentarioPublicacion InsertarComentarioPublicacion(PublicacionComentarioDto publicacioncomentario);


    }
}
