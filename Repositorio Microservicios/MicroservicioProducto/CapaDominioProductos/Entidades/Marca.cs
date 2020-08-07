using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CapaDominioProductos.Entidades
{
   public  class Marca : Entidad
    {
       
        private string nombre;

       
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
