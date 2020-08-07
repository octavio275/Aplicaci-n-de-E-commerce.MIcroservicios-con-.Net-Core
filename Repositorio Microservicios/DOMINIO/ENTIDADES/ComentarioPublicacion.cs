using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DOMINIO.ENTIDADES
{
    public class ComentarioPublicacion
    {
        [Key]
        private int id;
        private int comentariosID;
        private int publicacionID;

        public int Id { get => id; set => id = value; }
        public int ComentariosID { get => comentariosID; set => comentariosID = value; }

        public int PublicacionID { get => publicacionID; set => publicacionID = value; }


        public virtual Comentario ComentarioNavigator { get; set; }
        public virtual Publicacion PublicacionNavigator { get; set; }

    }
}
