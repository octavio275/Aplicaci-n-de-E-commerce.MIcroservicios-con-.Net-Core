using CapaDeDominio.DTOs;
using CapaDeDominio.Queries;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace CapaAccesoDatos.Queries
{
    public class QueryVenta : IQueryVenta
    {
        private readonly Compiler compiler;
        private readonly IDbConnection connection;

        public QueryVenta(Compiler compiler, IDbConnection connection)
        {
            this.compiler = compiler;
            this.connection = connection;
        }


        //buscar un carrito por su id
        
        //buscar un cliente por su idd
       
    }
}
