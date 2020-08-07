using System;
using System.Collections.Generic;
using System.Text;

namespace DOMINIO.DTOS
{
    public class JsonProductoFiltroDto
    {
        public string filtro { get; set; }
        public List<int> productosID { get; set; }
        public List<int> publicacionesID { get; set; }
    }
}
