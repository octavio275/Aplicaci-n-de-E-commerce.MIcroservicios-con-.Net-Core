using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DOMINIO.ENTIDADES
{
    public class Publicacion
    {

        [Key]
        private int iD;
        private int productoID;

        public int ID { get => iD; set => iD = value; }
        public int ProductoID { get => productoID; set => productoID = value; }
    }
}
