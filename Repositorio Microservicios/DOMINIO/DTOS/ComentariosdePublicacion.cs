using DOMINIO.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOMINIO.DTOS
{
   public class ComentariosdePublicacion
    {
        public int publicacionID { get; set; }

        public DateTime Fecha { get; set; }
        //cambiar la lista de comentarios por una lista de string.
        public List<Comentario> comentarios { get; set; }

    }
}
