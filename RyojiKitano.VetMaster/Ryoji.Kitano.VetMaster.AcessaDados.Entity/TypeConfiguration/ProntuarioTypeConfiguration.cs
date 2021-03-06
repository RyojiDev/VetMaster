﻿using Ryoji.Kitano.VetMaster.Dominio;
using RyojiKitano.AcessaADados.Common.Entity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryoji.Kitano.VetMaster.AcessaDados.Entity.TypeConfiguration
{
    class ProntuarioTypeConfiguration : EntityAbstractConfig<Prontuario>
    {
        protected override void ConfigurarNomeTabela()
        {
            ToTable("PRT_PRONTUARIOS");
        }

        protected override void ConfigurarCampoTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("PRT_ID");

            Property(p => p.AnimalAtendido)
                .HasColumnName("ANIMALATENDIDO")
                .HasMaxLength(40)
                .IsRequired();

            Property(p => p.DataHoraAtendimento)
                .HasColumnType("DateTime")
                .IsRequired()
                .HasColumnName("PRT_DATA_HORA_ATENDIMENTO");

            Property(p => p.Observacoes)
                .HasMaxLength(500)
                .IsOptional()
                .HasColumnName("OBSERVACOES");

            Property(p => p.IdVeterinario)
                .HasColumnName("PRT_VETERINARIO_ID");


        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(p => p.Id);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
            /*HasRequired(p => p.Veterinario)
                .WithMany(fk => fk.Prontuarios)
                .HasForeignKey(fk => fk.IdVeterinario);*/
        }
    }
}
