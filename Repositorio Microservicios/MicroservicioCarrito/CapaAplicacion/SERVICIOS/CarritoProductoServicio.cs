using CapaDominio.COMANDOS;
using CapaDominio.DTOS;
using CapaDominio.ENTIDADES;
using CapaDominio.QUERYS;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CapaAplicacion.SERVICIOS
{
    public interface ICarritoProductoServicio
    {
        CarritoProducto InsertarCarritoProductoCliente(int carritoID,int productoID);
        List<CarritoProducto> InsertarCarritoProductoCantidad(PublicacionCarritoDto objeto);
    }

    public class CarritoProductoServicio: ICarritoProductoServicio
    {

        private readonly IGenericsRepository repository;
        private readonly IQueryCarritoProducto query;

        public CarritoProductoServicio(IGenericsRepository repository, IQueryCarritoProducto query)
        {
            this.repository = repository;
            this.query = query;
        }

        public List<CarritoProducto> InsertarCarritoProductoCantidad(PublicacionCarritoDto objeto)
        {
            List<CarritoProducto> lista = new List<CarritoProducto>();
            for (int x = 0; x < objeto.cantidad; x++)
            {
                CarritoProducto obj = new CarritoProducto()
                {
                    CarritoID = objeto.carritoID,
                    ProductoID = objeto.productoID
                };

                 repository.Agregar<CarritoProducto>(obj);
                lista.Add(obj);
            }

            return lista;
        }

        public CarritoProducto InsertarCarritoProductoCliente(int carritoID, int productoID)
        {
            CarritoProducto objeto = new CarritoProducto()
            {
                CarritoID=carritoID,
                ProductoID=productoID
            };

            return repository.Agregar<CarritoProducto>(objeto);
        }
    }
}
