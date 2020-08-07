using CapaDominio.ENTIDADES;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDatos
{
    public class Contexto : DbContext
    {
        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<CarritoProducto> CarritoProducto { get; set; }
        public Contexto(DbContextOptions<Contexto> opciones) : base(opciones)
        {
            
        }
       


    }
}
