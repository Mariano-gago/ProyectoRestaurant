using Application.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class AllContext : DbContext
    {
        public DbSet<Bebidas> Bebidas { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Entradas> Entradas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
