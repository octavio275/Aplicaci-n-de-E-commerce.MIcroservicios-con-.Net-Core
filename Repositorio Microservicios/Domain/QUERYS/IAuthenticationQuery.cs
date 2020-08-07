using Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.QUERYS
{
    public interface IAuthenticationQuery
    {
        Task<ClienteCarritoDTOs> getCarrito(string uids);
        Task<ClienteCarritoDTOs> getCarritoAdmin(string uids);
    }
}
