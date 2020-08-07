using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CapaDeDominio.Entity;
namespace CapaAccesoDatos
{
    public class DatoDbContext : DbContext
    {
  
   
        public DbSet<Venta> Ventas { get; set; }

        
        public DatoDbContext(DbContextOptions<DatoDbContext> options):base(options)
        {

        }
       

    }
}
