using CapaDominioProductos.Comandos;
using CapaDominioProductos.DTOs;
using CapaDominioProductos.Entidades;
using CapaDominioProductos.Querys;
using Newtonsoft.Json;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatosProductos.Querys
{
    public class ProductoQuery : IProductoQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler compiler;
        private readonly IGenericsRepository repository;

        public ProductoQuery(IDbConnection connection, Compiler compiler, IGenericsRepository repository)
        {
            this.connection = connection;
            this.compiler = compiler;
            this.repository = repository;
        }

        public List<ProductoDto> GetAllProducto()
        {
            var db = new QueryFactory(connection, compiler);
            var query = db.Query("Productos");
            var result = query.Get<ProductoDto>();
            return result.ToList();
        }

        public List<ProductoDto> BusquedaProducto(int precio)
        {
            var db = new QueryFactory(connection, compiler);
            var Precio = db.Query("PrecioProducto").Select("id").Where("Precioventa", "=", precio).FirstOrDefault<PrecioProducto>();
            var query = db.Query("Productos").Select("Nombre"
                , "Descripcion"
                , "PrecioID"
                , "ImagenID"
                , "CategoriaID")
                .Where("PrecioID", "=", Precio.Id).Get<ProductoDto>().ToList();

            return query;
        }

        public ProductoEspecificoDto GetProductoID(int productoID)
        {
            var db = new QueryFactory(connection, compiler);




            var producto = db.Query("Productos").Select("Id", "Nombre", "Descripcion", "PrecioID", "ImagenID", "CategoriaID", "MarcaID", "Stock").Where("Id", "=", productoID).FirstOrDefault<Producto>();
            var marca = db.Query("marca").Select("Nombre").Where("Id", "=", producto.MarcaID).FirstOrDefault<Marca>();
            var precio = db.Query("precioproducto").Select("Precioventa").Where("Id", "=", producto.PrecioID).FirstOrDefault<PrecioProducto>();
            var categoria = db.Query("categorias").Select("Descripcion").Where("Id", "=", producto.CategoriaID).FirstOrDefault<Categoria>();
            var imagen = db.Query("imagenproducto").Select("Nombre").Where("Id", "=", producto.ImagenID).FirstOrDefault<ImagenProducto>();
            ProductoEspecificoDto productoespecifico = new ProductoEspecificoDto
            {
                Nombre = producto.Nombre,
                Categoria = categoria.Descripcion,
                Imagen = imagen.Nombre,
                Marca = marca.Nombre,
                Precio = precio.Precioventa,
                Stock = producto.Stock,
                Descripcion = producto.Descripcion,
                ProductoID = producto.Id


            };

            return productoespecifico;
        }

        public List<ProductoEspecificoDto> GetProductosID(JsonProductoDTO json)
        {
            var db = new QueryFactory(connection, compiler);
            List<int> productosID = json.productosID;
            List<ProductoEspecificoDto> productos = new List<ProductoEspecificoDto>();
            for (int x = 0; x < productosID.Count; x++) {

                var producto = db.Query("Productos").Select("Id", "Nombre", "Descripcion", "PrecioID", "ImagenID", "CategoriaID", "MarcaID", "Stock").Where("Id", "=", productosID[x]).FirstOrDefault<ProductoDto>();
                var marca = db.Query("marca").Select("Nombre").Where("Id", "=", producto.MarcaID).FirstOrDefault<Marca>();
                var precio = db.Query("precioproducto").Select("Precioventa").Where("Id", "=", producto.PrecioID).FirstOrDefault<PrecioProducto>();
                var categoria = db.Query("categorias").Select("Descripcion").Where("Id", "=", producto.CategoriaID).FirstOrDefault<Categoria>();
                var imagen = db.Query("imagenproducto").Select("Nombre").Where("Id", "=", producto.ImagenID).FirstOrDefault<ImagenProducto>();
                ProductoEspecificoDto productoespecifico = new ProductoEspecificoDto
                {
                    Nombre = producto.Nombre,
                    Categoria = categoria.Descripcion,
                    Imagen = imagen.Nombre,
                    Marca = marca.Nombre,
                    Precio = precio.Precioventa,
                    Stock = producto.Stock,
                    Descripcion = producto.Descripcion,
                    PublicacionID = json.publicacionesID[x],
                    ProductoID = producto.Id
                };
                productos.Add(productoespecifico);
            }


            return productos;
        }

        public List<ProductoEspecificoDto> ProductosPublicacionFiltro(JsonProductoFiltroDto json)
        {
            var db = new QueryFactory(connection, compiler);
            List<int> productosID = json.productosID;
            List<ProductoEspecificoDto> productos = new List<ProductoEspecificoDto>();
            for (int x = 0; x < productosID.Count; x++)
            {

                var query = db.Query("productos").Select("productos.Id", "productos.Nombre", "productos.Descripcion", "PrecioID", "ImagenID", "CategoriaID", "MarcaID", "Stock")
                    .Join("categorias", "categorias.Id", "Productos.CategoriaID")
                    .Where("productos.Id", "=", productosID[x])
                    .WhereLike("productos.Nombre", $"%{json.filtro}%");
                    //.OrWhereLike("productos.Descripcion", $"%{json.filtro}%")
                    //.OrWhereLike("categorias.Descripcion", $"%{json.filtro}%");
                Console.WriteLine(compiler.Compile(query).ToString());

                var producto = query.FirstOrDefault<ProductoDto>();

                //.FirstOrDefault<ProductoDto>();
                if (producto != null)
                {


                    var marca = db.Query("marca").Select("Nombre").Where("Id", "=", producto.MarcaID).FirstOrDefault<Marca>();
                    var precio = db.Query("precioproducto").Select("Precioventa").Where("Id", "=", producto.PrecioID).FirstOrDefault<PrecioProducto>();
                    var categoria = db.Query("categorias").Select("Descripcion").Where("Id", "=", producto.CategoriaID).FirstOrDefault<Categoria>();
                    var imagen = db.Query("imagenproducto").Select("Nombre").Where("Id", "=", producto.ImagenID).FirstOrDefault<ImagenProducto>();

                    ProductoEspecificoDto productoespecifico = new ProductoEspecificoDto
                    {
                        Nombre = producto.Nombre,
                        Categoria = categoria.Descripcion,
                        Imagen = imagen.Nombre,
                        Marca = marca.Nombre,
                        Precio = precio.Precioventa,
                        Stock = producto.Stock,
                        Descripcion = producto.Descripcion,
                        PublicacionID = json.publicacionesID[x],
                        ProductoID = producto.Id

                    };
                    productos.Add(productoespecifico);
                }
            }


            return productos;


        }

        public ProductosCantidadValorDTO ProductosValorCarritoCliente(ValorCarritoDTO valor)
        {
            var db = new QueryFactory(connection, compiler);
            decimal valorCarrito = 0;
            List<ProductoEspecificoDto> productoscliente = new List<ProductoEspecificoDto>();
            for(int x=0; x< valor.productosID.Count; x++) {
                var producto = db.Query("Productos").
                    Select("Id", "Nombre", "Descripcion", "PrecioID", "ImagenID", "CategoriaID", "MarcaID", "Stock").
                    Where("Id", "=", valor.productosID[x]).
                    FirstOrDefault<ProductoDto>();
                var precio = db.Query("precioproducto").
                    Select("Precioventa").
                    Where("Id", "=", producto.PrecioID).
                    FirstOrDefault<PrecioProducto>();
                var categoria = db.Query("categorias").
                    Select("Descripcion").
                    Where("Id", "=", producto.CategoriaID).
                    FirstOrDefault<Categoria>();
                var imagen = db.Query("imagenproducto").
                    Select("Nombre").Where("Id", "=", producto.ImagenID).
                    FirstOrDefault<ImagenProducto>();
                var marca = db.Query("marca").
                    Select("Nombre").
                    Where("Id", "=", producto.MarcaID).
                    FirstOrDefault<Marca>();

                ProductoEspecificoDto productoespecifico = new ProductoEspecificoDto
                {
                    Imagen=imagen.Nombre,
                    Precio=precio.Precioventa,
                    Marca=marca.Nombre,
                    Categoria=categoria.Descripcion,
                    ProductoID=producto.Id,
                    Stock=producto.Stock,
                    Nombre=producto.Nombre,
                    Descripcion=producto.Descripcion
                   
                };

                productoscliente.Add(productoespecifico);
                valorCarrito +=0;
            }
            ProductosCantidadValorDTO objeto = new ProductosCantidadValorDTO()
            {
                productos = productoscliente,
                valorcarrito=valorCarrito
            };
            return objeto;
        }

        public List<ProductoEspecificoDto> ProductosPublicacionesFiltroDescripcion(JsonProductoFiltroDto json)
        {
            var db = new QueryFactory(connection, compiler);
            List<int> productosID = json.productosID;
            List<ProductoEspecificoDto> productos = new List<ProductoEspecificoDto>();
            for (int x = 0; x < productosID.Count; x++)
            {

                var query = db.Query("productos").Select("productos.Id", "productos.Nombre", "productos.Descripcion", "PrecioID", "ImagenID", "CategoriaID", "MarcaID", "Stock")
                    .Join("categorias", "categorias.Id", "Productos.CategoriaID")
                    .Where("productos.Id", "=", productosID[x])
                    .WhereLike("productos.Descripcion", $"%{json.filtro}%");
                //.OrWhereLike("productos.Descripcion", $"%{json.filtro}%")
                //.OrWhereLike("categorias.Descripcion", $"%{json.filtro}%");
                Console.WriteLine(compiler.Compile(query).ToString());

                var producto = query.FirstOrDefault<ProductoDto>();

                //.FirstOrDefault<ProductoDto>();
                if (producto != null)
                {


                    var marca = db.Query("marca").Select("Nombre").Where("Id", "=", producto.MarcaID).FirstOrDefault<Marca>();
                    var precio = db.Query("precioproducto").Select("Precioventa").Where("Id", "=", producto.PrecioID).FirstOrDefault<PrecioProducto>();
                    var categoria = db.Query("categorias").Select("Descripcion").Where("Id", "=", producto.CategoriaID).FirstOrDefault<Categoria>();
                    var imagen = db.Query("imagenproducto").Select("Nombre").Where("Id", "=", producto.ImagenID).FirstOrDefault<ImagenProducto>();

                    ProductoEspecificoDto productoespecifico = new ProductoEspecificoDto
                    {
                        Nombre = producto.Nombre,
                        Categoria = categoria.Descripcion,
                        Imagen = imagen.Nombre,
                        Marca = marca.Nombre,
                        Precio = precio.Precioventa,
                        Stock = producto.Stock,
                        Descripcion = producto.Descripcion,
                        PublicacionID = json.publicacionesID[x],
                        ProductoID = producto.Id

                    };
                    productos.Add(productoespecifico);
                }
            }


            return productos;
        }

        public List<ProductoEspecificoDto> ProductosPublicacionesFiltroCategoria(JsonProductoFiltroDto json)
        {
            var db = new QueryFactory(connection, compiler);
            List<int> productosID = json.productosID;
            List<ProductoEspecificoDto> productos = new List<ProductoEspecificoDto>();
            for (int x = 0; x < productosID.Count; x++)
            {

                var query = db.Query("productos").Select("productos.Id", "productos.Nombre", "productos.Descripcion", "PrecioID", "ImagenID", "CategoriaID", "MarcaID", "Stock")
                    .Join("categorias", "categorias.Id", "Productos.CategoriaID")
                    .Where("productos.Id", "=", productosID[x])
                    .WhereLike("categorias.Descripcion", $"%{json.filtro}%");
                //.OrWhereLike("productos.Descripcion", $"%{json.filtro}%")
                //.OrWhereLike("categorias.Descripcion", $"%{json.filtro}%");
                Console.WriteLine(compiler.Compile(query).ToString());

                var producto = query.FirstOrDefault<ProductoDto>();

                //.FirstOrDefault<ProductoDto>();
                if (producto != null)
                {


                    var marca = db.Query("marca").Select("Nombre").Where("Id", "=", producto.MarcaID).FirstOrDefault<Marca>();
                    var precio = db.Query("precioproducto").Select("Precioventa").Where("Id", "=", producto.PrecioID).FirstOrDefault<PrecioProducto>();
                    var categoria = db.Query("categorias").Select("Descripcion").Where("Id", "=", producto.CategoriaID).FirstOrDefault<Categoria>();
                    var imagen = db.Query("imagenproducto").Select("Nombre").Where("Id", "=", producto.ImagenID).FirstOrDefault<ImagenProducto>();

                    ProductoEspecificoDto productoespecifico = new ProductoEspecificoDto
                    {
                        Nombre = producto.Nombre,
                        Categoria = categoria.Descripcion,
                        Imagen = imagen.Nombre,
                        Marca = marca.Nombre,
                        Precio = precio.Precioventa,
                        Stock = producto.Stock,
                        Descripcion = producto.Descripcion,
                        PublicacionID = json.publicacionesID[x],
                        ProductoID = producto.Id

                    };
                    productos.Add(productoespecifico);
                }
            }


            return productos;
        }

        public async Task<Producto> InsertarProductoPanel(InsertoProductoPanelDto producto)
        {
            var db = new QueryFactory(connection, compiler);
            ImagenProducto imagen = new ImagenProducto()
            {
                Nombre = producto.imagen
            };
            PrecioProducto precio = new PrecioProducto()
            {
                Precioreal=producto.precioreal,
                Precioventa=producto.precioventa,
                Fecha=DateTime.Now
            };
            Marca marca = new Marca()
            {
                Nombre=producto.marca
            };
            repository.Agregar<ImagenProducto>(imagen);
            repository.Agregar<PrecioProducto>(precio);
            repository.Agregar<Marca>(marca);
           
            var categoriaID = db.Query("categorias").
                Select("Id").
                Where("Descripcion", "=", producto.categoria).FirstOrDefault<int>();

            var imagenID = db.Query("imagenproducto").
                Select("Id").
                Where("nombre", "=", producto.imagen).FirstOrDefault<int>();

            var precioID = db.Query("precioproducto").
                Select("Id").
                Where("PrecioVenta", "=", producto.precioventa)
                .Where("PrecioReal", "=", producto.precioreal).
                FirstOrDefault<int>();

            var marcaID = db.Query("marca").
                Select("Id").
                Where("Nombre","=",producto.marca).
                FirstOrDefault<int>();


            Producto objeto = new Producto()
            {
                Nombre=producto.nombre,
                Descripcion=producto.descripcion,
                ImagenID=imagenID,
                PrecioID=precioID,
                CategoriaID=categoriaID,
                MarcaID=marcaID,
                Stock=producto.stock
            };
            repository.Agregarr<Producto>(objeto);

            var ProductoID = db.Query("productos").
             Select("Id").
             Where("Nombre", "=", objeto.Nombre).
              Where("CategoriaID", "=", objeto.CategoriaID).
               Where("PrecioID", "=", objeto.PrecioID).
                Where("MarcaID", "=", objeto.MarcaID).
                 Where("Stock", "=", objeto.Stock).
                  Where("Descripcion", "=", objeto.Descripcion).
                   FirstOrDefault<int>();

            InsertarPublicacionDto avg = new InsertarPublicacionDto()
            {
                productoID=ProductoID
            };



            string url = "https://localhost:44398/api/Publicacion/InsertarPublicacion";
            using (var httpClient = new HttpClient())
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(avg, Formatting.None);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

                var result = await httpClient.PostAsync(url,data);
                string resultado = result.Content.ReadAsStringAsync().Result;
                //posts = JsonConvert.DeserializeObject<List<ProductoEspecificoDto>>(resultado);



            }


            return objeto;



        }
    }
}
