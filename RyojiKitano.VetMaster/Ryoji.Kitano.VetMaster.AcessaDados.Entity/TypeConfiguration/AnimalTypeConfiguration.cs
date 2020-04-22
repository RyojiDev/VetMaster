using Ryoji.Kitano.VetMaster.Dominio;
using RyojiKitano.AcessaADados.Common.Entity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Ryoji.Kitano.VetMaster.AcessaDados.Entity.TypeConfiguration
{
    public class AnimalTypeConfiguration : EntityAbstractConfig<Animal>
    {
        protected override void ConfigurarNomeTabela()
        {
            ToTable("ANM_Animais");
        }

        protected override void ConfigurarCampoTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("ANM_ID");

            Property(p => p.NomeDoDono)
                .IsOptional()
                .HasMaxLength(40)
                .HasColumnName("ANM_NOME_DONO");

            Property(p => p.Raça)
                .HasMaxLength(40)
                .IsRequired()
                .HasColumnName("ANM_RAÇA");

            Property(p => p.IdVeterinario)
                .HasColumnName("ANM_VETERINARIO_ID")
                .IsOptional();
                


        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(p => p.Id);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
            HasRequired(p => p.Veterinario)
                .WithMany(p => p.Animais)
                .HasForeignKey(fk => fk.IdVeterinario);
        }
    }
}
