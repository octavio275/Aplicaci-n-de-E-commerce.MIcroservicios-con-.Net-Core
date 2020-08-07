using Domain.ENTITIES;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Context:DbContext
    {
        public DbSet<UsersRoles> UserRole { get; set; }
        public DbSet<Role> role { get; set; }
        public DbSet<Users> user { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}
