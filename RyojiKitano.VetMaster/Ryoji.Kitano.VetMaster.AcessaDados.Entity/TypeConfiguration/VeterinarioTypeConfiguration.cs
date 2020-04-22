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
    public class VeterinarioTypeConfiguration : EntityAbstractConfig<Veterinario>
    {
        protected override void ConfigurarNomeTabela()
        {
            ToTable("VET_VETERINARIOs");
        }

        protected override void ConfigurarCampoTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("VET_ID");

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnName("VET_NOME");

            Property(p => p.CRV)
                .IsRequired()
                .HasColumnName("VET_CRV");

            Property(p => p.AnimalAtendido)
                .HasMaxLength(40)
                .HasColumnName("VET_ANIMAL_ATENDIDO")
                .IsRequired();
            

            Property(p => p.DataHoraAtendimento)
                .IsRequired()
                .HasColumnType("DateTime")
                .HasColumnName("VET_DATA_HORA_ATENDIMENTO");
                
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(p => p.Id);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
            
        }
    }
}