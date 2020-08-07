window.onload = function() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44398/api/Publicacion/TraerProductosPublicaciones?CANTIDAD=" + localStorage.getItem("offset"),




        dataType: "json",
        success: function(data) {




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
                boton.setAttribute("data-toggle", "modal");
                boton.setAttribute("data-target", "#myModal");
                boton.textContent = "Anadir Al Carrito";
                boton.id = item.productoID;

                boton.onclick = function() {
                    if (localStorage.getItem("carritoID") != null) {
                        $.ajax({
                            type: "POST",
                            url: "https://localhost:44310/api/CarritoProducto/InsertarCarritoProductoCliente?carritoID=" + localStorage.getItem("carritoID") + "&productoID=" + item.productoID,
                            dataType: "json",
                            success: function(data) {

                            }


                        });

                    } else {
                        alert("No esta registrado, inicie sesion para agregar productos a su carrito");
                    }

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

                $('#contenedor').append(div);






            });
            // var divboton = document.createElement("div");
            //divboton.className="verMas w3-center w3-margin-top w3-margin-bottom";
            //var boton2= document.createElement("button");
            //boton2.className="btn btn-default";
            //boton2.onclick= VerMas();
            //$("#panel").append(divboton);



        },
        error: function(error) {
            console.log(error.message);
            alert('error');
        }

    });

    if (localStorage.getItem("usuario") == "usuario") {

        if (localStorage.getItem("uid") != null && localStorage.getItem("carritoID") == null && localStorage.getItem("clienteID") == null) {

            $.ajax({
                type: "GET",
                url: "https://localhost:44346/api/Authenticacion/getCliente?uids=" + localStorage.getItem("uid"),
                dataType: "json",
                success: function(data) {
                    console.log(data);
                    localStorage.setItem("carritoID", data.carritoId);
                    localStorage.setItem("clienteID", data.clienteId);
                    localStorage.setItem("rolId", data.rolId);
                }

            });

        }
    } else {
        if (localStorage.getItem("uid") != null && localStorage.getItem("carritoID") == null && localStorage.getItem("clienteID") == null) {
            $.ajax({
                type: "GET",
                url: "https://localhost:44346/api/Authenticacion/getClienteAdmin?uids=" + localStorage.getItem("uid"),
                dataType: "json",
                success: function(data) {
                    console.log(data);
                    localStorage.setItem("carritoID", data.carritoId);
                    localStorage.setItem("clienteID", data.clienteId);
                    localStorage.setItem("rolId", data.rolId);
                    location.reload();
                }

            });
        }


    }

    if (parseInt(localStorage.getItem("rolId")) == 1) {
        var configuracion = document.getElementById("configuracion");
        configuracion.innerHTML = '<a href="/PantallasPrincipales/panel.html"><i class="glyphicon glyphicon-cog w3-margin-top" aria-hidden="true" style="font-size: 24px;"></i></a>';
    }



}



function VerMas() {
    var offset = parseInt(localStorage.getItem("offset"));
    offset = offset + 6;
    localStorage.setItem("offset", `${offset}`);
    $.ajax({
        type: "GET",
        url: "https://localhost:44398/api/Publicacion/TraerProductosPublicaciones?CANTIDAD=" + localStorage.getItem("offset"),




        dataType: "json",
        success: function(data) {
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
                    if (localStorage.getItem("carritoID") != null) {
                        $.ajax({
                            type: "POST",
                            url: "https://localhost:44310/api/CarritoProducto/InsertarCarritoProductoCliente?carritoID=" + localStorage.getItem("carritoID") + "&productoID=" + item.productoID,
                            dataType: "json",
                            success: function(data) {

                            }


                        });

                    } else {
                        alert("No esta registrado, inicie sesion para agregar productos a su carrito");
                    }

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
                $('#contenedor').append(div);






            });



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
    if (document.getElementById("maestro") != null) {
        var maestro = document.getElementById("maestro");
        var contenedor = document.getElementById("contenedor");
        var paginacion = document.getElementById("paginacion");
        maestro.remove(contenedor);
        paginacion.innerHTML = "";
    }
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
                    if (localStorage.getItem("carritoID") != null) {
                        $.ajax({
                            type: "POST",
                            url: "https://localhost:44310/api/CarritoProducto/InsertarCarritoProductoCliente?carritoID=" + localStorage.getItem("carritoID") + "&productoID=" + item.productoID,
                            dataType: "json",
                            success: function(data) {

                            }


                        });

                    } else {
                        alert("No esta registrado, inicie sesion para agregar productos a su carrito");
                    }

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



function BuscarDescripcion(descripcion) {
    if (document.getElementById("maestro") != null) {
        var maestro = document.getElementById("maestro");
        var contenedor = document.getElementById("contenedor");
        var paginacion = document.getElementById("paginacion");
        maestro.remove(contenedor);
        maestro.remove(paginacion);
        paginacion.innerHTML = "";
    }
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
                    if (localStorage.getItem("carritoID") != null) {
                        $.ajax({
                            type: "POST",
                            url: "https://localhost:44310/api/CarritoProducto/InsertarCarritoProductoCliente?carritoID=" + localStorage.getItem("carritoID") + "&productoID=" + item.productoID,
                            dataType: "json",
                            success: function(data) {

                            }


                        });

                    } else {
                        alert("No esta registrado, inicie sesion para agregar productos a su carrito");
                    }

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



function BuscarCategoria(categoria) {
    if (document.getElementById("maestro") != null) {
        var maestro = document.getElementById("maestro");
        var contenedor = document.getElementById("contenedor");
        var paginacion = document.getElementById("paginacion");
        maestro.remove(contenedor);
        maestro.remove(paginacion);
        paginacion.innerHTML = "";
    }
    $.ajax({
        type: "GET",
        url: "https://localhost:44398/api/Publicacion/ProductosPublicacionFiltroCategoria?filtro=" + categoria,




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
                    if (localStorage.getItem("carritoID") != null) {
                        $.ajax({
                            type: "POST",
                            url: "https://localhost:44310/api/CarritoProducto/InsertarCarritoProductoCliente?carritoID=" + localStorage.getItem("carritoID") + "&productoID=" + item.productoID,
                            dataType: "json",
                            success: function(data) {

                            }


                        });

                    } else {
                        alert("No esta registrado, inicie sesion para agregar productos a su carrito");
                    }

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



//--------------------------------------------------------------------FIREBASE------------------------------------------------------------------------------//
var contenido = document.getElementById('contenido');


function Cerrar() {
    firebase.auth().signOut().then(function() {
        console.log("Finalizo sesion");
        location.href = "/PantallasPrincipales/PaginaPrincipal.html";
    }).catch(function(error) {
        console.log(error);
    });
}
//Agregar un Obsevador para obtener información del usuario ingresado a la pagina
function Observador() {
    firebase.auth().onAuthStateChanged(function(user) {
        if (user) {
            Aparece(user);
            // User is signed in.
            console.log("existe usuario activo");
            var displayName = user.displayName;
            var email = user.email;
            var emailVerified = user.emailVerified;
            var photoURL = user.photoURL;
            var isAnonymous = user.isAnonymous;
            var uid = user.uid;
            var providerData = user.providerData;
            // ...
            //devuelve el token del usuario
            user.getIdToken().then(function(data) {
                console.log(data)
            });
            console.log("hola");

        } else {
            // User is signed out.
            // ...
            console.log("no existe el usuario");
        }
    });
}


function iniciarSesion() {

    location.href = "/PantallasPrincipales/login.html";
    localStorage.removeItem("carritoID");
    localStorage.removeItem("clienteID");
    localStorage.removeItem("rolId");

}

function Aparece(user) {
    //Si se verifico el usuario que rediriga la pagina
    if (user.uid != null) {
        contenido.innerHTML = `<a href="#" onclick="Cerrar();">Cerrar sesión</a>`;
    }
}

Observador();

function AlertaModalClienteNoRegistrado() {

    var contenidoNull = document.getElementById("modalContenedor");
    contenidoNull.innerHTML = ` <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">


        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>

            </div>
            <div class="modal-body">
                <p class="texto-error">Inicie sesión para agregar productos al Carrito
                    <span id="div1" class="fa"></span>
                </p>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>

            </div>
        </div>

    </div>
</div> `;
}