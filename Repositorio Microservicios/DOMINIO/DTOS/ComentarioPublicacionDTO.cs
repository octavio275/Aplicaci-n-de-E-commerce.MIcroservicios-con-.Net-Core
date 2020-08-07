using System;
using System.Collections.Generic;
using System.Text;

namespace DOMINIO.DTOS
{
    public class ComentarioPublicacionDTO
    {
        private int comentariosID;
        private int publicacionID;


        public int ComentariosID { get => comentariosID; set => comentariosID = value; }

        public int PublicacionID { get => publicacionID; set => publicacionID = value; }


        public virtual ComentarioDTO ComentarioDTONavigator { get; set; }
        public virtual PublicacionDTO PublicacionDTONavigator { get; set; }
    }
}
