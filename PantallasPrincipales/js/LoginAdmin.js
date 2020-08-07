//----------------------------------------------------------------->
var singupForm = document.querySelector('#SingUpForm');
//Sing Up
singupForm.addEventListener('submit', (e) => {
    e.preventDefault();
    var dato = new FormData(singupForm);
    var email = dato.get('email');
    var contraseña = dato.get('pwd');

    auth.signInWithEmailAndPassword(email, contraseña)
        .then(userCredential => {
            var user = userCredential.uid;
            localStorage.setItem("uid",`${userCredential.user.uid}`);
            location.href="/PantallasPrincipales/PaginaPrincipal.html";
        })

});

//------------------------------------------------------------------>
//Restablecer contraseña
function RestablecerContraseña() {
    var email = document.querySelector('#email').value;
    var comentario = document.getElementById('comentario1');
    if (email == "") {

        comentario.innerHTML = `  
    <!-- Modal -->
            <div class="modal fade" id="myModal" role="dialog">
                <div class="modal-dialog">
                
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    
                    </div>
                    <div class="modal-body">
                    <p>Ingrese su correo electronico.</p>
                    </div>
                    <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
                
                </div>
            </div>
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
Observador();