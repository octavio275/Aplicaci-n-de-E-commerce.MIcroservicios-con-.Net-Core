using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CapaDominioProductos.Entidades
{
    public  class Entidad
    {
        [Key]
        private int id;

        public int Id { get => id; set => id = value; }
    }
}
