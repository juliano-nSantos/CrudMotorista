using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class StatusMotoristaConfiguration : IEntityTypeConfiguration<StatusMotorista>
    {
        public void Configure(EntityTypeBuilder<StatusMotorista> builder)
        {
            builder.ToTable("StatusMotoristas");
            builder.HasKey(p => p.IdStatusMotorista).HasName("PK_StatusMotoristas");
            builder.Property(p => p.DscStatusMotorista).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(p => p.Ativo).HasColumnType("BIT");
        }
    }
}