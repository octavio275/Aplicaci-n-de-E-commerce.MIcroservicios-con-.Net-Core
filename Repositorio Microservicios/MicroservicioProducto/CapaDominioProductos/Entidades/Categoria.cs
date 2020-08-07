using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CapaDominioProductos.Entidades
{
    public class Categoria : Entidad
    {

     
        private string descripcion;

       
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
