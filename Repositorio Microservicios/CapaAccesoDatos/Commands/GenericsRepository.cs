using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CapaDeDominio.Commands;
using CapaDeDominio.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CapaAccesoDatos.Commands
{
    public class GenericsRepository : IGenericRepository
    {
        private readonly DatoDbContext _context;
        
        public GenericsRepository(DatoDbContext dbcontex)
        {
            _context = dbcontex;
            
        }

        public T Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete<T>(T entity) where T : class
        {
            if(entity != null )
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
         
            
        }

        public IEnumerable<T> GetALL<T>() where T : class
        {
            DbSet<T> table = null;
            table = _context.Set<T>();
            return table.ToList();
           
        }

        public T GetBy<T>(int id) where T : class
        {
            DbSet<T> table = _context.Set<T>();
            return table.Find(id);
        }
       

        public bool Update<T>(T entity) where T : class
        {
            if(entity != null)
            {
                _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        
    }
}
