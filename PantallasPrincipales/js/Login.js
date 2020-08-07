//Boton para acceder con google ----------------------------------->
const googleBoton = document.querySelector('#GoogleBoton');


googleBoton.addEventListener('click', e => {
    const provider = new firebase.auth.GoogleAuthProvider();
    auth.signInWithPopup(provider)
        .then(function(result) {
            var user = result.user.uid;
            localStorage.setItem("uid", `${user}`);
            location.href = "/PantallasPrincipales/PaginaPrincipal.html";
        })
        .catch(erro => {
            console.log(erro);
        })
});

//----------------------------------------------------------------->


//------------------------------------------------------------------>
//Restablecer contraseña
function RestablecerContraseña() {
    var email = document.querySelector('#email').value;
    var comentario = document.getElementById('comentario1');
    if (email == "") {

        comentario.innerHTML = `
                    <!-- Modal -->
                    <
                    div class = "modal fade"
                id = "myModal"
                role = "dialog" >
                <
                div class = "modal-dialog" >

                <!-- Modal content-->
                <
                div class = "modal-content" >
                <
                div class = "modal-header" >
                <
                button type = "button"
                class = "close"
                data - dismiss = "modal" > & times; < /button>

                <
                /div> <
                div class = "modal-body" >
                <
                p > Ingrese su correo electronico. < /p> <
                /div> <
                div class = "modal-footer" >
                <
                button type = "button"
                class = "btn btn-default"
                data - dismiss = "modal" > Cerrar < /button> <
                /div> <
                /div>

                <
                /div> <
                /div>
                `;

    } else {
        var auth = firebase.auth();
        var emailAddress = email;

        auth.sendPasswordResetEmail(emailAddress).then(function() {
            alert("Se ha enviado un correo a su cuenta, siga los pasos indicados");
        }).catch(function(error) {
            console.log(error);
        });
    }

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
            console.log(uid);
            var providerData = user.providerData;
            // ...
            //devuelve el token del usuario
            user.getIdToken().then(function(data) {
                console.log(data)
            });

        } else {
            // User is signed out.
            // ...
            console.log("no existe el usuario");
        }
    });
}


function Aparece(user) {
    //Si se verifico el usuario que rediriga la pagina
    if (user.emailVerified == true) {
        location.href = "../PantallasPrincipales/PaginaPrincipal.html";
    }
}