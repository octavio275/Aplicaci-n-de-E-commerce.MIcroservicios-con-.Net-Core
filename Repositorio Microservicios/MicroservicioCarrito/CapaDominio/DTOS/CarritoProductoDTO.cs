using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDominio.DTOS
{
    public class CarritoProductoDTO
    {
        private int iD;
        private int carritoID;
        private int productoID;

        public int ID { get => iD; set => iD = value; }
        public int CarritoID { get => carritoID; set => carritoID = value; }
        public int ProductoID { get => productoID; set => productoID = value; }

        public virtual CarritoDTO CarritoNavigator { get; set; }
    }
}
