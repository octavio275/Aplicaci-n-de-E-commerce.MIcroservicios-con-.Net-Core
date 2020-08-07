using DOMINIO.ENTIDADES;
using DOMINIO.QUERYS;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DOMINIO.DTOS;
using Newtonsoft.Json.Linq;

namespace DATOS.QUERYS
{
    public class QueryPublicacion : IQueryPublicacion
    {
        private readonly IDbConnection conexion;
        private readonly Compiler SqlKataCompiler;
     

        public QueryPublicacion(IDbConnection conexion, Compiler SqlKataCompiler)
        {
            this.conexion = conexion;
            this.SqlKataCompiler = SqlKataCompiler;
        }

    

        public async Task<ProductoEspecificoDto> GetProducto(int publicacionID)
        {
            //ProductoDTO producto = new ProductoDTO();

            string url = "https://localhost:44370/api/Producto/TraerProductosID?publicacionID=" + publicacionID;

           
            using (var http = new HttpClient())
            {


                 string request = await http.GetStringAsync(url);
                 ProductoEspecificoDto posts = JsonConvert.DeserializeObject<ProductoEspecificoDto>(request);

               



                return posts;






            }
        }

        public async Task<List<ProductoEspecificoDto>> getProductosPublicaciones(int CANTIDAD)//recibir el offset por parametro.
        {          
            var db = new QueryFactory(conexion, SqlKataCompiler);
            var Productos = db.Query("Publicaciones").
            Select("ProductoID").Limit(6).Offset(CANTIDAD).Get<int>().ToList();
            //recordar cambiar la logica y aplicar el limit.
            //string productosID = "";
            //ahora voy a hacer la paginacion de forma correcta.
            //lo que siempre voy a pedir  por parámetor es el offset.
            var Publicaciones = db.Query("Publicaciones").
            Select("ID").Limit(6).Offset(CANTIDAD).Get<int>().ToList();


            List<ProductoEspecificoDto> posts = null;
            //for (int x=0; x<Publicacion.Count; x++)
            //{
            //    productosID += Publicacion[x];
            //}
            JsonProductoDTO jsonDTO = new JsonProductoDTO();
            jsonDTO.productosID = Productos;
            jsonDTO.publicacionesID = Publicaciones;

            //string url = "https://localhost:44370/api/Producto/ProductosID?productosID="+productosID;

            string url = "https://localhost:44370/api/Producto/ProductosID";
            using (var httpClient = new HttpClient())
                    {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(jsonDTO, Formatting.None);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

                var result = await httpClient.PostAsync(url, data);
                string resultado = result.Content.ReadAsStringAsync().Result;
                posts = JsonConvert.DeserializeObject<List<ProductoEspecificoDto>>(resultado);

                //string request = await httpClient.GetStringAsync(url);
                //        posts = JsonConvert.DeserializeObject<List<ProductoDTO>>(request);                    

                    }

                            
            return posts;


        }


        public async Task<List<ProductoEspecificoDto>> ProductosPublicacionFiltro(string filtro)//recibir el offset por parametro.
        {
            var db = new QueryFactory(conexion, SqlKataCompiler);
            var Productos = db.Query("Publicaciones").
            Select("ProductoID").Get<int>().ToList();
            var Publicaciones = db.Query("Publicaciones").
            Select("ID").Get<int>().ToList();


            List<ProductoEspecificoDto> posts = null;    
            JsonProductoFiltroDto jsonDTO = new JsonProductoFiltroDto();
            jsonDTO.productosID = Productos;
            jsonDTO.filtro = filtro;
            jsonDTO.publicacionesID = Publicaciones;
            string url = "https://localhost:44370/api/Producto/ProductosPublicacionesFiltro";
            using (var httpClient = new HttpClient())
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(jsonDTO, Formatting.None);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

                var result = await httpClient.PostAsync(url, data);
                string resultado = result.Content.ReadAsStringAsync().Result;
                posts = JsonConvert.DeserializeObject<List<ProductoEspecificoDto>>(resultado);

                                 

            }


            return posts;


        }






        public List<Publicacion> GetPublicaciones()
        {
            var db = new QueryFactory(conexion, SqlKataCompiler);
            var Publicacion = db.Query("Publicaciones").
               Select("ProductoID").Get<Publicacion>().ToList();

            return Publicacion;  

        }

        public Publicacion GetPublicacionesID(int publicacionID)
        {
            var db = new QueryFactory(conexion, SqlKataCompiler);
            var Publicacion = db.Query("Publicaciones").
                Select("ProductoID").
                Where("ID", "=", publicacionID).
                FirstOrDefault<Publicacion>();
               

            return Publicacion;
        }

        public List<string> PaginacionComentarios(PaginacionComentarioDto json)
        {
            var db = new QueryFactory(conexion, SqlKataCompiler);

            List<string> ListaComentarios = new List<string>();
            var comentariosID = db.Query("ComentarioPublicacion").
              Select("ComentariosID").
              Limit(5).Offset(json.Offset).
              Where("PublicacionID", "=", json.PublicacionID).
              Get<ComentarioPublicacion>().ToList();
            foreach (ComentarioPublicacion var in comentariosID) {
                var comentario = db.Query("Comentarios").               
                  Select("Comentarios").
                  Where("Id", "=", var.ComentariosID).
                  FirstOrDefault<Comentario>();
                ListaComentarios.Add(comentario.Comentarios);

                                           }

            return ListaComentarios;
        }

        public async Task< productoYcomentariosDTO> ProductoYcomentariosDePublicacion(int publicacionID, int offset)
        {
            var db = new QueryFactory(conexion, SqlKataCompiler);
            productoYcomentariosDTO variable = new productoYcomentariosDTO();
            PaginacionComentarioDto var = new PaginacionComentarioDto()
            {
                PublicacionID=publicacionID,
                Offset=offset
            };

            var query = db.Query("publicaciones").Select("ProductoID").Where("ID", "=", publicacionID).FirstOrDefault<int>();

            string url = "https://localhost:44370/api/Producto/TraerProductosID?publicacionID="+query;


            using (var http = new HttpClient())
            {


                string request = await http.GetStringAsync(url);
                ProductoEspecificoDto posts = JsonConvert.DeserializeObject<ProductoEspecificoDto>(request);


                variable.Comentarios = PaginacionComentarios(var);
                variable.Categoria = posts.Categoria;
                variable.Nombre = posts.Nombre;
                variable.Precio = posts.Precio;
                variable.Marca = posts.Marca;
                variable.Stock = posts.Stock;
                variable.PublicacionID = publicacionID;
                variable.Descripcion = posts.Descripcion;
                variable.Imagen = posts.Imagen;
                variable.ProductoID = posts.ProductoID;


                return variable;





            }



        }

        public async Task<List<ProductoEspecificoDto>> ProductosPublicacionFiltroDescripcion(string filtro)
        {
            var db = new QueryFactory(conexion, SqlKataCompiler);
            var Productos = db.Query("Publicaciones").
            Select("ProductoID").Get<int>().ToList();
            var Publicaciones = db.Query("Publicaciones").
            Select("ID").Get<int>().ToList();


            List<ProductoEspecificoDto> posts = null;
            JsonProductoFiltroDto jsonDTO = new JsonProductoFiltroDto();
            jsonDTO.productosID = Productos;
            jsonDTO.filtro = filtro;
            jsonDTO.publicacionesID = Publicaciones;
            string url = "https://localhost:44370/api/Producto/ProductosPublicacionesFiltroDescripcion";
            using (var httpClient = new HttpClient())
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(jsonDTO, Formatting.None);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

                var result = await httpClient.PostAsync(url, data);
                string resultado = result.Content.ReadAsStringAsync().Result;
                posts = JsonConvert.DeserializeObject<List<ProductoEspecificoDto>>(resultado);



            }


            return posts;
        }

        public async Task<List<ProductoEspecificoDto>> ProductosPublicacionFiltroCategoria(string filtro)
        {
            var db = new QueryFactory(conexion, SqlKataCompiler);
            var Productos = db.Query("Publicaciones").
            Select("ProductoID").Get<int>().ToList();
            var Publicaciones = db.Query("Publicaciones").
            Select("ID").Get<int>().ToList();


            List<ProductoEspecificoDto> posts = null;
            JsonProductoFiltroDto jsonDTO = new JsonProductoFiltroDto();
            jsonDTO.productosID = Productos;
            jsonDTO.filtro = filtro;
            jsonDTO.publicacionesID = Publicaciones;
            string url = "https://localhost:44370/api/Producto/ProductosPublicacionesFiltroCategoria";
            using (var httpClient = new HttpClient())
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(jsonDTO, Formatting.None);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

                var result = await httpClient.PostAsync(url, data);
                string resultado = result.Content.ReadAsStringAsync().Result;
                posts = JsonConvert.DeserializeObject<List<ProductoEspecificoDto>>(resultado);



            }


            return posts;
        }

        public async Task<List<ProductoEspecificoDto>> TraerProductosPublicacionesPanel()
        {
            var db = new QueryFactory(conexion, SqlKataCompiler);
            var Productos = db.Query("Publicaciones").
            Select("ProductoID").Get<int>().ToList();
            
            var Publicaciones = db.Query("Publicaciones").
            Select("ID").Get<int>().ToList();


            List<ProductoEspecificoDto> posts = null;
           
            JsonProductoDTO jsonDTO = new JsonProductoDTO();
            jsonDTO.productosID = Productos;
            jsonDTO.publicacionesID = Publicaciones;

           

            string url = "https://localhost:44370/api/Producto/ProductosID";
            using (var httpClient = new HttpClient())
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(jsonDTO, Formatting.None);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

                var result = await httpClient.PostAsync(url, data);
                string resultado = result.Content.ReadAsStringAsync().Result;
                posts = JsonConvert.DeserializeObject<List<ProductoEspecificoDto>>(resultado);

                                

            }


            return posts;

        }
    }
}
