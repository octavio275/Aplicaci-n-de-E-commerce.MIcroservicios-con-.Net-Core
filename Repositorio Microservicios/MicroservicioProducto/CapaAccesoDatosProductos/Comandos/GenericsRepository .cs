using CapaDominioProductos.Comandos;
using CapaDominioProductos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace CapaAccesoDatosProductos.Comandos
{
    public class GenericsRepository : IGenericsRepository
    {
        private readonly Contexto contexto;
        public GenericsRepository(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public void Agregar<T>(T entity) where T : class
        {
            contexto.Add(entity);
            contexto.SaveChanges();
        }
      

        public void Delete<T>(T entity) where T : class
        {
            contexto.Set<T>().Remove(entity);
            contexto.SaveChanges();
        }

        public bool DeleteById<T>(int id) where T : Entidad
        {
            T entidad = contexto.Set<T>().FirstOrDefault(x => x.Id == id);
            contexto.Remove(entidad);
            contexto.SaveChanges();
            return true;
      
        }

        public T GetBy<T>(int id) where T : class
        {
            DbSet<T> table = contexto.Set<T>();
            return table.Find(id);
        }

        public T Update<T>(T entity) where T : class
        {
            contexto.Entry(entity).State = EntityState.Modified;
            contexto.SaveChanges();
            return entity;
        }

        T IGenericsRepository.Agregarr<T>(T entity)
        {
            contexto.Add(entity);
            contexto.SaveChanges();
            return entity;
        }
    }
}
