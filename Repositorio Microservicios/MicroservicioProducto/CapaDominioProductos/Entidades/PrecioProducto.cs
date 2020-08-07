using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CapaDominioProductos.Entidades
{
    public class PrecioProducto : Entidad
    {
       
        [Column(TypeName = "decimal(18,2)")]
        private decimal precioreal;
        private decimal precioventa;
        private DateTime fecha;

        
        public decimal Precioreal { get => precioreal; set => precioreal = value; }
        public decimal Precioventa { get => precioventa; set => precioventa = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
     
    }
}
