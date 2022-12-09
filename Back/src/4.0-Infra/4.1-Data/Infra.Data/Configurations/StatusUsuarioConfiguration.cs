using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class StatusUsuarioConfiguration : IEntityTypeConfiguration<StatusUsuario>
    {
        public void Configure(EntityTypeBuilder<StatusUsuario> builder)
        {
            builder.ToTable("StatusUsuarios");
            builder.HasKey(p => p.IdStatusUsuario).HasName("PK_StatusUsuarios");
            builder.Property(p => p.DscStatusUsuario).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.Ativo).HasColumnType("BIT");
        }
    }
}