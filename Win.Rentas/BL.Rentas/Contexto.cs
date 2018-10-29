﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BL.Rentas.ClientesBL;

namespace BL.Rentas
{
     public class Contexto: DbContext
    {
    
        public Contexto(): base("VideoJuegos")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        
    }
}
