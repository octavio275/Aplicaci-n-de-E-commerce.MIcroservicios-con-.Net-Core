using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.COMANDOS
{
    public interface IGenericRepository
    {
        void Add<T>(T entity) where T : class;
        bool Delete<T>(T entity) where T : class;
        bool Update<T>(T entity) where T : class;
        IEnumerable<T> GetALL<T>() where T : class;
        T GetBy<T>(int id) where T : class;
    }
}
