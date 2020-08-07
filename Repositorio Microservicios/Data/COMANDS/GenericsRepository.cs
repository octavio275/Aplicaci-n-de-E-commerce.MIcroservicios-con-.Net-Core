using Domain.COMANDOS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.COMANDS
{
    public class GenericsRepository : IGenericRepository
    {
        private readonly Context _context;

        public GenericsRepository(Context contexto)
        {
            _context = contexto;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public bool Delete<T>(T entity) where T : class
        {

            if (entity != null)
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
            if (entity != null)
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
