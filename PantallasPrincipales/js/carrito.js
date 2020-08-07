window.onload = function() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44310/api/Carrito/ProductosValorCarritoCliente?clienteID=" + localStorage.getItem("clienteID"),

        dataType: "json",
        success: function(data) {
            var precio = document.getElementById("precio");
            precio.innerHTML = "TOTAL: " + "$" + data.valorcarrito;
            localStorage.setItem("valorcarrito", data.valorcarrito);
            $.each(data.productos, function(i, item) {

                var tr = document.createElement('tr');
                var td = document.createElement('td');

                var div = document.createElement('div');
                div.className = "contenedor-imagen";

                var imagen = document.createElement('IMG');
                imagen.src = 'images/' + item.imagen;
                imagen.id = item.productoID;



                div.append(imagen);
                td.append(div);
                tr.append(td);


                var td1 = document.createElement('td');
                td1.className = "titulo";
                td1.innerHTML = item.nombre;
                var td2 = document.createElement('td');
                td2.className = "precio";
                td2.textContent = "$" + item.precio;
                var td3 = document.createElement('td');
                td3.className = "cantidad";
                var texto = "unidades";
                if (item.cantidad == 1) {
                    texto = "unidad";
                }
                td3.textContent = item.cantidad + " " + texto;
                var td4 = document.createElement('td');
                td4.className = "centrar-boton";


                var a = document.createElement('button');
                a.className = "btn btn-danger centrar-boton";
                a.textContent = "Borrar";

                a.onclick = function() {
                    $.ajax({
                        type: "GET",
                        url: "https://localhost:44310/api/Carrito/BorrarProductoCarrito?productoID=" + item.productoID + "&carritoID=" + localStorage.getItem("carritoID"),
                        dataType: "json",
                        success: function(data) {

                            var precio = document.getElementById("precio");
                            precio.innerHTML = precio.innerHTML - item.precio;
                            location.reload();

                        }


                    });
                }

                td4.append(a);
                tr.append(td1);
                tr.append(td2);
                tr.append(td3);
                tr.append(td4);



                $('#contenedor').append(tr);

            });

        },
        error: function(error) {
            console.log(error.message);
            alert('error');
        }




    });




}


function cancelar() {

    $.ajax({
        type: "GET",
        url: "https://localhost:44310/api/Carrito/BorrarCarritoCompleto?carritoID=" + localStorage.getItem("carritoID"),
        dataType: "json",
        success: function(data) {


            location.reload();

        }


    });


}


function FiltrarDescripcion(descripcion) {
    if (document.getElementById('main') != null) {
        var mainmaestro = document.getElementById('main');

        var body = document.getElementById("body");

        body.removeChild(mainmaestro);
    }
    //de aca para abjoe esto si va
    var main = document.createElement('div');
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

    var mainmaestro2 = document.createElement('main');
    mainmaestro2.id = "main";
    mainmaestro2.className = "contenedor seccion";
    //mainmaestro2.className="MainCarrito";

    mainmaestro2.append(main);
    var body = document.getElementById("body");
    var footer = document.getElementById("footerr");
    body.insertBefore(mainmaestro2, footer);

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
                imagen.style.width = "100%";

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
var buscador = document.getElementById('formulario');
buscador.addEventListener('submit', function(e) {
    e.preventDefault();


    var filtro = document.getElementById("search").value;
    if (document.getElementById('main') != null) {
        var mainmaestro = document.getElementById('main');

        var body = document.getElementById("body");

        body.removeChild(mainmaestro);
    }
    //de aca para abjoe esto si va
    var main = document.createElement('div');
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

    var mainmaestro2 = document.createElement('main');
    mainmaestro2.id = "main";
    mainmaestro2.className = "contenedor seccion";
    //mainmaestro2.className="MainCarrito";

    mainmaestro2.append(main);
    var body = document.getElementById("body");
    var footer = document.getElementById("footerr");
    body.insertBefore(mainmaestro2, footer);

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
                imagen.style.width = "100%";

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

function comprar() {
    if (parseInt(localStorage.getItem("valorcarrito")) > 0) {
        $.ajax({
            type: "POST",
            url: "https://localhost:44321/api/venta/InsertarVenta?carritoID=" + localStorage.getItem("carritoID"),
            dataType: "json",
            success: function(data) {
                cancelar();

            }


        });

    } else {

        alert("hola");

    }

}



function iniciarSesion() {

    location.href = "/PantallasPrincipales/login.html";

}