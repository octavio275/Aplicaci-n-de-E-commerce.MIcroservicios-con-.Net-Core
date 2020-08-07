using CapaDominio.COMANDOS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.COMANDOS
{
    public class GenericsRepository:IGenericsRepository
    {
        private readonly Contexto contexto;

        public GenericsRepository(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public void Add<T>(T entity) where T : class
        {
            contexto.Add(entity);
            contexto.SaveChanges();
        }

        public T Agregar<T>(T entity) where T : class
        {
            contexto.Add(entity);
            contexto.SaveChanges();
            return entity;

        }

        public void Delete<T>(T entity) where T : class
        {
            contexto.Set<T>().Remove(entity);
            contexto.SaveChanges();
        }


        public void Update<T>(T entity) where T : class
        {
            contexto.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            contexto.SaveChanges();
        }

        public IEnumerable<T> GetALL<T>() where T : class
        {
            DbSet<T> table = null;
            table = contexto.Set<T>();
            return table.ToList();
        }

    }
}
