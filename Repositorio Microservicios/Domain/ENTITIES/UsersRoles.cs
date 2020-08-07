using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.ENTITIES
{
    public class UsersRoles
    {
        [Key]
        public int UsuarioId { get; set; }
        public int RoleId { get; set; }

        public virtual ICollection<Users> User { get; set; }
        public virtual ICollection<Role> Role { get; set; }
    }
}
