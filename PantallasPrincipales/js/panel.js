window.onload = function() {
    $.ajax({
        type: "GET",
        url: 'https://localhost:44398/api/Publicacion/TraerProductosPublicacionesPanel',
        dataType: "json",
        success: function(data) {
            var count = 0;
            $.each(data, function(i, item) {


                var tr = document.createElement('tr');
                var td = document.createElement('td');
                var imagen = document.createElement('IMG');
                imagen.src = 'images/' + item.imagen;
                imagen.setAttribute("width", "100px");

                td.append(imagen);

                var td2 = document.createElement('td');
                td2.className = "titulo";
                td2.textContent = item.nombre;
                var td3 = document.createElement('td');
                td3.className = "precio";
                td3.textContent = "$" + item.precio;
                var td4 = document.createElement('td');
                td4.className = "stock";
                td4.textContent = item.stock + " " + "productos";
                var td5 = document.createElement('td');
                td5.className = "boton-centro";

                var boton = document.createElement('button');
                boton.className = "btn btn-danger";
                boton.textContent = "Borrar";
                boton.onclick = function() {
                    $.ajax({
                        type: "POST",
                        url: "https://localhost:44398/api/Publicacion/BorrarPublicacion?publicacionID=" + item.publicacionID,
                        dataType: "json",
                        success: function(data) {


                            location.reload();

                        }


                    });




                }
                td5.append(boton);

                tr.append(td);
                tr.append(td2);
                tr.append(td3);
                tr.append(td4);
                tr.append(td5);
                $('#contenedorProductos').append(tr);
                count += 1;


                var cantidad = document.getElementById("cantidad");
                cantidad.innerHTML = count;






            });

        },
        error: function(error) {
            console.log(error.message);
            alert('error');
        }


    });



}



var formulario = document.getElementById('dataForm');
document.addEventListener('submit', function(e) {
    e.preventDefault();
    var data = new FormData(formulario);
    var Marca = data.get('Marca');
    var Nombre = data.get('Nombre');
    var PrecioReal = parseFloat(data.get('PrecioReal'));
    var PrecioVenta = parseFloat(data.get('PrecioVenta'));
    var Categoria = data.get('Categoria');
    var Imagen = data.get('archivosubido').name;
    var Descripcion = data.get('Descripcion');
    var Stock = parseInt(data.get('Stock'));


    var objeto = {
        nombre: Nombre,
        descripcion: Descripcion,
        stock: Stock,
        categoria: Categoria,
        precioreal: PrecioReal,
        precioventa: PrecioVenta,
        imagen: Imagen,
        marca: Marca
    }

    $.ajax({
        url: "https://localhost:44331/api/Producto/InsertarProductoPanel",
        data: JSON.stringify(objeto),
        type: "POST",
        dataType: 'JSON',
        contentType: "application/json",
        success: function(data) {
            location.reload();
        }

    });

});