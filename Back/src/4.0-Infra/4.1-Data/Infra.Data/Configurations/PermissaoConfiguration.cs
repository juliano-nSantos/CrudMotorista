using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class PermissaoConfiguration : IEntityTypeConfiguration<Permissao>
    {
        public void Configure(EntityTypeBuilder<Permissao> builder)
        {
            builder.ToTable("Permissoes");
            builder.HasKey(p => p.IdPermissao).HasName("PK_Permissoes");
            builder.Property(p => p.NomePermissao).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.Ativo).HasColumnType("BIT");
        }
    }
}