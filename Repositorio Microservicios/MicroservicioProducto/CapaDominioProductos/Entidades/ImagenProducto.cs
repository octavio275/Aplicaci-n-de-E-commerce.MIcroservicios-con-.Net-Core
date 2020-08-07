using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CapaDominioProductos.Entidades
{
    public class ImagenProducto : Entidad
    {
       
        private string nombre;

        
        public string  Nombre { get => nombre; set => nombre = value; }
    }
}
