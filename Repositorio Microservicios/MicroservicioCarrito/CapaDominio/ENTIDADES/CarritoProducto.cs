using CapaDominio.DTOS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CapaDominio.ENTIDADES
{
    public class CarritoProducto
    {
      
        private int iD;
        private int carritoID;
        private int productoID;
        
        public int ID { get => iD; set => iD = value; }
        public int CarritoID { get => carritoID; set => carritoID = value; }
        public int ProductoID { get => productoID; set => productoID = value; }

        public virtual Carrito CarritoNavigator { get; set; }
        

    }
}
