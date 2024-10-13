using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD_Owners_RealState.Models
{
    public class DbContextClass : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Nominee> Nominees { get; set; }

        public DbContextClass() : base("MyDbContext")
        {

        }
    }
}