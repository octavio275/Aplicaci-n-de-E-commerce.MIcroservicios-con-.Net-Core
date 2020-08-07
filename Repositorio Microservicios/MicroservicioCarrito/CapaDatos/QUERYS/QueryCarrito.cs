using CapaDominio.DTOS;
using CapaDominio.QUERYS;
using Newtonsoft.Json;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos.QUERYS
{
    public class QueryCarrito:IQueryCarrito
    {



        private readonly IDbConnection conexion;
        private readonly Compiler SqlKataCompiler;


        public QueryCarrito(IDbConnection conexion, Compiler SqlKataCompiler)
        {
            this.conexion = conexion;
            this.SqlKataCompiler = SqlKataCompiler;
        }

        public async Task<decimal> ValorCarritoCliente(int clienteID)
        {
            var db = new QueryFactory(conexion, SqlKataCompiler);
            var carritoID = db.Query("Carrito").
           Select("ID").Where("ClienteID","=",clienteID).FirstOrDefault<int>();
            var productos = db.Query("CarritoProducto").
           Select("ProductoID").Where("CarritoID", "=", carritoID).Get<int>().ToList();
            decimal valorcarrito = 0;

            ValorCarritoDTO valor = new ValorCarritoDTO()
            {
                productosID = productos
            };

            
            string url = "https://localhost:44398/api/Producto/ValorCarritoCliente";
            using (var httpClient = new HttpClient())
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(valor, Formatting.None);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

                var result = await httpClient.PostAsync(url, data);
                string resultado = result.Content.ReadAsStringAsync().Result;
                valorcarrito = JsonConvert.DeserializeObject<decimal>(resultado);

                              

            }

            return valorcarrito;
        }
    }
}
