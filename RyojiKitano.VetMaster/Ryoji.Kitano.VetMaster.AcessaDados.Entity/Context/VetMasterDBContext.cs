using Ryoji.Kitano.VetMaster.AcessaDados.Entity.TypeConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Ryoji.Kitano.VetMaster.AcessaDados.Entity.Context
{
    public class VetMasterDBContext : DbContext
    {
        public DbSet Animal { get; set; }
        public DbSet Veterinario { get; set; }
        public DbSet Prontuario { get; set; }

        public VetMasterDBContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VeterinarioTypeConfiguration());
            modelBuilder.Configurations.Add(new ProntuarioTypeConfiguration());
            modelBuilder.Configurations.Add(new AnimalTypeConfiguration());


        }
    }
}
