using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection.PortableExecutable;

namespace CapaDeDominio.Commands
{
   public interface IGenericRepository
    {
         T Add<T>(T entity) where T : class;
         bool Delete<T>(T entity) where T : class;
         bool Update<T>(T entity) where T : class;
         IEnumerable<T> GetALL<T>() where T : class;
         T GetBy<T>(int id) where T : class;
      
    }
}
