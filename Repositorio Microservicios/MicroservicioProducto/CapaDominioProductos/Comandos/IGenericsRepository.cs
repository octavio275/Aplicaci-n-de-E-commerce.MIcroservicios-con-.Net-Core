using CapaDominioProductos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDominioProductos.Comandos
{
    public interface IGenericsRepository
    {
        void Agregar<T>(T entity) where T : class;
        T Agregarr<T>(T entity) where T : class;
        T GetBy<T>(int id) where T : class;
        void Delete<T>(T entity) where T : class;
        bool DeleteById<T>(int productoID) where T : Entidad;
        T Update<T>(T entity) where T : class;
    }
}
