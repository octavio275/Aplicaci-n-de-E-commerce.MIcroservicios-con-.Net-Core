window.onload = function() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44398/api/Publicacion/ProductoYcomentariosDePublicacion?publicacionID=" + localStorage.getItem("publicacionID") + "&offset=" + localStorage.getItem("offsetcomentario"),




        dataType: "json",
        //hice un cambio
        success: function(data) {
            //$.each(data, function(i, item) {  
            var countComments = document.getElementById("CountComments");
            var producto = document.getElementById("producto");
            producto.src = 'images/' + data.imagen;
            producto.id = data.productoID
            localStorage.setItem("productoID", data.productoID);
            var precio = document.getElementById("precio");
            precio.innerHTML = "$" + data.precio;
            var nombre = document.getElementById("nombre");
            nombre.innerHTML = 'PresentOnline - ' + data.nombre + " - " + data.categoria + ` <img src="https://css.drlcdn.com/imagecache/dresslilyV3/static/img/common/nav-fire-icon-pc.gif" alt="">`;
            //var stock = document.getElementById("stock");
            //stock.innerHTML=item.stock;

            //prueba

            //}); 
            var contador = 0;
            for (x = 0; x < data.comentarios.length; x++) {

                contador += 1;
                var div = document.createElement('div');
                div.className = "media";

                var div2 = document.createElement('div');
                div2.className = "media-left";

                var hr = document.createElement('hr');


                var imagen = document.createElement('IMG');
                imagen.src = 'images/iconousuario.png';
                imagen.className = "img-rounded media-object";
                imagen.setAttribute("width", "60");


                div2.append(imagen);

                var div3 = document.createElement('div');
                div3.className = "media-right";

                var h4 = document.createElement('h4');
                h4.className = "media-heading";
                h4.textContent = "usuario";

                var p = document.createElement('p');
                p.textContent = data.comentarios[x];

                div3.append(h4);
                div3.append(p);

                div.append(div2);

                div.append(div3);

                $('#secciones').append(div);

            }
            countComments.innerHTML = contador;

        },
        error: function(error) {
            console.log(error.message);
            alert('error');
        }





    });


}




function comentar() {

    var objeto = {
        publicacionID: parseInt(localStorage.getItem("publicacionID")),
        comentario: document.getElementById("comentario").value
    }



    $.ajax({
        url: 'https://localhost:44398/api/Comentario/InsertarComentarioPublicacion',
        data: JSON.stringify(objeto),
        type: "POST",
        dataType: 'JSON',
        contentType: "application/json",


        success: function() {
            location.reload();
        }

    });



}



function VerMas() {
    var offset = parseInt(localStorage.getItem("offsetcomentario"));
    offset = offset + 3;
    localStorage.setItem("offsetcomentario", `${offset}`);
    var objeto = {
        PublicacionID: parseInt(localStorage.getItem("publicacionID")),
        Offset: parseInt(localStorage.getItem("offsetcomentario"))
    }

    $.ajax({
        url: 'https://localhost:44398/api/Publicacion/PaginacionComentarios',
        data: JSON.stringify(objeto),
        type: "POST",
        dataType: 'JSON',
        contentType: "application/json",


        success: function(data) {
            for (x = 0; x < data.length; x++) {
                var div = document.createElement('div');
                div.className = "media";

                var div2 = document.createElement('div');
                div2.className = "media-left";

                var hr = document.createElement('hr');


                var imagen = document.createElement('IMG');
                imagen.src = 'images/fotoperfil.jpg';
                imagen.className = "img-rounded media-object";
                imagen.setAttribute("width", "60");

                div2.append(imagen);

                var div3 = document.createElement('div');
                div3.className = "media-right";

                var h4 = document.createElement('h4');
                h4.className = "media-heading";
                h4.textContent = "usuario";

                var p = document.createElement('p');
                p.textContent = data[x];

                div3.append(h4);
                div3.append(p);

                div.append(div2);
                div.append(hr);
                div.append(div3);
                div.append(hr);
                $('#secciones').append(div);

            }

        },
        error: function(error) {
            console.log(error.message);
            alert('error');
        }


    });



}



var buscador = document.getElementById('formulario');
buscador.addEventListener('submit', function(e) {
    e.preventDefault();



    var filtro = document.getElementById("search").value;
    if (document.getElementById("contenedorMaestro") != null) {
        var maestro = document.getElementById("contenedorMaestro");
        var aprendiz = document.getElementById("contenedorAprendiz");
        maestro.remove(aprendiz);
        if (document.getElementById("borrar") != null) {

            var borrar = document.getElementById("borrar");
            var seccion = document.getElementById("seccionComentarios");
            borrar.remove(seccion);
        }

        if (document.getElementById("borrar2") != null) {

            var borrar2 = document.getElementById("borrar2");
            var footer = document.getElementById("footer");
            borrar2.remove(footer);
        }


    }

    var main = document.createElement('main');
    main.className = "seccion-top";
    var ddiv = document.createElement('div');
    ddiv.className = "container-fluid";
    main.append(ddiv);
    var dddiv = document.createElement('div');
    dddiv.className = "row";
    var divv = document.createElement('div');
    divv.id = "panel";
    divv.className = "panel";
    dddiv.append(divv);
    ddiv.append(dddiv);
    var maestro2 = document.createElement('main');
    maestro2.className = "contenedor seccion";
    maestro2.id = "contenedorMaestro";
    maestro2.append(main);

    $('body').append(maestro2);

    $.ajax({
        type: "GET",
        url: "https://localhost:44398/api/Publicacion/ProductosPublicacionFiltro?filtro=" + filtro,




        dataType: "json",




        success: function(data) {
            var maestro2 = document.createElement('div');
            maestro2.className = "col-md-12";
            maestro2.id = "maestro";
            var divcontenedor = document.createElement('div');
            divcontenedor.className = "w3-row-padding";
            divcontenedor.id = "contenedor";
            $.each(data, function(i, item) {







                var div = document.createElement('div');
                div.className = "w3-col s4  w3-hover-shadow  w3-margin-top containere";


                var imagen = document.createElement('IMG');
                imagen.src = 'images/' + item.imagen;
                imagen.id = item.publicacionID;

                var div2 = document.createElement('div');
                div2.className = "middle";

                var boton = document.createElement('button');
                boton.className = "text btn";
                boton.textContent = "Añadir Al Carrito";
                boton.id = item.productoID;

                boton.onclick = function() {
                    $.ajax({
                        type: "POST",
                        url: "https://localhost:44310/api/CarritoProducto/InsertarCarritoProductoCliente?carritoID=" + localStorage.getItem("carritoID") + "&productoID=" + item.productoID,
                        dataType: "json",
                        success: function(data) {

                        }


                    });
                }
                div2.append(boton);

                var div3 = document.createElement('div');
                div3.className = "w3-center btn-link description-producto";


                var a = document.createElement('a');
                a.onclick = function() {
                    llenarLocalStorage(item.publicacionID);
                    location.href = "producto.html";
                }
                var p = document.createElement('p');
                p.className = "titulo";
                p.textContent = item.nombre + " / " + "$" + item.precio;
                a.append(p);
                div3.append(a);

                div.append(imagen);
                div.append(div2);
                div.append(div3);
                divcontenedor.append(div);
                $('#panel').append(maestro2);
                maestro2.append(divcontenedor);





            });
        }



    });
});

function llenarLocalStorage(publicacionID) {
    localStorage.setItem("publicacionID", parseInt(publicacionID));

}






function FiltrarDescripcion(descripcion) {

    if (document.getElementById("contenedorMaestro") != null) {
        var maestro = document.getElementById("contenedorMaestro");
        var aprendiz = document.getElementById("contenedorAprendiz");
        maestro.remove(aprendiz);
        if (document.getElementById("borrar") != null) {

            var borrar = document.getElementById("borrar");
            var seccion = document.getElementById("seccionComentarios");
            borrar.remove(seccion);
        }

        if (document.getElementById("borrar2") != null) {

            var borrar2 = document.getElementById("borrar2");
            var footer = document.getElementById("footer");
            borrar2.remove(footer);
        }


    }

    var main = document.createElement('main');
    main.className = "seccion-top";
    var ddiv = document.createElement('div');
    ddiv.className = "container-fluid";
    main.append(ddiv);
    var dddiv = document.createElement('div');
    dddiv.className = "row";
    var divv = document.createElement('div');
    divv.id = "panel";
    divv.className = "panel";
    dddiv.append(divv);
    ddiv.append(dddiv);
    var maestro2 = document.createElement('main');
    maestro2.className = "contenedor seccion";
    maestro2.id = "contenedorMaestro";
    maestro2.append(main);

    $('body').append(maestro2);

    $.ajax({
        type: "GET",
        url: "https://localhost:44398/api/Publicacion/ProductosPublicacionFiltroDescripcion?filtro=" + descripcion,




        dataType: "json",




        success: function(data) {
            var maestro2 = document.createElement('div');
            maestro2.className = "col-md-12";
            maestro2.id = "maestro";
            var divcontenedor = document.createElement('div');
            divcontenedor.className = "w3-row-padding";
            divcontenedor.id = "contenedor";
            $.each(data, function(i, item) {







                var div = document.createElement('div');
                div.className = "w3-col s4  w3-hover-shadow  w3-margin-top containere";


                var imagen = document.createElement('IMG');
                imagen.src = 'images/' + item.imagen;
                imagen.id = item.publicacionID;

                var div2 = document.createElement('div');
                div2.className = "middle";

                var boton = document.createElement('button');
                boton.className = "text btn";
                boton.textContent = "Añadir Al Carrito";
                boton.id = item.productoID;

                boton.onclick = function() {
                    $.ajax({
                        type: "POST",
                        url: "https://localhost:44310/api/CarritoProducto/InsertarCarritoProductoCliente?carritoID=" + localStorage.getItem("carritoID") + "&productoID=" + item.productoID,
                        dataType: "json",
                        success: function(data) {

                        }


                    });
                }
                div2.append(boton);

                var div3 = document.createElement('div');
                div3.className = "w3-center btn-link description-producto";


                var a = document.createElement('a');
                a.onclick = function() {
                    llenarLocalStorage(item.publicacionID);
                    location.href = "producto.html";
                }
                var p = document.createElement('p');
                p.className = "titulo";
                p.textContent = item.nombre + " / " + "$" + item.precio;
                a.append(p);
                div3.append(a);

                div.append(imagen);
                div.append(div2);
                div.append(div3);
                divcontenedor.append(div);
                $('#panel').append(maestro2);
                maestro2.append(divcontenedor);





            });
        }



    });
}



function AgregarAlCarrito() {

    var objeto = {
        productoID: parseInt(localStorage.getItem("productoID")),
        carritoID: parseInt(localStorage.getItem("carritoID")),
        cantidad: parseInt(document.getElementById("cantidadProducto").value)
    }

    $.ajax({
        url: "https://localhost:44310/api/CarritoProducto/InsertarCarritoProductoCantidad",
        data: JSON.stringify(objeto),
        type: "POST",
        dataType: 'JSON',
        contentType: "application/json",
        success: function(data) {

        }

    });
}