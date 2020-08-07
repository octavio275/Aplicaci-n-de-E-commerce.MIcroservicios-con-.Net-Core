using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDominio.DTOS
{
    public class ProductosCantidadValorDTO
    {
        public decimal valorcarrito { get; set; }
        public List<ProductoEspecificoDto> productos { get; set; }
    }
}
