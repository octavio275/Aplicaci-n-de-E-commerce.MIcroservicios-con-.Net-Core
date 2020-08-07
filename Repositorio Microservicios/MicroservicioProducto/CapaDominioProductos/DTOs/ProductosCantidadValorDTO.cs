using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDominioProductos.DTOs
{
   public  class ProductosCantidadValorDTO
    {
        public decimal valorcarrito { get; set; }
        public List<ProductoEspecificoDto> productos { get; set; }
    }
}
