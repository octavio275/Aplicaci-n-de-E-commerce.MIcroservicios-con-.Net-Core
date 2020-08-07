using Domain.COMANDOS;
using Domain.DTOS;
using Domain.QUERYS;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Domain.ENTITIES;
using Newtonsoft.Json;

namespace Data.QUERYS
{
    public class AuthenticacionQuery : IAuthenticationQuery
    {
        private readonly Context context;
        private readonly IGenericRepository _repository;

        public AuthenticacionQuery(Context context, IGenericRepository repository)
        {
            this.context = context;
            _repository = repository;
        }

        public async Task<ClienteCarritoDTOs> getCarrito(string uids)
        {
            ClienteCarritoDTOs clientecarrito = new ClienteCarritoDTOs();
            HttpClient http = new HttpClient();
            //Inicializo la app de firebase aca 
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(@"C:\Users\Alan\Pictures\INFORME METODOLOGIA\MicroservicioUser\MicroservicioUser\Privatekey\usuario-5093e-firebase-adminsdk-43fcf-1bf89503c6.json"),
            });
            var result = await FirebaseAuth.DefaultInstance.GetUserAsync(uids);
            var ExisteCliente = (from x in context.user where x.uid == uids select x.Id).FirstOrDefault<int>();
            if (ExisteCliente == 0)
            {
                var enityClient = new Users()
                {
                    uid = uids,
                    Nombre = result.DisplayName,
                    gmail = result.Email

                };
                _repository.Add<Users>(enityClient);
                var userrol = new UsersRoles()
                {
                    RoleId = 2,
                    UsuarioId = ExisteCliente
                };
                _repository.Add<UsersRoles>(userrol);
                ExisteCliente = (from x in context.user where x.uid == uids select x.Id).FirstOrDefault<int>();

                string url = " https://localhost:44310/api/Carrito/VerificarClienteCarrito?clienteID=" + ExisteCliente;
                string request = await http.GetStringAsync(url);
                int gets = JsonConvert.DeserializeObject<int>(request);
                clientecarrito.CarritoId = gets;
                clientecarrito.ClienteId = ExisteCliente;
                clientecarrito.RolId = 2;

            }
            else
            {

                string url = " https://localhost:44310/api/Carrito/VerificarClienteCarrito?clienteID=" + ExisteCliente;
                string request = await http.GetStringAsync(url);
                int gets = JsonConvert.DeserializeObject<int>(request);
                clientecarrito.CarritoId = gets;
                clientecarrito.ClienteId = ExisteCliente;
                clientecarrito.RolId = 2;
            }

            return clientecarrito;
        }

        public async Task<ClienteCarritoDTOs> getCarritoAdmin(string uids)
        {
            ClienteCarritoDTOs clientecarrito = new ClienteCarritoDTOs();
            HttpClient http = new HttpClient();
            //Inicializo la app de firebase aca 
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(@"C:\Users\Alan\Pictures\INFORME METODOLOGIA\MicroservicioUser\MicroservicioUser\Privatekey\usuario-5093e-firebase-adminsdk-43fcf-1bf89503c6.json"),
            });
            var result = await FirebaseAuth.DefaultInstance.GetUserAsync(uids);
            var ExisteCliente = (from x in context.user where x.uid == uids select x.Id).FirstOrDefault<int>();
            if (ExisteCliente == 0)
            {
                var enityClient = new Users()
                {
                    uid = uids,
                    Nombre = result.DisplayName,
                    gmail = result.Email

                };
                _repository.Add<Users>(enityClient);
                var userrol = new UsersRoles()
                {
                    RoleId = 2,
                    UsuarioId = ExisteCliente
                };
                _repository.Add<UsersRoles>(userrol);
                ExisteCliente = (from x in context.user where x.uid == uids select x.Id).FirstOrDefault<int>();

                string url = " https://localhost:44310/api/Carrito/VerificarClienteCarrito?clienteID=" + ExisteCliente;
                string request = await http.GetStringAsync(url);
                int gets = JsonConvert.DeserializeObject<int>(request);
                clientecarrito.CarritoId = gets;
                clientecarrito.ClienteId = ExisteCliente;
                clientecarrito.RolId = 1;

            }
            else
            {

                string url = " https://localhost:44310/api/Carrito/VerificarClienteCarrito?clienteID=" + ExisteCliente;
                string request = await http.GetStringAsync(url);
                int gets = JsonConvert.DeserializeObject<int>(request);
                clientecarrito.CarritoId = gets;
                clientecarrito.ClienteId = ExisteCliente;
                clientecarrito.RolId = 1;
            }

            return clientecarrito;
        }
    }
}
