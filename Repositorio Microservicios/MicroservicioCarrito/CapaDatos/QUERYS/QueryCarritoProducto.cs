using CapaDominio.QUERYS;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaDatos.QUERYS
{
    public class QueryCarritoProducto:IQueryCarritoProducto
    {
        private readonly IDbConnection conexion;
        private readonly Compiler SqlKataCompiler;


        public QueryCarritoProducto(IDbConnection conexion, Compiler SqlKataCompiler)
        {
            this.conexion = conexion;
            this.SqlKataCompiler = SqlKataCompiler;
        }
    }
}
