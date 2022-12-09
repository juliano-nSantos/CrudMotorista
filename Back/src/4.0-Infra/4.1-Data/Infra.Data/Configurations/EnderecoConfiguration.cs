using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");
            builder.HasKey(p => p.IdEndereco).HasName("PK_Enderecos");
            builder.Property(p => p.Logradouro).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(p => p.Numero).HasColumnType("CHAR(5)");
            builder.Property(p => p.Bairro).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(p => p.Cidade).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(p => p.UF).HasColumnType("CHAR(2)").IsRequired();
            builder.Property(p => p.Cep).HasColumnType("CHAR(10)").IsRequired();
            
        }
    }
}