using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDominio.DTOS
{
    public class PublicacionCarritoDto
    {

        public int productoID { get; set; }
        public int carritoID { get; set; }
        public int cantidad { get; set; }
    }
}
