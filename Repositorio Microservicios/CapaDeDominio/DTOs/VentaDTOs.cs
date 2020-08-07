using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CapaDeDominio.DTOs
{
    public class VentaDTOs
    {
        [Key]
        public int Id { get; set; }
        public int Id_cliente { get; set; }
        public int Id_carrito { get; set; }
        public DateTime FechaVenta { get; set; }
     
        public int Monto { get; set; }
    }
}
