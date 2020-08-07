using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDominioProductos.DTOs
{
   public  class PrecioProductoDto
    {
        private decimal precioreal;
        private decimal precioventa;
        private DateTime fecha;

        public decimal Precioreal { get => precioreal; set => precioreal = value; }
        public decimal Precioventa { get => precioventa; set => precioventa = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
