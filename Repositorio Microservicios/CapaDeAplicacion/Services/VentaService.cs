using CapaDeDominio.Commands;
using CapaDeDominio.DTOs;
using CapaDeDominio.Entity;
using CapaDeDominio.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeAplicacion.Services
{

    public interface IVentaService
    {

        Venta InsertarVenta(int carritoID);


    }
    public class VentaService : IVentaService
    {
        private readonly IGenericRepository _repository;
        private readonly IQueryVenta query;

        public VentaService(IGenericRepository repository)
        {
            _repository = repository;
        }

        public VentaService(IGenericRepository repository, IQueryVenta query)
        {
            _repository = repository;
            this.query = query;
        }

        public Venta InsertarVenta(int carritoID)
        {
            Venta venta = new Venta()
            {
                FechaVenta=DateTime.Today,
                Id_carrito=carritoID
            };

            return _repository.Add<Venta>(venta);
        }
    }
}
