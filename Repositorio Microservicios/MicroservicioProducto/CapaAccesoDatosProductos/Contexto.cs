using CapaDominioProductos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaAccesoDatosProductos
{
    public class Contexto:DbContext
    {

        public DbSet<Producto> productos { get; set; }
        public DbSet<Categoria> categorias { get; set; }
 
        public DbSet<ImagenProducto> imagenproducto { get; set; }
        public DbSet<Marca> marca { get; set; }
        public DbSet<PrecioProducto> precioproducto { get; set; }



        public Contexto(DbContextOptions<Contexto> opciones)

           : base(opciones)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{


        //    modelBuilder.Entity<Marca>(entity =>
        //    {
        //        entity.ToTable("ImagenProducto");
        //        entity.HasData(new Marca { Id = 1, Nombre = "Nike" });
        //        entity.HasData(new Marca { Id = 2, Nombre = "Adidas" });
        //    }
        //  );

        //    modelBuilder.Entity<ImagenProducto>(entity =>
        //    {
        //        entity.ToTable("ImagenProducto");
        //        entity.HasData(new ImagenProducto { Id = 1, Nombre = "C:\\Users\\EmmaGrande\\source\\repos\\EmmanuelJulio\\Tp2Psoft\\FotoNike.jpg" });
        //        entity.HasData(new ImagenProducto { Id = 2, Nombre = "C:\\Users\\EmmaGrande\\source\\repos\\EmmanuelJulio\\Tp2Psoft\\FotoAdidas.jpg" });
        //    }
        //    );

        //    modelBuilder.Entity<PrecioProducto>(entity =>
        //    {
        //        entity.ToTable("PrecioProducto");
        //        entity.HasData(new PrecioProducto { Id = 1, Precioreal = 110, Precioventa = 150, Fecha = DateTime.Now });
        //        entity.HasData(new PrecioProducto { Id = 2, Precioreal = 40, Precioventa = 45, Fecha = DateTime.Now });
        //    }
        //  );

        //    modelBuilder.Entity<Categoria>(entity =>
        //    {
        //        entity.ToTable("Categorias");
        //        entity.HasData(new Categoria { Id = 1, Descripcion = "Es rica y tiene gusto a uva" });
        //        entity.HasData(new Categoria { Id = 2, Descripcion = "es una cosa que podes chupar" });
        //    }
        //  );
        //    modelBuilder.Entity<Producto>(entity =>
        //    {
        //        entity.ToTable("Productos");
        //        entity.HasData(new Producto { Id = 1, CategoriaID = 1, Nombre = "Gel 2000", Descripcion = "Sistema de amortiguacion", PrecioID = 1, ImagenID = 1,MarcaID = 1, Stock = 2 });
        //        entity.HasData(new Producto { Id = 2, CategoriaID = 2, Nombre = "Air Flow", Descripcion = "Ideales para correr", PrecioID = 2, ImagenID = 3, MarcaID = 2, Stock = 5 });
        //    });
        //}
    }

}
