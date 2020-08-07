using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDominioProductos.DTOs
{
    public class InsertoProductoPanelDto
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int stock { get; set; }

        public string categoria { get; set; }

        public string marca { get; set; }

        public decimal precioreal { get; set; }

        public decimal precioventa { get; set; }

        public string imagen { get; set; }
    }
}
