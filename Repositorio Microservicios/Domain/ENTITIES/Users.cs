using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.ENTITIES
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string uid { get; set; }
        public string Nombre { get; set; }
        public string gmail { get; set; }
        public virtual UsersRoles UserRole { get; set; }
    }
}
