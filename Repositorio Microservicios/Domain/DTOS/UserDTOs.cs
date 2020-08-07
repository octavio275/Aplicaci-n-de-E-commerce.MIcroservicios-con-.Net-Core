using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOS
{
    public class UserDTOs
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

        public string Telefono { get; set; }
        public string Password { get; set; }
    }
}
