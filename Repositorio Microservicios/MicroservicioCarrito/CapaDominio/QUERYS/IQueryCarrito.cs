using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.QUERYS
{
    public interface IQueryCarrito
    {
        Task<decimal> ValorCarritoCliente(int clienteID);
    }
}
