using CapaDatos;
using CapaDominio.COMANDOS;
using CapaDominio.ENTIDADES;
using CapaDominio.QUERYS;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using CapaDominio.DTOS;
using System.Net.Http;
using Newtonsoft.Json;

namespace CapaAplicacion.SERVICIOS
{
    public interface ICarritoServicio
    {
        Carrito InsertarCarritoCliente(int clienteID);
        Task<ProductosCantidadValorDTO> ProductosValorCarritoCliente(int clienteID);
        bool BorrarProductoCarrito(int productoID, int carritoID);
        int VerificarClienteCarrito(int clienteID);

        public bool BorrarCarritoCompleto(int carritoID);
    }


    public class CarritoServicio :ICarritoServicio
    {
        private readonly IGenericsRepository repository;
        private readonly IQueryCarrito query;
        private readonly Contexto contexto;






        public CarritoServicio(IGenericsRepository repository, IQueryCarrito query, Contexto contexto)
        {
            this.repository = repository;
            this.query = query;
            this.contexto = contexto;
        }

     

        public bool BorrarProductoCarrito(int productoID, int carritoID)
        {
            bool respuesta = false;
            CarritoProducto obj = (from x in contexto.CarritoProducto where x.ProductoID == productoID && x.CarritoID == carritoID select x).
            FirstOrDefault<CarritoProducto>();
            if (obj!=null)
            {
                repository.Delete<CarritoProducto>(obj);
                respuesta = true;
            }
            return respuesta;
        }

        public Carrito InsertarCarritoCliente(int clienteID)
        {
            Carrito objeto = new Carrito()
            {
                ClienteID = clienteID
            };


            return repository.Agregar<Carrito>(objeto);
        }

        public async Task<ProductosCantidadValorDTO> ProductosValorCarritoCliente(int clienteID)
        {
             decimal preciototal= 0;
            var query = (from x in contexto.Carrito where x.ClienteID == clienteID select x.ID).FirstOrDefault<int>();
            var query2 = (from x in contexto.CarritoProducto where x.CarritoID == query select x.ProductoID).Distinct<int>().ToList();
            List<ProductoEspecificoDto> productos = new List<ProductoEspecificoDto>();
            ValorCarritoDTO valor = new ValorCarritoDTO()
            {
                productosID = query2
            };
            ProductosCantidadValorDTO objeto;

            string url = "https://localhost:44370/api/Producto/ProductosValorCarritoCliente";
            using (var httpClient = new HttpClient())
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(valor, Formatting.None);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

                var result = await httpClient.PostAsync(url, data);
                string resultado = result.Content.ReadAsStringAsync().Result;
                objeto = JsonConvert.DeserializeObject<ProductosCantidadValorDTO>(resultado);



            }

            foreach (ProductoEspecificoDto obj in objeto.productos)
            {
                int count = (from x in contexto.CarritoProducto where x.ProductoID == obj.ProductoID && x.CarritoID == query select x).Count();
                ProductoEspecificoDto var = new ProductoEspecificoDto()
                {
                    ProductoID=obj.ProductoID,
                    Imagen=obj.Imagen,
                    Descripcion=obj.Descripcion,
                    Stock=obj.Stock,
                    Nombre=obj.Nombre,
                    Marca=obj.Marca,
                    Cantidad=count,
                    Categoria=obj.Categoria,
                    Precio=obj.Precio
                };
                productos.Add(var);
                preciototal += var.Precio*var.Cantidad;

            }


            objeto.productos = productos;
            objeto.valorcarrito = preciototal;
            




            return objeto;



        }

        public int VerificarClienteCarrito(int clienteID)
        {
            var query = (from x in contexto.Carrito where x.ClienteID == clienteID select x.ID).FirstOrDefault<int>();
            if (query==0)
            {
                Carrito obj = new Carrito()
                {
                    ClienteID=clienteID
                };
                repository.Agregar<Carrito>(obj);
            }


            return (from x in contexto.Carrito where x.ClienteID == clienteID select x.ID).FirstOrDefault<int>();

        }

        public bool BorrarCarritoCompleto(int carritoID)
        {
            var respuesta = false;
            var query = (from x in contexto.CarritoProducto where x.CarritoID == carritoID select x).ToList<CarritoProducto>();
            foreach (CarritoProducto obj in query)
            {
                repository.Delete<CarritoProducto>(obj);
                respuesta = true;

            }
            return respuesta;



        }
    }
}
