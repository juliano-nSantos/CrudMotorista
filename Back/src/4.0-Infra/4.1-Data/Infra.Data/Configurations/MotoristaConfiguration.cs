using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class MotoristaConfiguration : IEntityTypeConfiguration<Motorista>
    {
        public void Configure(EntityTypeBuilder<Motorista> builder)
        {
            builder.ToTable("Motoristas");
            builder.HasKey(p => p.IdMotorista).HasName("PK_Motoristas");
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(p => p.CPF).HasColumnType("VARCHAR(20)").IsRequired();
            builder.Property(p => p.Sexo).HasColumnType("CHAR(1)").IsRequired();
            builder.Property(p => p.DataNascimento).HasColumnType("datetime").IsRequired();

            builder.HasIndex(i => i.CPF).HasDatabaseName("UQ_CPF_Motoristas").IsUnique();
            builder.HasIndex(i => i.Nome).HasDatabaseName("idx_Nome_Motorista");

            builder.HasOne(k => k.StatusMotoristas)
                   .WithMany(p => p.Motoristas)
                   .HasForeignKey(k => k.StatusMotoristaId)
                   .HasConstraintName("FK_Motoristas_StatusMotoristas");

            builder.HasOne(k => k.Enderecos)
                   .WithMany(p => p.Motoristas)
                   .HasForeignKey(k => k.EnderecoId)
                   .HasConstraintName("FK_Motoristas_Enderecos");
        }
    }
}