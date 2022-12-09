using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext() { }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) {}
            
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<StatusMotorista> StatusMotoristas { get; set; }
        public DbSet<StatusUsuario> StatusUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableSensitiveDataLogging()
                .UseSqlServer("Server=JULIANO-PC;Database=CrudMotorista;user id=sa;password=123456;Trusted_Connection=false;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlContext).Assembly);            
        }
    }
}