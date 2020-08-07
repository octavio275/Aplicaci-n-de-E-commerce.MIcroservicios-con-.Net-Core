using Domain.DTOS;
using Domain.QUERYS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public interface IAuthenticacionService
    {
        Task<ClienteCarritoDTOs> getCarrito(string uids);
        Task<ClienteCarritoDTOs> getCarritoAdmin(string uids);
    }
    public class AuthenticacionService : IAuthenticacionService
    {
        private readonly IAuthenticationQuery _query;

        public AuthenticacionService(IAuthenticationQuery query)
        {
            _query = query;
        }

        public Task<ClienteCarritoDTOs> getCarrito(string uids)
        {
            return _query.getCarrito(uids);
        }

        public Task<ClienteCarritoDTOs> getCarritoAdmin(string uids)
        {
            return _query.getCarritoAdmin(uids);
        }
    }
}
