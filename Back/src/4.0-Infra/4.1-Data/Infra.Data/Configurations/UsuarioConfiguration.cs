using System.Collections.Immutable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(p => p.IdUsuario).HasName("PK_Usuarios");
            builder.Property(p => p.NomeUsuario).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(p => p.CPF).HasColumnType("VARCHAR(12)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.Senha).HasColumnType("VARCHAR(256)").IsRequired();
            builder.Property(p => p.DataCadastro).HasColumnType("datetime").HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(p => p.DataAtualizacao).HasColumnType("datetime").HasDefaultValueSql("GETDATE()").ValueGeneratedOnAddOrUpdate();
            builder.Property(p => p.PrimeiroAcesso).HasColumnType("BIT").HasDefaultValue(1);

            builder.HasIndex(p => p.CPF).HasDatabaseName("UQ_CPF_Usuarios").IsUnique();
            builder.HasIndex(p => p.Email).HasDatabaseName("UQ_Email_Usuarios").IsUnique();

            builder.HasOne(fk => fk.StatusUsuarios)
                   .WithMany(stu => stu.Usuarios)
                   .HasForeignKey(fk => fk.StatusUsuarioId)
                   .HasConstraintName("FK_Usuarios_StatusUsuarios");

            builder.HasOne(p => p.Permissoes)
                   .WithMany(pe => pe.Usuarios)
                   .HasForeignKey(fk => fk.PermissaoId)
                   .HasConstraintName("FK_Usuarios_Permissoe");
        }
    }
}