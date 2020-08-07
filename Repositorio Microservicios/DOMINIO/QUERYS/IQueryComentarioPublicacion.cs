using DOMINIO.DTOS;
using DOMINIO.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOMINIO.QUERYS
{
    public interface IQueryComentarioPublicacion
    {
        List<ComentariosdePublicacion> GetComentarioPublicaciones();
        ComentariosdePublicacion GetComentarioPublicacionesID(int comentariopublicacionID);
    }
}
